using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class TaxiManager
    {
        private SortedDictionary<int, Taxi> _taxis;
        public SortedDictionary<int, Taxi> taxis { get { return _taxis; } set { _taxis = value; }}
        public TaxiManager() {
            _taxis = new SortedDictionary<int, Taxi>(); // init the database 
        }
        public SortedDictionary<int, Taxi> GetAllTaxis() { return taxis; }
        public Taxi FindTaxi(int taxiNum) {
            if (_taxis.ContainsKey(taxiNum)) { 
                return taxis[taxiNum]; // returns if the dictionary have anything 
            }
            else
            {
                return null; // else returns null
            }
        }
        public Taxi CreateTaxi(int taxiNum) {
            if (taxis.ContainsKey(taxiNum)) {
                return taxis[taxiNum];
            }
            Taxi newTaxi = new Taxi(taxiNum);
            taxis.Add(taxiNum, newTaxi);
            return newTaxi;
        } 
    }
}
