# Database Migrations

_**This is a Makers Bite.** Bites are designed to train specific skills or
tools. They contain an intro, a demonstration video, some exercises with an
example solution video, and a challenge without a solution video for you to test
your learning. [Read more about how to use Makers
Bites.](https://github.com/makersacademy/course/blob/main/labels/bites.md)_

Learn to make changes to your database using database migrations

## Introduction

In previous projects you used seed files to set up your database schema, which is a good start. In this project, we'll take things to the next level and use automated "database migrations" using Entity Framework.

Buy why?? Well, migrations us to make iterative changes to the database structure, using a series of different database migration files. You might, for example, initially have a `spaces` table with columns for `id` and `name`. Then, in future, you might want to add a new column for `price` without dropping the table. You might also want to ensure that all your colleagues make the same change to their local database... *AND* that the same change is made to your database in the cloud. You could implement your own solution but Entity Framework provides one for you!

### Creating a Migration File

You can use a terminal command to make Entity Framework create your migration files based on your Models but there are two things to before that's possible.

#### Add A Dependency

Make sure you're in `MakersBnB` then do this

```shell
; dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0
# again, the version here will depend on your version of .NET
```

#### Update Your Model

Next you need to
- Add an `int Id` field to be used as the primary key
- Use the `[Key]` annotation to tell Entity Framework which field is your primary key
- Add a zero argument constructor

```cs
namespace MakersBnB.Models;
using System.ComponentModel.DataAnnotations;

public class Space
{
  // the primary key is Id
  [Key]
  public int Id {get; set;}

  public string? Name {get; set;}
  public string? Description {get; set;}
  public int? Price {get; set;}

  public Space(string name, string description, int price) {
    this.Name = name;
    this.Description = description;
    this.Price = price;
  }

  // a zero arguument constructor is required by Entity Framework
  public Space() {}
}
```

#### Create a Migration

Now everything is in place to create a migration file. Make sure you're in `MakersBnB` and then do this in the terminal...

```shell
; dotnet ef migrations add CreateSpacesTable
# CreateSpacesTable is the name of the migration
# it should be descriptive but it can be anything you want
```

#### Run the Migration

If you look in `/Migrations` you should see some new files but if you connect to the `makersbnb_aspdotnet_dev` database using `psql` or TablePlus you won't see any tables yet. To actually create the Spaces table you need to tell Entity Framework to run the migration. This separation between creating and running migrations gives you the chance to edit or add to what is automatically created - we don't need to do that right now though.

Make sure you're in `MakersBnB` and then do this in the terminal...

```shell
; dotnet ef database update
```

Finally, have another look at the database using `psql` or `TablePlus` and you should see the Spaces table.

#### If You Make a Mistake...

Perhaps you forgot to make some changes to your model/s before creating a migration. To remove the last migration added (but not yet run)...

```shell
; dotnet ef migrations remove
```

You can now make more changes to your model/s then create a new migration in the normal way.

Perhaps you would like to undo a migration that has already been run. If you have run more than one migration, you can 'rollback' to a previous migration. For example, imagine you had created and run two migrations

1. `CreateSpacesTable`
2. `CreateUsersTable`

Now you just realised that you made a mistake with the User model and you would like to undo the `CreateUsersTable` migration. You can 'rollback' to just after `CreateSpacesTable` was run like this...

```shell
; dotnet ef database update CreateSpacesTable
```

### Summary

The basic workflow from this point on would be...

1. Make some changes to a model OR create a new model
2. Use `dotnet ef migrations add <MigratioName>` to generate a migration
3. Use `dotnet ef database update` to run all pending migrations

If you make a mistake

- `dotnet ef mogrations remove` can remove the most recently added migration
- `dotnet ef migrations update <PrevMigration>` can roll the database back to a previous state

## Demonstration

<!-- OMITTED -->

[Demonstration Video]())

## Exercise

- Add an `int Bedroooms` field to the `Space` model then create and run a migration to update the database
- Verify that the change has been applied using `psql` or `TablePlus`

[Next Challenge](08_forms_bite.md)

<!-- BEGIN GENERATED SECTION DO NOT EDIT -->

---

**How was this resource?**  
[😫](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F07_database_migrations_bite.md&prefill_Sentiment=😫) [😕](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F07_database_migrations_bite.md&prefill_Sentiment=😕) [😐](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F07_database_migrations_bite.md&prefill_Sentiment=😐) [🙂](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F07_database_migrations_bite.md&prefill_Sentiment=🙂) [😀](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F07_database_migrations_bite.md&prefill_Sentiment=😀)  
Click an emoji to tell us.

<!-- END GENERATED SECTION DO NOT EDIT -->
