using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class LeaveTransaction : Transaction 
    {
        public LeaveTransaction(DateTime dt, int rankId, Taxi taxi) : base("Leave", dt)
        {
            TransactionDatetime = dt;
            rankID = rankId;
        }
        public override string ToString()
        {
            return TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + $" Leave Taxi "; //TODO: continue working on this and make Taxi object ref works in here
        } 
    }
}
