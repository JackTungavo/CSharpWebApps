# Repositories

_**This is a Makers Bite.** Bites are designed to train specific skills or
tools. They contain an intro, a demonstration video, some exercises with an
example solution video, and a challenge without a solution video for you to test
your learning. [Read more about how to use Makers
Bites.](https://github.com/makersacademy/course/blob/main/labels/bites.md)_

<!-- OMITTED -->

Learn to integrate your ASP.NET application with a database

## Introduction

In previous bites, you learned about...

- Setting up an ASP.NET project
- Templating with Razor
- Feature testing with Playwright
- Handling requests
- Models

Now, you have an app that _could_ do quite a lot but there are some crucial things missing...

- You don't have a database
- You couldn't query the database if you had one!

### Create a Database

First, let's create a PostgreSQL database using the command line

```shell
; createdb makersbnb_aspdotnet_dev
# if this doesn't work, make sure PostgreSQL is running and try again
```

### Dependencies

`cd` into `MakersBnB` then do this on the command line to install Entity Framework (a tool used by ASP.NET to manage database interactions).

```sh
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.0
#  the version chosen here needs to be compatible with your version of .NET
#  if you're using something higher than .NET 7.0, you might be able to change
#  the version here for something more recent
```

### DbContext

Next, you need a way of querying the database.

To achieve this, we'll create a `MakersBnBDbContext` class that will handle all
interactions with a database. It's comparable to the Repository classes you used in Python - the main difference is that a single DbContext class will handle all database interactions for all models. You won't have one DbContext per model.

First, create a new file in `Models` called `MakersBnBDbContext.cs` and add the following...

```cs
namespace MakersBnB.Models;
using Microsoft.EntityFrameworkCore;

public class MakersBnBDbContext : DbContext
{
    internal DbSet<Space>? Spaces { get; set; }

    internal string? DbPath { get; }

    internal string dbName = "makersbnb_aspdotnet_dev";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
          @"Host=localhost;Username=postgres;Password=1234;Database=" + this.dbName
        );
}
```

And that's it for now. Unfortunately, there's no simple way of testing whether this has worked until we have the final piece in place - see the next bite!

## Demonstration

<!-- OMITTED -->

[Demonstration Video]())


[Next Challenge](07_database_migrations_bite.md)

<!-- BEGIN GENERATED SECTION DO NOT EDIT -->

---

**How was this resource?**  
[😫](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F06_dbcontext_bite.md&prefill_Sentiment=😫) [😕](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F06_dbcontext_bite.md&prefill_Sentiment=😕) [😐](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F06_dbcontext_bite.md&prefill_Sentiment=😐) [🙂](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F06_dbcontext_bite.md&prefill_Sentiment=🙂) [😀](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F06_dbcontext_bite.md&prefill_Sentiment=😀)  
Click an emoji to tell us.

<!-- END GENERATED SECTION DO NOT EDIT -->
