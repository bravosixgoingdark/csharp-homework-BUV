using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class LeaveTransaction : Transaction 
    {
        public Taxi taxi;
        private string _destination;
        private string _CurrentFare;
        public LeaveTransaction(DateTime dt, int rankId, Taxi taxi) : base("Leave", dt)
        {
            rankID = rankId;
            this.taxi = taxi;
            this._destination = taxi.Destination;
            this._CurrentFare = taxi.CurrentFare.ToString();
        }
        public override string ToString()
        {
            return TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + $" Leave     - Taxi {taxi.Number} from rank {rankID} to {_destination} for £{_CurrentFare}"; //TODO: continue working on this and make Taxi object ref works in here
        } 
    }
}
