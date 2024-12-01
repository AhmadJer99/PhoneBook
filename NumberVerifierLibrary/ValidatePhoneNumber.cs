namespace NumberVerifierLibrary;

public class ValidatePhoneNumber
{
    private string? _countryCode;
    private string? _phoneNumber;
    private ValidatedPhoneNumber? _numberDetails;
    public ValidatePhoneNumber(string countryCode, string phoneNumber)
    {
        _countryCode = "&country_code=" + countryCode;
        _phoneNumber = "&number=" + phoneNumber;
    }

    public bool IsPhoneNumberValid()
    {
        var task = LoadPhoneDetails();
        task.Wait();

        return _numberDetails.IsNumberValid;
    }
    private async Task LoadPhoneDetails()
    {
        HttpRequestCreator httpRequestCreator = new();
        var client = httpRequestCreator.CreateHttpClient();
        var apiKey = httpRequestCreator.LoadApiKey();
        var requestUri = httpRequestCreator.LoadHttpValidationConnectionString();
        var fullUri = requestUri + apiKey + _phoneNumber + _countryCode;

        _numberDetails = await ApiRequest.ProcessRequestAsync<ValidatedPhoneNumber>(client, fullUri);
    }
}