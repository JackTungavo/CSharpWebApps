# Templates

_**This is a Makers Bite.** Bites are designed to train specific skills or
tools. They contain an intro, a demonstration video, some exercises with an
example solution video, and a challenge without a solution video for you to test
your learning. [Read more about how to use Makers
Bites.](https://github.com/makersacademy/course/blob/main/labels/bites.md)_

/** Fill this out **/

Learn to edit existing templates in an ASP.NET project.

## Introduction

In the previous bite, you were guided to create an ASP.NET project using `dotnet`. The resulting application already has Index and Privacy templates but the content is not quite what we need for MakersBnB. In this bite, you'll learn how to edit those templates to make the content more relevant.

### Razor

The ASP.NET template app uses _Razor syntax_ in the Views - the Python equivalent used earlier in the course is Jinja. Both allow you to create dynamic templates (Views) by combining HTML and C# (in the case of Razor) or Python (in the case of Jinja). I'll not go into a _lot_ of detail here but I will cover some of the basics.

#### Implicit Expressions

Implicit expressions are suitable for very simple use cases. Here's an example...

```html
<p>Today is @DateTime.Now</p>
```

Generates...

```
Today is 04/12/2023 15:55:48
```

So what's going on? The `@` indicates that we're going to use some C#. `DateTime` is a C# class and `.Now` is a property.

#### Explicit Expressions

Explicit expressions can handle slightly more complex C#. As a rule of thumb, if the C# you need includes one or more spaces, implicit expressions will not work. Here's an example...

```html
<p>This time last week was: @(DateTime.Now - TimeSpan.FromDays(7))</p>
```

As you can see, it's a lot like an implicit expression but I've wrapped the C# in some parentheses. This code generates...

```
This time last week was: 27/11/2023 15:55:48
```

#### Code Blocks

Occasionally you'll need to add a bit more C# to your template - some logic, or a loop, perhaps. In that case, code blocks are the tool to reach for. These look a lot like explicit expressions except we use curly braces instead of parentheses. Here's an example...

```cs
@{
    // declare the message variable
    string message;

    if(DateTime.IsLeapYear(DateTime.Now.Year)) {
        // if this year is a leap year
        message = "It's a leap year";
    } else {
        // if this year is not a leap year
        message = "It's not a leap year";
    }
}
```

<br>
  <details>
    <summary>How would you then show the message?</summary>
    <br>
    <p>
      With an implicit expression...
      <br>
      <br>
      <code>&ltp&gt@message&lt/p&gt</code>
    </p>
  </details>
<br>

Here's another example of a code block. This time I iterate through a `string[]` of names and render each one as an `li`.

```cs
<ol>
@{
    string[] names = new string[4] {"tina", "mandip", "sulemon", "jordi"};
    foreach(string name in names) {
        <li>@name</li>
    }
}
</ol>
```

In a database-backed ASP.NET application, you would probably be iterating through a list of stuff that was passed into the template from a controller. We'll see how that works later.

## Demonstration

/**

  Add a video demonstration covering the same material as the intro, as close as
  you can get it. Assume some learners will engage only with the intro text or
  the demo video.

**/

[Demonstration Video]()

Have a look in the `Views` directory - you should find `Index.cshtml` and `Privacy.cshtml`.

## Exercise

In `Index.cshtml`, add the following...

1. A message (`h2`) that welcomes people to MakersBnB
2. A list of reviews (you can use a hard coded list of strings)


## Exercise 2

Go to [Holiday Insights](https://www.holidayinsights.com/) then click on `Daily Holidays` to find out what you can celebrate today - there is something for every day of the year!

Now add some logic to your `Index` page so that a festive message is displayed for that day. For example, today is December 4th, which is "Wear Brown Shoes Day"! So one would expect to see...

```
Happy Wear Brown Shoes Day!
```


[Next Challenge](03_feature_tests_bite.md)

<!-- BEGIN GENERATED SECTION DO NOT EDIT -->

---

**How was this resource?**  
[😫](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F02_templates_bite.md&prefill_Sentiment=😫) [😕](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F02_templates_bite.md&prefill_Sentiment=😕) [😐](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F02_templates_bite.md&prefill_Sentiment=😐) [🙂](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F02_templates_bite.md&prefill_Sentiment=🙂) [😀](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F02_templates_bite.md&prefill_Sentiment=😀)  
Click an emoji to tell us.

<!-- END GENERATED SECTION DO NOT EDIT -->
