using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class Rank 
    {
        public int Id;
        public int numberOfTaxiSpaces;
        public int rankid;
        public Taxi taxi;
        public List<Taxi> taxiSpace;
        public Rank(int rankid, int numberOfTaxiSpaces)
        {
            this.Id = rankid;
            this.numberOfTaxiSpaces = numberOfTaxiSpaces;
            this.taxiSpace = []; //init the taxispace list first 
        }
        public bool AddTaxi(Taxi taxi)
        {
            if (taxiSpace.Count < numberOfTaxiSpaces) // checks if is there any taxispaces left
            {
                taxiSpace.Add(taxi); // add new taxi
                taxi.Rank = this; // update Rank of the taxi object
                return true;
            }
            else
            {
                return false;
            }
        }
        public Taxi FrontTaxiTakesFare(string Destination, double agreedPrice)
        {
            //taxiSpace[0].AddFare(Destination, agreedPrice); // addfaring the top one
            if (taxiSpace.Count == 0)
            {
                return null;
            }
            Taxi taxi = taxiSpace[0]; 
            taxi.AddFare(Destination, agreedPrice);
            taxiSpace.RemoveAt(0); // fix to remove the leaving taxi;
            return taxi;
        }
    }
}
