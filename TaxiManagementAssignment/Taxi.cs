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
        private Rank _rank;
        public double agreedPrice; 
        public Rank Rank { 
            get { return _rank; } 
            set {
                if (value == null)
                {
                    throw new Exception("Rank cannot be null"); // make sure that the rank cannot be null
                }
                if (!string.IsNullOrEmpty(Destination)) // make sure that the rank cannot be set for the thing
                {
                    throw new Exception("Cannot join rank if fare has not been dropped");
                }
                _rank = value;
                Location = IN_RANK;
            }
        }
        public static string IN_RANK = "in rank"; 
        public string ON_ROAD = "on the road";
        public double TotalMoneyPaid;
        public Taxi(int num)
        {
            Number = num;
            CurrentFare = 0;
            Destination = string.Empty;
            TotalMoneyPaid = 0;
            Location = ON_ROAD;
        }
        public void AddFare(string destination, double agreedPrice)
        {
            this.Destination = destination;
        }
    }
}
