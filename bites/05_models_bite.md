# Models

_**This is a Makers Bite.** Bites are designed to train specific skills or
tools. They contain an intro, a demonstration video, some exercises with an
example solution video, and a challenge without a solution video for you to test
your learning. [Read more about how to use Makers
Bites.](https://github.com/makersacademy/course/blob/main/labels/bites.md)_

Learn to define database-backed Models

## Introduction

Eventually, when the MakersBnB application reads data from the `spaces` table, it will create an instance of `Space` for each record. Let's implement the `Space` Model now.

Create a new C# class file in `Models` called `Space.cs` then add the following code (leaving out the comments if you prefer).

```cs
namespace MakersBnB.Models;
using System.ComponentModel.DataAnnotations;

public class Space
{
  // some fields
  // the ? indicates that a field can be null / blank (is nullable)
  // {get; set;} tells the compiler to create getter and setter methods
  public string? Name {get; set;}
  public string? Description {get; set;}
  public int? Price {get; set;}

  // the constructor
  public Space(string name, string description, int price) {
    this.Name = name;
    this.Description = description;
    this.Price = price;
  }
}
```



## Demonstration

<!-- OMITTED -->

[Demonstration Video]())

## Exercise

- Create an instance of Space in the `Index` method of the `Spaces` controller and pass it to the `Spaces/Index` view using `ViewBag`
- Edit the `Spaces/Index` view to use the instance of Space you just passed in
- The page should show the `Name`, `Description` and `Price` of the space


[Next Challenge](06_dbcontext_bite.md)

<!-- BEGIN GENERATED SECTION DO NOT EDIT -->

---

**How was this resource?**  
[😫](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F05_models_bite.md&prefill_Sentiment=😫) [😕](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F05_models_bite.md&prefill_Sentiment=😕) [😐](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F05_models_bite.md&prefill_Sentiment=😐) [🙂](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F05_models_bite.md&prefill_Sentiment=🙂) [😀](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F05_models_bite.md&prefill_Sentiment=😀)  
Click an emoji to tell us.

<!-- END GENERATED SECTION DO NOT EDIT -->
