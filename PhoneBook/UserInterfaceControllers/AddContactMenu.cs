using Spectre.Console;
using PhoneBook.Data;
using PhoneBook.Models;
using NumberVerifierLibrary;

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

        _newContact.ContactPhone = AnsiConsole.Ask<string>("Contact Phone Without Country Prefix:");
        var countryCode = AnsiConsole.Ask<string>("Country Code (First two letters of your country name -Jordan = JO, United States = US)\nIF YOU ARE HAVING TROUBLE KNOWING YOUR COUNTRY CODE look it up on google:");
        _newContact.ContactPhoneStatus = VerifiyPhoneNumber(countryCode);

        _newContact.ContactEmail = AnsiConsole.Ask<string>("Contact Email:");
        _newContact.ContactEmailStatus = true;


        SaveNewContact();
        IndicateAddSuccess();
    }

    private bool VerifiyPhoneNumber(string countryCode)
    {
        var validatePhone = new ValidatePhoneNumber(countryCode, _newContact.ContactPhone);

        if (!validatePhone.IsPhoneNumberFormatValid()) // if the format isnt valid instantly invalidate the number and set status as unverified
            return false;
            
        // if the format was valid , then check for the api if the number really exists and set the status accordingly
        string verification = validatePhone.IsPhoneNumberValid() ? "[green]Valid[/]" : "[red]Invalid[/]";
        AnsiConsole.MarkupLine($"This number {_newContact.ContactPhone} is {verification}");
        return validatePhone.IsPhoneNumberValid();
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