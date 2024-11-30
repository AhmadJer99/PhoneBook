﻿using PhoneBook.Data;
using PhoneBook.UI;

MainMenu mainMenu = new MainMenu();
while (true)
{
    Console.Clear();
    var choice = mainMenu.ShowMainMenu();
    if (choice == 4)

    { break; }

    using var db = new PhoneBookContext();
    switch (choice)
    {
        case 1:
            break;
        case 2:
            AddContactMenu addContactMenu = new(db);
            addContactMenu.PromptNewContact();
            break;
        case 3:
            break;
    }
    db.SaveChanges();
}