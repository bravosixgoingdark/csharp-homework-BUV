using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class Taxi
    {
        public int Number;
        public double CurrentFare;
        public string Destination;
        public string Location;
        public Rank Rank;
        private string IN_RANK = "in rank";
        private string ON_ROAD = "on the road";
        public double TotalMoneyPaid;
        public Taxi(int num)
        {
            Number = num;
            CurrentFare = 0;
            Destination = string.Empty;
            Location = ON_ROAD;
            TotalMoneyPaid = 0;
        }
    }
}
