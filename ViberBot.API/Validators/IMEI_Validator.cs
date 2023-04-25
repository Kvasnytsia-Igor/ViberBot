using System.Text.RegularExpressions;

namespace ViberBot.API.Validators;

public class InputValidator
{
    private readonly Regex regexIMEI = new(@"^\d{15}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private readonly Regex regexRequest = new(@"walks_list/\d{15}/\d{1,10}",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);
    public bool ValidateIMEI(string IMEI)
    {
        return regexIMEI.IsMatch(IMEI);
    }
    public  bool ValidateRequest(string request)
    {
        return regexRequest.IsMatch(request);
    }
}
