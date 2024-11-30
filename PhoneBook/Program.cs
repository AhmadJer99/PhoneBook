using PhoneBook.Data;
using PhoneBook.Models;
using PhoneBook.UI;
using System.Reflection.Metadata;

MainMenu mainMenu = new MainMenu();
while (true)
{
    var choice = mainMenu.ShowMainMenu();
    if (choice == 4)
    { break; }

    using var db = new PhoneBookContext();

        Console.Write("Enter a name for a new contact: ");
    var name = Console.ReadLine();
    var contact = new Contact { ContactName = name };
    db.Contacts.Add(contact);
    db.SaveChanges();

    switch (choice)
    {
        case 1:
            break;
        case 2:
            break;
        case 3:
            break;
    }
}