using Spectre.Console;
using PhoneBook.Data;
using PhoneBook.Models;

namespace PhoneBook.UserInterfaceControllers;

internal class AddContactMenu
{
    private Contact _newContact;
    private PhoneBookContext PhoneBookDb { get; set; }

    public AddContactMenu(PhoneBookContext phoneBookDb)
    {
        PhoneBookDb = phoneBookDb;
        _newContact = new Contact();
    }

    public void PromptNewContact()
    {
        AnsiConsole.MarkupLine("[bold green]New Contact\n[/]");

        _newContact.ContactName = AnsiConsole.Ask<string>("Contact Name:");
        _newContact.ContactTitle = AnsiConsole.Ask<string>("Contact Title E.g.(Family,Work,..):");

        _newContact.ContactPhone = AnsiConsole.Ask<string>("Contact Phone:"); // set the new contact number status based on Number verifier 
        _newContact.ContactPhoneStatus = true;

        _newContact.ContactEmail = AnsiConsole.Ask<string>("Contact Email:"); // set the new contact email status based on email verifier
        _newContact.ContactEmailStatus = true;

        SaveNewContact();
        IndicateAddSuccess();
    }

    private void SaveNewContact()
    {
        PhoneBookDb.Add(_newContact);
        PhoneBookDb.SaveChanges();
    }

    private void IndicateAddSuccess()
    {
        AnsiConsole.MarkupLine("\n[green]Contact Added Successfully!\n[/](Press Any Key To Continue)");
        Console.ReadKey();
    }
}