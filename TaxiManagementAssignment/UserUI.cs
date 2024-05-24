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
        
        public UserUI(RankManager rankMgr, TaxiManager taxiMgr, TransactionManager transactionmgr) {
            this.rankMgr = rankMgr;
            this.taxiMgr = taxiMgr;
            this.transactionMgr = transactionmgr;
        }
        public List<string> TaxiJoinsRank(int taxiNum, int rankID) // replaced the if elese hellscape to make the code more human-readable
        {
            Taxi taxi = taxiMgr.FindTaxi(taxiNum);
            Rank rank = rankMgr.FindRank(rankID);

            string caseSwitch = "";

            if (taxi == null) caseSwitch = "taxiNull";
            else if (rank == null) caseSwitch = "rankNull";

            switch (caseSwitch)
            {
                case "taxiNull":
                    rankMgr.AddTaxiToRank(taxiMgr.CreateTaxi(taxiNum), rankID);
                    transactionMgr.RecordJoin(taxiNum, rankID);
                    _result.Insert(0, $"Taxi {taxiNum} has joined rank {rankID}.");
                    break;
                case "rankNull":
                    _result.Add($"Rank {rankID} not found.");
                    break;
                  default:
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
        public List<string> TaxiLeavesRank(int rankID, string destination, double agreedPrice)
        {
            Taxi taxi = rankMgr.FrontTaxiInRankTakesFare(rankID, destination, agreedPrice);
            _result.Clear();

            string caseSwitch = "";

            if (taxi == null) caseSwitch = "taxiNull";

            switch (caseSwitch)
            {
                case "taxiNull":
                    _result.Insert(0, $"Taxi has not left rank {rankID}.");
                    break;
                default:
                    transactionMgr.RecordLeave(rankID, taxi);
                    _result.Insert(0, $"Taxi {taxi.Number} has left rank {rankID} to take a fare to {destination} for £{agreedPrice}.");
                    break;
            }

            return _result;
        }
        public List<string> TaxiDropsFare (int taxiNum, bool pricePaid)
        {
            Taxi taxi = taxiMgr.FindTaxi(taxiNum);
            _result.Clear();
            string caseSwitch = "";
            if (taxi.CurrentFare == 0) caseSwitch = "notexists";
            else if (pricePaid == false) caseSwitch = "notpaid";
            switch (caseSwitch)
            {
                case "notexists":
                    _result.Insert(0, $"Taxi {taxiNum} has not dropped its fare.");
                    return _result;
                    
                case "notpaid":
                    _result.Insert(0, $"Taxi {taxiNum} has dropped its fare and the price was not paid.");
                    transactionMgr.RecordDrop(taxiNum, pricePaid);
                    return _result;
                default:
                    _result.Insert(0, $"Taxi {taxiNum} has dropped its fare and the price was paid.");
                    transactionMgr.RecordDrop(taxiNum, pricePaid);
                    return _result;
            }
        }

       
        public List<string> ViewTaxiLocations()
        {
            var alltaxis = taxiMgr.GetAllTaxis();
            _result.Clear();
            _result.Add("Taxi locations");
            _result.Add("==============");
            string caseSwitch = "";
            if (alltaxis.Count != 0) caseSwitch = "taxiexists";
            switch (caseSwitch)
            {
                case "taxiexists":
                    foreach (var TaxiEntry in alltaxis)
                    {
                        Taxi taxi = TaxiEntry.Value;
                        if (taxi.Rank != null)
                        {
                            _result.Add($"Taxi {taxi.Number} is in rank {taxi.Rank.Id}");
                        }
                        else if (transactionMgr.transactions.Any(t => t is DropTransaction && t.taxiNum == taxi.Number)) // this is indeed a hack, that's all, don't be mad at me Mr F
                        {
                            _result.Add($"Taxi {taxi.Number} is on the road");
                        }
                        else if (taxi.Destination != "")
                        {
                            _result.Add($"Taxi {taxi.Number} is on the road to {taxi.Destination}");
                        }
                    }
                    return _result;
                default:
                    _result.Add("No taxis");
                    return _result;
            }
        }
        public List<string> ViewFinancialReport()
        {
            var alltaxis = taxiMgr.GetAllTaxis();
            double totalmoney = 0.00;
            _result.Clear();
            _result.Add("Financial report");
            _result.Add("================");
            string caseSwitch = "";
            if (alltaxis.Count != 0) caseSwitch = "taxiexists";
            switch(caseSwitch)
            {
                case "taxiexists":
                    foreach (var TaxiEntry in alltaxis)
                    {
                        Taxi taxi = TaxiEntry.Value;
                        _result.Add($"Taxi {taxi.Number}      {taxi.TotalMoneyPaid.ToString("F")}");
                         totalmoney = taxi.TotalMoneyPaid + totalmoney;
                    }
                    _result.Add("           ======");
                    _result.Add($"Total:       {totalmoney.ToString("F")}");
                    _result.Add("           ======");
                    return _result;
                default:
                    _result.Add("No taxis, so no money taken");
                    return _result;
            }
        }
    }
}
