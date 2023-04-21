namespace ViberBot.API.Validators
{
    public class IMEI_Validator
    {
        public static bool ValidateIMEI(string IMEI)
        {
            if (IMEI.Length != 15)
            {
                return false;
            }
            foreach (char c in IMEI)
            {
                if(!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
