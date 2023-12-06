# Sign Up

This section is a bit different to the others - there's a lot less to read through and you'll spend more time programming. Working on it will bring together everything we've covered so far.

- Feature testing
- Controllers
- Templates
- Models
- Database migrations
- DbContext
- Forms

## Introduction

In this section, you will test drive a full stack feature - user sign up. I'll describe the requirements and share some guidance first though.

## Exercise

### Requirements

- When a user navigates to "Users/New", they should see a sign up form
- The form should contain fields for username, email and password
- When they submit the form, they should be redirected to "/Spaces" (we'll change this later)
- And a new user record should be saved in the database

### Guidance


- _Plan_ the sign up form
- Then write a feature test
> From now on, run your test frequently and pay attention to the output
- [`GetByLabel`](https://playwright.dev/dotnet/docs/locators#locate-by-label) will be useful there
- Create the `UsersController`
- Add a method called `New`
- Create the form - it should live in `Views/Users`
- Form submission should make a `POST "/Users"` request
> !! The order of these next three steps is important
- Create a User model - use the Space model as inspiration
- Add `internal DbSet<User>? Users { get; set; }` to `MakersBnBDbContext`
- Create and run a migration to update the database
> !! Use `psql` or TablePlus to check that the Users table was created
- Add a method called `Create` to `UsersController`
- Use `MakersBnBDbContext` to save a new user in `UsersController.Create`
- Finally, redirect to "/Spaces"

[If you get really lost, have a look at the files in here](../examples/sign_up/)

> Once you're done, the test should pass and you should see a new user in the database (using `psql` or TablePlus)

## Demonstration

<!-- OMITTED -->

[Demonstration Video]())


[Next Challenge](10_auth_bite.md)

<!-- BEGIN GENERATED SECTION DO NOT EDIT -->

---

**How was this resource?**  
[😫](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F09_signing_up_bite.md&prefill_Sentiment=😫) [😕](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F09_signing_up_bite.md&prefill_Sentiment=😕) [😐](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F09_signing_up_bite.md&prefill_Sentiment=😐) [🙂](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F09_signing_up_bite.md&prefill_Sentiment=🙂) [😀](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=bites%2F09_signing_up_bite.md&prefill_Sentiment=😀)  
Click an emoji to tell us.

<!-- END GENERATED SECTION DO NOT EDIT -->
