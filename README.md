# PhoneBook
 ![contact-us](https://github.com/user-attachments/assets/adc5ea58-09c7-4eb5-a74c-077842bd57a5)
### A very simple Phone Book console application using the most popular ORM Entity Framework (EF)

# Requirements
- Application should record contacts with their phone numbers.
- Users should be able to Add, Delete, Update and Read from a database, using the console.
- Use Entity Framework, raw SQL isn't allowed.
- Code should contain a base Contact class with AT LEAST {Id INT, Name STRING, Email STRING and Phone Number(STRING)}.
- Code should validate e-mails and phone numbers and let the user know what formats are expected.
- Code should be done using Code-First Approach, which means EF will create the database schema.
- Code should use SQL Server, not SQLite
  
# Resources
- [EF introduction using MS docs for EF.](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli)
- [Code sample using EF core on Github](https://github.com/entityframeworktutorial/EF6-Code-First-Demo)
- [What is Code-First approach?](https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx)
- [Setting up my connection string in the App.Config](https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings?tabs=vs)
- [Async Guidance By David Fowler](https://github.com/davidfowl/AspNetCoreDiagnosticScenarios/blob/master/AsyncGuidance.md)
  
# Build Instructions
- Change the connection strings to your specified SQL server instance , and desired database name in the App.Config Xml file.
- Make sure to use the command Add-Migration <YOUR MIGRATION NAME> in the PMC.
- Run Update-Database in PMC.
- Make sure to provide Api Keys for the Email Verifier and phone verifier in their respective App.Config files.
- You can get Api keys for those services through these
   - [NumVerify](https://numverify.com/) You can sign up for free and get a free Api key and have 100 requests per-month allowance
   - [EmailVerify](https://mailboxlayer.com/) You can sign up for free and get a free Api key and have 100 requests per-month allowance
 ### Note: I left my Api keys in the app configs so you can use it to test the app, but there's a limit on its usage because they are free keys.

# Features
- Used [Spectre.Console](https://spectreconsole.net/) Package to add colors and select menus with arrow keys.
- ![image](https://github.com/user-attachments/assets/2f976e3e-fd61-4463-97a6-a3b809752142)
- Provides a user friendly interface to view all the contacts available in the phonebook.
- ![image](https://github.com/user-attachments/assets/215af96d-5061-47ea-9d5c-ed9f7dda6e9e)
- User can then select a contact to see its details in a well formatted way.
- ![image](https://github.com/user-attachments/assets/65c12480-166d-405e-b3f3-3d142da2acc3)
- User can chose to edit/delete the contact
- If the user chose to edit the contact he can edit any field he wants.
  - ![image](https://github.com/user-attachments/assets/304353dd-c8ab-4562-8695-f44d004a1c03)
  - ![image](https://github.com/user-attachments/assets/8d7a9205-ba40-4f5c-947c-ffab9b4d69dd)
  - After the user is done editing the contact he can choose to cancel any changes or save changes,and will be shown the edited contact details.
  - ![image](https://github.com/user-attachments/assets/c45f0e7f-2fdf-4e13-be81-2096bbe15ce5)
- If the user chose to delete te contact.
   - User will be prompted with a confirmation if he really wants to delete that contact permanently.
   - ![image](https://github.com/user-attachments/assets/b53dc505-62c1-4264-a41c-71609f2ca35f)

# Lessons Learned
- I learnt how to implement async methods correctly.
- I learnt how to use Code-First approach with EF core creating the schema for me.
- I learnt how to do basic CRUD operations with EF.

# Future Improvement 🚀
- I think I still need to be more consistent with my code regarding how i define variables and how I do external projects.
- I need some work applying more design patterns more efficiently without killing the code readability.
- I need to untie my code even better and apply better SoC througout my project.
