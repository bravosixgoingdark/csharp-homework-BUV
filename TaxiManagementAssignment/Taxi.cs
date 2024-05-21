using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class Taxi
    {
        private int number;
        private double? currentfare;
        private string destination;
        private string location;
        private Rank _rank;
        public int Number { 
            get { return number; } 
            set 
            { 
                number = value;
            } 
        }
        public double? CurrentFare { get { return currentfare; }
            set
            {
                currentfare = value;
            } 
        }
        public string Destination { get { return destination; }
            set
            {
                destination = value;
            }
        }
        public string Location { get { return location; }
            set
            {
                location = value;
            } 
        }
        public Rank Rank { 
            get { return _rank; } 
            set {
                if (value == null)
                {
                    throw new Exception("Rank cannot be null"); // make sure that the rank cannot be null
                }
                if (Destination != null && Destination != "") // make sure that the rank cannot be set for the thing
                {
                    throw new Exception("Cannot join rank if fare has not been dropped");
                }
                _rank = value;
                Location = IN_RANK; // if set rank and then the location will be set as IN_RANK
            }
        }
        public static string IN_RANK = "in rank"; 
        public static string ON_ROAD = "on the road";
        public double TotalMoneyPaid;
        public Taxi(int num)
        {
            Number = num;
            CurrentFare = 0;
            Destination = string.Empty;
            TotalMoneyPaid = 0;
            Location = ON_ROAD; // by default, the location will be ON_ROAD, will subject to some change later
        }
        public void AddFare(string destination, double agreedPrice)
        {
            this.Destination = destination;
            CurrentFare = agreedPrice;
            this._rank = null; //overrides the private rank property
        }
        public void DropFare(bool priceWasPaid)
        {
            if (priceWasPaid == true)
            {
                TotalMoneyPaid = (double)(CurrentFare + TotalMoneyPaid);
                CurrentFare = 0;
                Destination = string.Empty;
            }
        }
        
    }
}
