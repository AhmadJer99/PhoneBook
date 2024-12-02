﻿using Spectre.Console;

namespace EmailVerifierLibrary;

public class ValidateEmailAddress
{
    private string? _emailAddress;
    private ValidatedEmailAddress? _emailDetails;
    public ValidateEmailAddress(string emailAddress)
    {
        _emailAddress =  emailAddress;
        var task = LoadPhoneDetails();
        task.Wait();
    }

    public bool IsEmailAddressFormatValid()
    {
        return _emailDetails.IsFormatValid;
    }
    public double GetEmailAddressValidConfidenceScore()
    {
        return _emailDetails.Confidence;
    }
    public bool EmailCanRecieveMail()
    {
        return _emailDetails.MxCheck;
    }
    public string CheckEmailPossibleTypoFix()
    {
        if (!string.IsNullOrWhiteSpace(_emailDetails.CorrectedEmail))
        {
            AnsiConsole.Markup($"[yellow]Did you mean -{_emailDetails.CorrectedEmail}? [/]");

            while(true)
            {
                var userChoice = AnsiConsole.Ask<string>("(Y/N)");

                if (userChoice.ToLower() == "y")
                {
                    _emailAddress = _emailDetails.CorrectedEmail;
                    var task = LoadPhoneDetails();
                    task.Wait();
                    return _emailDetails.CorrectedEmail;
                }
                if (userChoice.ToLower() == "n")
                    return "";
                AnsiConsole.MarkupLine("[red]Invalid Choice![/]");
            }
        }
        return "";
    }

    private async Task LoadPhoneDetails()
    {
        HttpRequestCreator httpRequestCreator = new();
        var client = httpRequestCreator.CreateHttpClient();
        var apiKey = httpRequestCreator.LoadApiKey();
        var requestUri = httpRequestCreator.LoadHttpValidationConnectionString();
        var fullUri = requestUri + apiKey + "&email=" + _emailAddress;

        _emailDetails = await ApiRequest.ProcessRequestAsync<ValidatedEmailAddress>(client, fullUri);
    }
}