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
        public LeaveTransaction(DateTime dt, int rankId, Taxi taxi) : base("Leave", dt)
        {
            rankID = rankId;
            this.taxi = taxi;
        }
        public override string ToString()
        {
            return TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + $" Leave     - Taxi {taxi.Number} from rank 2 to Somewhere nice for £{taxi.CurrentFare}"; //TODO: continue working on this and make Taxi object ref works in here
        } 
    }
}
