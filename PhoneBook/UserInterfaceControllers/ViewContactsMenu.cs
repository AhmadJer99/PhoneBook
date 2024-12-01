using PhoneBook.Data;
using PhoneBook.Models;
using Spectre.Console;

namespace PhoneBook.UserInterfaceControllers;

internal class ViewContactsMenu
{
    private enum _ContactOperations
    {
        Edit,
        Delete,
        Back
    }

    private PhoneBookContext PhoneBookDb { get; set; }

    public ViewContactsMenu(PhoneBookContext phoneBookDb)
    {
        PhoneBookDb = phoneBookDb;
    }

    public void ListAllContacts()
    {
        AnsiConsole.MarkupLine("[bold green]Contacts\n[/]");

        var contacts = PhoneBookDb.Contacts
            .OrderBy(x => x.ContactName).ToList();

        var selectedContact = AnsiConsole.Prompt(
            new SelectionPrompt<Contact>()
            .Title("[bold green]Select a contact to view its details\n[/]")
            .UseConverter(c => $"{c.ContactName}")
            .AddChoices(contacts));

        ViewContactDetails(selectedContact);

        IndicateSuccess();
    }

    private void ViewContactDetails(Contact selectedContact)
    {
        string phoneStatus = selectedContact.ContactPhoneStatus ? "[green]Verified[/]" : "[red]Unverified[/]";
        string emailStatus = selectedContact.ContactEmailStatus ? "[green]Verified[/]" : "[red]Unverified[/]";
        // list all the details about this contact 
        AnsiConsole.MarkupLine($"[bold teal]Name: [/]{selectedContact.ContactName}");
        AnsiConsole.MarkupLine($"[bold teal]Contact info:[/]");
        AnsiConsole.MarkupLine($"\t[bold teal]Phone: [/]{selectedContact.ContactPhone} {phoneStatus}");

        if(!string.IsNullOrEmpty(selectedContact.ContactEmail))
            AnsiConsole.MarkupLine($"\t[bold teal]Email: [/]{selectedContact.ContactEmail} {emailStatus}");

        AnsiConsole.MarkupLine($"[bold teal]About {selectedContact.ContactName}: [/]{selectedContact.ContactTitle}");
    }

    private void IndicateSuccess()
    {
        AnsiConsole.MarkupLine("\n[green]Operation executed succesfully![/]\n(Press Any Key To Continue)");
        Console.ReadKey();
    }
}
