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

        public RankManager()
        {
            // Initialize the ranks dictionary
            _ranks = new Dictionary<int, Rank>();

            // Add initial ranks to the dictionary
            _ranks[1] = new Rank(1, 5);
            _ranks[2] = new Rank(2, 2);
            _ranks[3] = new Rank(3, 4);
        }

        public Rank FindRank(int rankID)
        {
            if (ranks.ContainsKey(rankID))
            {
                return ranks[rankID];
            }
            else
            {
                return null;
            }
        }

        public bool AddTaxiToRank(Taxi taxi, int rankID)
        {
            if (ranks.ContainsKey(rankID))
            {
                // Add the taxi to the specified rank
                return ranks[rankID].AddTaxi(taxi);
            }
            return false;
        }

        public Taxi FrontTaxiInRankTakesFare(int rankID, string Destination, double agreedPrice)
        {
            if (ranks.ContainsKey(rankID))
            {
                // Get the front taxi in the specified rank and let it take the fare
                return ranks[rankID].FrontTaxiTakesFare(Destination, agreedPrice);
            }
            return null;
        }
    }
}
