using ConsoleCkeck.Checks;
using System.Globalization;

Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
string[] IMEIs = new string[] { "359339077003915", "359339077004361", "359339077004344" };
Check_TrakcService.Check_FindWalks(IMEIs[0]);




