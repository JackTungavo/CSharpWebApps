# Authentication

_**This is a Makers Bite.** Bites are designed to train specific skills or
tools. They contain an intro, a demonstration video, some exercises with an
example solution video, and a challenge without a solution video for you to test
your learning. [Read more about how to use Makers
Bites.](https://github.com/makersacademy/course/blob/main/labels/bites.md)_

<!-- OMITTED -->

- Learn to authenticate users

## Introduction

### Authentication
When a user signs into an application, they must present some information that proves they are who they say they are - this is otherwise known as 'authentication'.

MakersBnB will use session-based authentication. When a user is authenticated, some data about that user is stored on the server inside an object called a _session_ and the browser is given the _session id_. When the browser makes further requests, it presents the session id and the server finds the appropriate session. When a user signs out, the session will be cleared.

The user journey will be...
- Navigate to `Sessions/New` and complete the form to sign in
- On success, get redirected to "/Spaces"
- On failure, remain on the sign in form

Once we can authenticate a user and sign them in, we will do a bit more work to prevent signed out users from creating spaces.

### Authorisation
Authorisation is where we think about what different types of user can do. For example, in the Makers Slack Workspaces, I'm an admin user so I can do things like invite new users and moderate content (by deleting posts). You are not an admin user though, so you are not _authorised_ to do these things.

For now, we don't need to think much about authorisation in MakersBnB because all users will be able to everything the app offers, once they have logged in.

### The Feature Test

Of course, we'll need a test for this! Create a new file called `AuthTests.cs` in `MakersBnB.Tests` then add the following...

```cs
namespace MakersBnB.Tests;

using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

public class AuthTests : PageTest
{
    [Test]
    public async Task SigningInWithCorrectCredentials()
    {
        // we need to create a user first
        // you might need to tweak this to work with your sign up form
        await Page.GotoAsync("http://localhost:5106/Users/New");
        await Page.GetByLabel("Password").FillAsync("secret");
        await Page.GetByLabel("Username").FillAsync("username");
        await Page.GetByLabel("Email").FillAsync("email@email.com");
        await Page.GetByRole(AriaRole.Button).ClickAsync();

        // signing in - will fail initially!
        await Page.GotoAsync("http://localhost:5106/Sessions/New");
        await Page.GetByLabel("Email").FillAsync("email@email.com");
        await Page.GetByLabel("Password").FillAsync("secret");
        await Page.GetByRole(AriaRole.Button).ClickAsync();

        // you will need to update `Spaces/Index` to make this pass
        await Expect(Page).ToHaveTitleAsync(new Regex("Spaces - MakersBnB"));

    }
}
```

### Exercise 1: Consolidation

- Create a controller called `SessionsController`
- Give it a method called `New` which returns `View()`
- Create a new file in `Views/Sessions` called `New.cshtml`
- Implement the sign up form in `Views/Sessions/New.cshtml`
- When submitted, the form should make a `POST "/Sessions"` request
- Add a method called `Create` to `SessionsController`
- Use `Console.WriteLine` to verify that `SessionsController.Create` is called when the form is submitted

> We'll do the rest together :)

### Sessions

Now, in the controller...

- Use the submitted email to find a user in the database
- Compare the submitted password with the password of the user in our database
- If the user exists and the passwords match, authentication was successful
  - And we will put the user's id in their session for later
  - Then redirect to "/Spaces"

Here's how it all works...

```cs
// in SessionsController.cs
[Route("/Sessions")]
[HttpPost]
public IActionResult Create(string email, string password) {
    // ASP.NET automatically passes email and password as args (see above)
    
    MakersBnBDbContext dbContext = new MakersBnBDbContext();

    // using the submitted email to find a user in the database
    User? user = dbContext.Users.Where(user => user.Email == email).First();

    // checking if a user was found and that the passwords match
    if(user != null && user.Password == password)
    {
      // putting the user's id in their session for later
      HttpContext.Session.SetInt32("user_id", user.Id);
      return new RedirectResult("/Spaces");
    } else {
      return new RedirectResult("/Sessions/New");
    }
  }
```

Now you need to add a bit of configuration, which tells your app to use sessions. Go to `Program.cs` in `MakersBnb` and find these lines...

```cs
// Add services to the container.
builder.Services.AddControllersWithViews();
```

Then add this below them...

```cs
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
```

Now find this line...

```cs
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

Then add this below it...

```cs
app.UseSession();
```

[Click here to see how `Program.cs` should now look](../examples/session_config/Program.cs)

Once you have implemented the above, your test should pass.

### Securing the Application

So now someone can sign in but that doesn't actually make any difference because nobody actually _needs_ to sign in. We want to stop people from creating spaces unless they are signed in, so we're going to add a _filter_ which will check that the current user has an active session anytime they make a request to `GET "/Spaces/New"` or `POST "/Spaces"`.

First, create a new directory at the _top level_ of `MakersBnB` (alongside `Controllers`, `Models`, `Views` etc) and call it `ActionFilters`. Then create a new file in there called `AuthenticationFilter.cs` and add the following...

```cs
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MakersBnB.ActionFilters
{
  // a class which implements the IActionFilter interface
  public class AuthenticationFilter : IActionFilter {

    // any class implementing IActionFilter must implement this method
    public void OnActionExecuting(ActionExecutingContext context) {

      // check if there is a user_id in current user's session
      int? user_id = context.HttpContext.Session.GetInt32("user_id");
      if(user_id == null) {
        // if there is no user id, redirect to sign in
        context.Result = new RedirectResult("/Sessions/New");
        return;
      }
      else
      {
        // otherwise, continue
        return;
      }
    }

    // any class implementing IActionFilter must implement this method
    public void OnActionExecuted(ActionExecutedContext context) {
      
    }
  }
}
```

You also need to add some configuration which tells the application to use this new filter. Go to `Program.cs` in `MakersBnB` and find these lines...

```cs
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
```

Then add this below them...

```cs
builder.Services.AddScoped<MakersBnB.ActionFilters.AuthenticationFilter>();
```

[Click here to see how `Program.cs` should now look](../examples/auth_filter_config/Program.cs)

Now, we just have to use the filter before either `SpacesController.New` or `SpacesController.Create` are called. You can do that using this annotation `[ServiceFilter(typeof(AuthenticationFilter))]`. Here's what that looks like for `SpacesController.New`...

First add this at the top...

```cs
using MakersBnB.ActionFilters;
```

Then update the `New` method...

```cs
[ServiceFilter(typeof(AuthenticationFilter))]
public IActionResult New()
{
    return View();
}
```

### Further Exercises

- Secure `SpacesController.Create` with `[ServiceFilter(typeof(AuthenticationFilter))]`
- Write a feature test for when authentication fails (passwords don't match or user cannot be found)

## Demonstration

<!-- OMITTED -->

[Demonstration Video]())


<!-- BEGIN GENERATED SECTION DO NOT EDIT -->

---

**How was this resource?**  
[😫](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F10_auth_bite.md&prefill_Sentiment=😫) [😕](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F10_auth_bite.md&prefill_Sentiment=😕) [😐](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F10_auth_bite.md&prefill_Sentiment=😐) [🙂](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F10_auth_bite.md&prefill_Sentiment=🙂) [😀](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F10_auth_bite.md&prefill_Sentiment=😀)  
Click an emoji to tell us.

<!-- END GENERATED SECTION DO NOT EDIT -->
