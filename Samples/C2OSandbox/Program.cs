using System;
using Connect2Ocbc;
using System.IO;

namespace C2OSandbox
{
    public class Program
    {
        private static string token = string.Empty;

        public static void Main(string[] args)
        {
            try
            {
                using (var fileStream = new FileStream("Token.txt", FileMode.Open))
                {
                    using (var streamReader = new StreamReader(fileStream))
                    {
                        token = streamReader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            while (true)
            {
                Console.WriteLine("Welcome to Connect2Ocbc Sandbox. Please Select:");
                Console.WriteLine("1. Branch Locator.");
                Console.WriteLine("2. Credit Card Advisor.");
                Console.WriteLine("3. ATM Locator.");
                Console.WriteLine("4. Forex Rates.");
                try
                {
                    var resp = Console.ReadLine();
                    var number = byte.Parse(resp);
                    switch (number)
                    {
                        case 1:
                            RetrieveAllBranches();
                            break;
                        case 2:
                            SuggestCreditCard();
                            break;
                        case 3:
                            RetrieveAllAtms();
                            break;
                        case 4:
                            RetrieveForexRates();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }

                Console.ReadKey();
                Console.WriteLine();
            }
        }

        private static void RetrieveAllBranches()
        {
            var branches = new Branches(token);
            var branchlist = branches.GetAllBranches();
            // For async use this:
            // var branchlist = branches.GetAllBranchesAsync();
            Console.WriteLine("Branch Locations.");
            var x = 0;
            foreach (var branch in branchlist)
            {
                Console.WriteLine();
                if (x != 0 && x % 20 == 0)
                {
                    Console.WriteLine("Type any key to retrieve another 20");
                    Console.ReadLine();
                }
                x++;
                Console.WriteLine("{0}. {1}", x, branch.Landmark);
                Console.WriteLine("Address: {0}, {1}", branch.Address, branch.PostalCode);
                Console.WriteLine("Coordinate: {0}, {1}", branch.Latitude, branch.Longitude);
            }                
        }

        private static void RetrieveAllAtms()
        {
            var atms = new Atms(token);
            var atmlist = atms.GetAllAtms();
            // For async use this:
            // var atmlist = atms.GetAllAtmsAsync();
            Console.WriteLine("ATM Locations.");
            var x = 0;
            foreach (var atm in atmlist)
            {
                Console.WriteLine();
                if (x != 0 && x % 20 == 0)
                {
                    Console.WriteLine("Type any key to retrieve another 20");
                    Console.ReadLine();
                }
                x++;
                Console.WriteLine("{0}. {1}", x, atm.Landmark);
                Console.WriteLine("Address: {0}, {1}", atm.Address, atm.PostalCode);
                Console.WriteLine("Coordinate: {0}, {1}", atm.Latitude, atm.Longitude);
                Console.WriteLine("Note: {0}", atm.Note);
                Console.WriteLine("Note Details: {0}", atm.NoteDetails);
            }
        }

        private static void SuggestCreditCard()
        {
            Console.WriteLine("Provide a keyword:");
            var keyword = Console.ReadLine();
            var creditcards = new CreditCards(token);
            var cclist = creditcards.GetCreditCardSuggestion(keyword);
            // For async use this:
            // var cclist = creditcards.GetCreditCardSuggestionAsync(keyword);
            Console.WriteLine("Suggested Credit Cards.");
            var x = 0;
            foreach (var cc in cclist)
            {
                Console.WriteLine();
                x++;
                Console.WriteLine("{0}", cc.Name);
                Console.WriteLine("{0}", cc.TagLine);
                Console.WriteLine("More Info: {0}", cc.ProductURL);
                Console.WriteLine("CC Look: {0}", cc.ImageURL);
                Console.WriteLine("{0}", cc.Keywords);
            }

        }

        private static void RetrieveForexRates()
        {
            var forex = new Forex(token);
            var rates = forex.GetAllRates();
            // For async use this:
            // var rates = forex.GetAllRatesAsync();
            Console.WriteLine("Forex Rates.");
            Console.WriteLine();
            foreach (var rate in rates)
            {
                Console.WriteLine("Bank Buy: {0}, Bank Sell: {1}, FromTo: {2}{3}, Unit: {4}", rate.BankBuyingRateTT, rate.BankSellingRate, rate.FromCurrency, rate.ToCurrency, rate.Unit);
            }
        }
    }
}
