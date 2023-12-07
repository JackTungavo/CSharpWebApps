# Feature Tests

_**This is a Makers Bite.** Bites are designed to train specific skills or
tools. They contain an intro, a demonstration video, some exercises with an
example solution video, and a challenge without a solution video for you to test
your learning. [Read more about how to use Makers
Bites.](https://github.com/makersacademy/course/blob/main/labels/bites.md)_

<!-- OMITTED -->

Learn to write feature tests in C# using [Playwright](https://playwright.dev/dotnet/docs/writing-tests).

## Introduction

There are many tools that could be used to write feature tests in C#, but you're already somewhat familiar with Playwright... so let's go with that!

In this bite, you'll be guided to write a couple of feature tests then challenged to write two of your own.

### Setup

First, `cd` into `MakersBnB.Tests` and do `dotnet add package Microsoft.Playwright.NUnit` to add the Playwright dependency. Then do `dotnet build` to install it.

Next, you'll need to install PowerShell because Playwright depends on it. If you're familiar with PowerShell from having done some programming on a Windows PC, this will feel odd. If you've never heard of PowerShell before, it won't. Either way, just roll with it! PowerShell isn't something you'll explicitly use beyond this setup bit.

```sh
brew install powershell/tap/powershell
```

Then you can use PowerShell to install browsers for PlayWright (replace `netX`) with the actual folder name - it depends on which version of .NET you're using.

```sh
pwsh bin/Debug/netX/playwright.ps1 install
```

I'm using .NET 7.0 so for me the actual command is

```sh
pwsh bin/Debug/net7.0/playwright.ps1 install
```

Now, you're almost there. Let's just add in a simple test for you to run and verify that everything works. When you created your test project (`MakersBnB.Tests`) it would have come with a file called `UnitTest1.cs`. Find that and replace the contents with this

```cs
namespace MakersBnB.Tests;

using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

public class Tests : PageTest
{
    // the following method is a test
    [Test]
    public void IndexpageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    {
        // go to the MakersBnB Index page
        Page.GotoAsync("http://localhost:5106");

        // expect the page title to contain "Index Page - MakersBnB"
        Expect(Page).ToHaveTitleAsync(new Regex("Index Page - MakersBnB"));
    }
}
```

This test should pass, when...

1. You start the server by doing `dotnet run` in `MakersBnB`
2. In new terminal tab, do `dotnet test` in `MakersBnB.Tests`

**Now we're ready to write some real tests!**

### A New Test

Add this to your existing test file.

```cs
[Test]
 public void HomePageIncludesWelcomeMessage() {
     Page.GotoAsync("http://localhost:5106");

     Expect(Page.GetByText("Welcome to MakersBnB!")).ToBeVisibleAsync();
 }
```

Now start your server and then run your tests by doing `dotnet test`

If the test fails, change it so that it looks for whatever welcome message you implemented in the previous bite.

In future, you'll need to write much more complex tests but you've already done just that using Playwright in Python so I am sure you'll figure out how to do it in C# as well, with some help from [the docs](https://playwright.dev/dotnet/docs/writing-tests).

The main bits you'll need are

- [Locators](https://playwright.dev/dotnet/docs/locators)
- [Assertions](https://playwright.dev/dotnet/docs/test-assertions)

## Demonstration

<!-- OMITTED -->

[Demonstration Video]())

## Exercise 1

Add another test to ensure that the reviews are on your Home page

## Exercise 2

Test-drive some content for the Privacy page

- Start by writing a test and expecting there to be some specific text on the Privacy page (you can decide what that text should be)
- Run the test and see it fail
- Add content to the privacy page to make the test pass


[Next Challenge](04_controllers_bite.md)

<!-- BEGIN GENERATED SECTION DO NOT EDIT -->

---

**How was this resource?**  
[😫](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F03_feature_tests_bite.md&prefill_Sentiment=😫) [😕](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F03_feature_tests_bite.md&prefill_Sentiment=😕) [😐](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F03_feature_tests_bite.md&prefill_Sentiment=😐) [🙂](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F03_feature_tests_bite.md&prefill_Sentiment=🙂) [😀](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F03_feature_tests_bite.md&prefill_Sentiment=😀)  
Click an emoji to tell us.

<!-- END GENERATED SECTION DO NOT EDIT -->
