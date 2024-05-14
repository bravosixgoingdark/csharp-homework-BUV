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
        public Rank Rank { 
            get { return _rank; } //getters and setters here to make sure that no one can set a null rank
            set {
                if (value == null)
                {
                    throw new Exception("Rank cannot be null");
                }
                _rank = value; 
            }
        }
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
            //this.Rank = null;
            //ArgumentNullException.ThrowIfNullOrEmpty(Rank);
        }
    }
}
