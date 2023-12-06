# C# Web Applications

In this module, you will learn how to build a small database-backed web application using C# and ASP.NET.

A lot of what you do here is similar to what you have already done in Python, using Flask...

- You'll write unit tests (using NUnit instead of Pytest)
- You'll write feature tests (using Selenium, instead of Playwright)
- The app will have models, views and controllers (MVC)

But there will be one or two things that are quite different!

## Learning Objectives

By the end of this module, you will be able to...
  
- Test drive features of a database-backed ASP.NET web application

## Overview

In this module, you'll re-build MakersBnB in C#. As always, do not judge your progress by how many challenges you complete or how pretty your web app looks.

> Instead, you should judge your progress by self-assessing against the learning objectives above.

## Phase 0

1. [Initial Setup](./bites/01_initial_setup_bite.md)

## Phase 1

1. [Templates](./bites/02_templates_bite.md)
2. [Feature Tests](./bites/03_feature_tests_bite.md)
3. [Controllers](./bites/04_controllers_bite.md)
4. [Models](./bites/05_models_bite.md)
5. [DbContext](./bites/06_dbcontext_bite.md)
6. [Database migrations](./bites/07_database_migrations_bite.md)
7. [Forms](./bites/08_forms_bite.md)
8. [Sign Up](./bites/09_signing_up_bite.md)
9. [Authentication](./bites/10_auth_bite.md)

## Phase 2 - Make it Your Own

In this phase, you are free to continue adding features to your application. You may wish to choose from the list below or, if you prefer, you can come up with your own list.

These exercises are marked with 🌶️ emojis to denote how challenging they are. A single chilli 🌶️ is the most straightforward, and five 🌶️🌶️🌶️🌶️🌶️ would be challenging even for a professional engineer. Pick whichever you prefer.

### Test Drive the 'Unhappy Paths'

At the moment, users can do strange things like sign up without a username or create spaces without a description.

- Make a list of all such cases you can find 🌶️
- Decide what should happen when users do those strange things 🌶️
- Test drive your chosen solutions. 🌶️🌶️

### Improve User Experience
- Add links to `Sign Up` and `Sign In` 🌶️
- Spruce up the front end using CSS 🌶️
- Allow users to sign out 🌶️🌶️🌶️

### Use Fake Data in Your Tests

At the moment the database is filling up with identical users as you run the tests. This is not ideal because it prevents you from making everyone sign up with a unique email address.

- User [Faker](https://blog.elmah.io/easy-generation-of-fake-dummy-data-in-c-with-faker-net/) to generate random email addresses users in your test/s 🌶️🌶️🌶️

### Add Availability and Search
- Space availability: each space should have a set of available dates 🌶️🌶️
- Search: users should be able to search for spaces that are available on a specific date 🌶️🌶️🌶️
- Improved search: users should be able to search for spaces that are available for their whole trip (from x to y) 🌶️🌶️🌶️🌶️
<details>
    <summary>
        Hints: Searching by available dates
    </summary>
    <p>
        When a user performs a search, this typically involves form submission. So you'll need a form and a route that handles form submission. You can then use the user-submitted data to filter <code>spaces</code> and return a specific subset based on their availability.
    </p>
</details>

### Add Bookings
- Booking: users should be able to book a space (the request is automatically approved) 🌶️🌶️🌶️
- Each space should belong to a user 🌶️🌶️🌶️🌶️
- Improved booking: the owner of a space has to approve a booking request 🌶️🌶️🌶️🌶️
<details>
    <summary>
        Hints: Associating spaces with users
    </summary>
    <p>
        A space can only belong to one user, but a user can have many spaces. This tells us that the relationship between users and spaces is <a href="https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-many">one to many</a>. The linked documentation is fairly good but (at the time of writing) fails to mention <a href="https://learn.microsoft.com/en-us/ef/ef6/querying/related-data#eagerly-loading">this</a>.
    </p>
</details>
<details>
    <summary>
        Hints: Making bookings
    </summary>
    <p>
        A single space can be booked, for different dates, by many different users. This tells us that the relationship between <code>spaces</code> and <code>users</code> (in the context of bookings) is <a href="https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many">many to many</a>. The linked documentation is fairly good but (at the time of writing) fails to mention <a href="https://learn.microsoft.com/en-us/ef/ef6/querying/related-data#eagerly-loading">this</a>.
    </p>
</details>


<!-- BEGIN GENERATED SECTION DO NOT EDIT -->

---

**How was this resource?**  
[😫](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=README.md&prefill_Sentiment=😫) [😕](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=README.md&prefill_Sentiment=😕) [😐](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=README.md&prefill_Sentiment=😐) [🙂](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=README.md&prefill_Sentiment=🙂) [😀](https://airtable.com/shrUJ3t7KLMqVRFKR?prefill_Repository=makersacademy%2Fcsharp_web_applications&prefill_File=README.md&prefill_Sentiment=😀)  
Click an emoji to tell us.

<!-- END GENERATED SECTION DO NOT EDIT -->
