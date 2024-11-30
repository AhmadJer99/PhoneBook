using Spectre.Console;

namespace PhoneBook.UI;

internal class MainMenu
{
    public int ShowMainMenu()
    {
        var userChoice = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("[bold green]PhoneBook[/]")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
        .AddChoices([
            "1. View Contacts", // after viewing contact , i would let the user filter them later.
            "2. Add Contact",
            "3. Search Contact",
            "4. Exit",
        ]));

        return GetNumericChoice(userChoice);
    }

    private int GetNumericChoice(string userChoice) => userChoice switch
    {
        "1. View Contacts" => 1,
        "2. Add Contact" => 2,
        "3. Search Contact" => 3,
        "4. Exit" => 4,
        _ => throw new InvalidOperationException("Invalid choice selected.")
    };
}