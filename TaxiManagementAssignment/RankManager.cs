using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class RankManager
    {
        private Dictionary<int, Rank> _ranks;
        public Dictionary<int, Rank> ranks { get { return _ranks; } }
//        public Rank rank;

        public RankManager() {
           _ranks = new Dictionary<int, Rank>(); // create new dictionary 
                                                 //for (int i = 0; i <= _ranks.Count; i++){}
           _ranks[1] = new Rank(1, 5);
           _ranks[2] = new Rank(2, 2);
           _ranks[3] = new Rank(3, 4);
        }
        public Rank FindRank(int rankID) {
           if (ranks.ContainsKey(rankID)) {  
                return ranks[rankID]; 
           }
           else { 
                return null; 
           }
        }
        public bool AddTaxiToRank(Taxi taxi, int rankID)
        {
            if (ranks.ContainsKey(rankID)) {
                    return ranks[rankID].AddTaxi(taxi); // I WANT TO DIE
                   // return true; // this is indeed a hack
                }
            return false;
        }
        public Taxi FrontTaxiInRankTakesFare(int rankID, string Destination, double agreedPrice)
        {
            if (ranks.ContainsKey(rankID))
            {
                return ranks[rankID].FrontTaxiTakesFare(Destination, agreedPrice);
            }
            return null;
        }
    }
}
