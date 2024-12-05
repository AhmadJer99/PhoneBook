# PhoneBook
 ![contact-us](https://github.com/user-attachments/assets/adc5ea58-09c7-4eb5-a74c-077842bd57a5)
### A very simple Phone Book console application using the most popular ORM Entity Framework (EF)

# Requirments
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
- [What is Code-First apporach?](https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx)
- [Setting up my connection string in the App.Config](https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings?tabs=vs)
# Build Instructions
- Change the connection strings to your specified Sql server instance , and desired database name in the App.Config Xml file.
- Make sure to use the command Add-Migration <YOUR MIGRATION NAME> in the PMC.
- Run Update-Database in PMC.
- Make sure to provide Api Keys for the Email Verifier and phone verifier in their respective App.Config files.
- You can get Api keys for those services through these
   - [NumVerifiy](https://numverify.com/) You can sign up for free and get a free Api key and have 100 requests per month allowance
   - [EmailVerifiy](https://mailboxlayer.com/) You can sign up for free and get a free Api key and have 100 requests per month allowance
 ### Note: I left my Api keys in the app configs so you can use it to test the app, but theres a limit on its usage because they are free keys.
