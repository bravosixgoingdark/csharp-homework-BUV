using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class Rank
    {
        public int id;
        public int numberOfTaxiSpaces;
        public List<Taxi> TaxiSpace;
        public Rank(int rankid, int numberOfTaxiSpaces) {
            rankid = id;
            this.numberOfTaxiSpaces = numberOfTaxiSpaces;
        }
        //public AddTaxi(Taxi t)
        //{

        //}
    }
}
