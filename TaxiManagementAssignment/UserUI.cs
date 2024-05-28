using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class UserUI
    {
        private RankManager rankMgr;
        private TaxiManager taxiMgr;
        private TransactionManager transactionMgr;
        private List<string> _result = new List<string>();

        public UserUI(RankManager rankMgr, TaxiManager taxiMgr, TransactionManager transactionmgr)
        {
            this.rankMgr = rankMgr;
            this.taxiMgr = taxiMgr;
            this.transactionMgr = transactionmgr;
        }

        // Method to handle the scenario when a taxi joins a rank
        public List<string> TaxiJoinsRank(int taxiNum, int rankID)
        {
            // Find the taxi and rank based on the provided taxi number and rank ID
            Taxi taxi = taxiMgr.FindTaxi(taxiNum);
            Rank rank = rankMgr.FindRank(rankID);

            string caseSwitch = "";

            // Check if the taxi or rank is null
            if (taxi == null) caseSwitch = "taxiNull";
            else if (rank == null) caseSwitch = "rankNull";

            switch (caseSwitch)
            {
                case "taxiNull":
                    // If the taxi is null, create a new taxi and add it to the rank
                    rankMgr.AddTaxiToRank(taxiMgr.CreateTaxi(taxiNum), rankID);
                    transactionMgr.RecordJoin(taxiNum, rankID);
                    _result.Insert(0, $"Taxi {taxiNum} has joined rank {rankID}.");
                    break;
                case "rankNull":
                    // If the rank is null, add a message indicating that the rank was not found
                    _result.Add($"Rank {rankID} not found.");
                    break;
                default:
                    // If both the taxi and rank are valid, add the taxi to the rank
                    bool isAdded = rankMgr.AddTaxiToRank(taxi, rankID);
                    if (isAdded)
                    {
                        transactionMgr.RecordJoin(taxiNum, rankID);
                        _result.Insert(0, $"Taxi {taxiNum} has joined rank {rankID}."); // Use the actual rank ID
                    }
                    else
                    {
                        _result.Insert(0, $"Taxi {taxiNum} has not joined rank {rankID}.");
                    }
                    break;
            }
            return _result;
        }

        // Method to handle the scenario when a taxi leaves a rank
        public List<string> TaxiLeavesRank(int rankID, string destination, double agreedPrice)
        {
            // Find the taxi that will take the fare from the front of the rank
            Taxi taxi = rankMgr.FrontTaxiInRankTakesFare(rankID, destination, agreedPrice);
            _result.Clear();

            string caseSwitch = "";

            // Check if the taxi is null
            if (taxi == null) caseSwitch = "taxiNull";

            switch (caseSwitch)
            {
                case "taxiNull":
                    // If the taxi is null, add a message indicating that it has not left the rank
                    _result.Insert(0, $"Taxi has not left rank {rankID}.");
                    break;
                default:
                    // If the taxi is valid, record the leave transaction and add a message indicating the details
                    transactionMgr.RecordLeave(rankID, taxi);
                    _result.Insert(0, $"Taxi {taxi.Number} has left rank {rankID} to take a fare to {destination} for £{agreedPrice}.");
                    break;
            }

            return _result;
        }

        // Method to handle the scenario when a taxi drops its fare
        public List<string> TaxiDropsFare(int taxiNum, bool pricePaid)
        {
            // Find the taxi based on the provided taxi number
            Taxi taxi = taxiMgr.FindTaxi(taxiNum);
            _result.Clear();
            string caseSwitch = "";

            // Check the conditions for different cases
            if (taxi.CurrentFare == 0) caseSwitch = "notexists";
            else if (pricePaid == false) caseSwitch = "notpaid";

            switch (caseSwitch)
            {
                case "notexists":
                    // If the taxi's current fare is 0, add a message indicating that it has not dropped its fare
                    _result.Insert(0, $"Taxi {taxiNum} has not dropped its fare.");
                    return _result;

                case "notpaid":
                    // If the price is not paid, add a message indicating that the fare was dropped and the price was not paid
                    _result.Insert(0, $"Taxi {taxiNum} has dropped its fare and the price was not paid.");
                    transactionMgr.RecordDrop(taxiNum, pricePaid);
                    return _result;

                default:
                    // If the conditions are not met, add a message indicating that the fare was dropped and the price was paid
                    _result.Insert(0, $"Taxi {taxiNum} has dropped its fare and the price was paid.");
                    transactionMgr.RecordDrop(taxiNum, pricePaid);
                    taxi.DropFare(pricePaid);
                    return _result;
            }
        }

        // Method to view the locations of all taxis
        public List<string> ViewTaxiLocations()
        {
            _result.Clear();
            _result.Add("Taxi locations");
            _result.Add("==============");

            // Check if there are any taxis
            if (taxiMgr.taxis.Count != 0)
            {
                foreach (var TaxiEntry in taxiMgr.GetAllTaxis())
                {
                    Taxi taxi = TaxiEntry.Value;

                    if (taxi.Rank != null)
                    {
                        // If the taxi is in a rank, add a message indicating the rank ID
                        _result.Add($"Taxi {taxi.Number} is in rank {taxi.Rank.Id}");
                    }
                    else if (transactionMgr.transactions.Any(t => t is DropTransaction && t.taxiNum == taxi.Number))
                    {
                        // If the taxi has a drop transaction, add a message indicating that it is on the road
                        _result.Add($"Taxi {taxi.Number} is on the road");
                    }
                    else if (taxi.Destination != "")
                    {
                        // If the taxi has a destination, add a message indicating the destination
                        _result.Add($"Taxi {taxi.Number} is on the road to {taxi.Destination}");
                    }
                }
                return _result;
            }

            // If there are no taxis, add a message indicating that there are no taxis
            _result.Add("No taxis");
            return _result;
        }

        // Method to view the financial report
        public List<string> ViewFinancialReport()
        {
            var alltaxis = taxiMgr.GetAllTaxis();
            double totalmoney = 0.00;
            _result.Clear();
            _result.Add("Financial report");
            _result.Add("================");
            string caseSwitch = "";

            // Check if there are any taxis
            if (alltaxis.Count != 0) caseSwitch = "taxiexists";

            switch (caseSwitch)
            {
                case "taxiexists":
                    foreach (var TaxiEntry in alltaxis)
                    {
                        Taxi taxi = TaxiEntry.Value;

                        // Add a message indicating the taxi number and the total money paid
                        _result.Add($"Taxi {taxi.Number}      {taxi.TotalMoneyPaid.ToString("F2")}");

                        // Calculate the total money by summing up the money paid by each taxi
                        totalmoney = taxi.TotalMoneyPaid + totalmoney;
                    }

                    _result.Add("           ======");
                    _result.Add($"Total:       {totalmoney.ToString("F2")}");
                    _result.Add("           ======");
                    return _result;

                default:
                    // If there are no taxis, add a message indicating that no money was taken
                    _result.Add("No taxis, so no money taken");
                    return _result;
            }
        }

        // Method to view the transaction log
        public List<string> ViewTransactionLog()
        {
            var alltransactions = transactionMgr.GetAllTransactions();
            _result.Clear();
            _result.Add("Transaction report");
            _result.Add("==================");
            string caseSwitch = "";

            // Check if there are any transactions
            if (alltransactions.Count != 0) caseSwitch = "transactionexists";

            switch (caseSwitch)
            {
                case "transactionexists":
                    foreach (var transaction in alltransactions)
                    {
                        // Add each transaction to the result list
                        _result.Add(transaction.ToString());
                    }
                    return _result;

                default:
                    // If there are no transactions, add a message indicating that there are no transactions
                    _result.Add("No transactions");
                    return _result;
            }
        }
    }
}
