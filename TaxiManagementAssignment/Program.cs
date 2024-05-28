using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using TaxiManagementAssignment;

namespace TaxiManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            RankManager rm = new RankManager();
            TaxiManager txm = new TaxiManager();
            TaxiManagementAssignment.TransactionManager trm = new TaxiManagementAssignment.TransactionManager();
            UserUI ui = new UserUI(rm, txm, trm);

            string GetStringFromUser(string prompt)
            {
                Console.Write(prompt);
                return Console.ReadLine();
            }

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Taxi management system v0.1 alpha");
                Console.WriteLine("Enter 1 to add a taxi to the rank");
                Console.WriteLine("Enter 2 to remove taxi from the rank");
                Console.WriteLine("Enter 3 to drop fare from a taxi");
                Console.WriteLine("Enter 4 to view your financial report");
                Console.WriteLine("Enter 5 to view transaction log");
                Console.WriteLine("Enter 6 to view taxi locations");
                Console.WriteLine("Enter e to exit from the program");
                string option = GetStringFromUser("Enter an option: ");
                int rankId;
                int taxiNum;
                switch (option)
                {
                    case "1":
                        if (Int32.TryParse(GetStringFromUser("Enter taxi number: "), out taxiNum) &&
                            Int32.TryParse(GetStringFromUser("Enter rank number: "), out rankId))
                        {
                            Console.WriteLine(ui.TaxiJoinsRank(taxiNum, rankId)[0]);
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid numbers for taxi and rank.");
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                            continue;
                        }
                    case "2":
                        double agreedprice;

                        if ((Int32.TryParse(GetStringFromUser("Enter rank number: "), out rankId) &&
                            Double.TryParse(GetStringFromUser("Enter agreed price: "), out agreedprice)))
                        {
                            Console.WriteLine(ui.TaxiLeavesRank(rankId, GetStringFromUser("Enter destination: "), agreedprice)[0]);
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                            continue;
                        }
                        else {
                            Console.WriteLine("Please enter valid numbers for rank and price");
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                            continue;
                        }
                    case "3":
                        bool pricepaid;
                        if ((Int32.TryParse(GetStringFromUser("Enter the taxi number: "), out taxiNum)) &&
                            (bool.TryParse(GetStringFromUser("Have the customer paid the bill? true/false: "), out pricepaid)))
                        {
                            Console.WriteLine(ui.TaxiDropsFare(taxiNum, pricepaid)[0]);
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                            continue;
                        }
                        else {
                            Console.WriteLine("Please enter valid value");
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                            continue;
                        }
                    case "4":
                        Console.Clear();
                        foreach (var results in ui.ViewFinancialReport()) {
                            Console.WriteLine(results);
                        }  
                        Console.WriteLine("Enter any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    case "5":
                        Console.Clear();
                        foreach (var results in ui.ViewTransactionLog()) {
                            Console.WriteLine(results);
                        } 
                        Console.WriteLine("Enter any key to continue....");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    case "6":
                        Console.Clear();
                        foreach (var results in ui.ViewTaxiLocations()) {
                            Console.WriteLine(results);
                        }
                        Console.WriteLine("Enter any key to continue....");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    case "e":
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        System.Threading.Thread.Sleep(5000);
                        Console.Clear();
                        continue;
                }
            }
        }
    }

}
