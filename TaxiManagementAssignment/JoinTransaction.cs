using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class JoinTransaction : Transaction
    {
        public JoinTransaction(DateTime dt, int taxiNum, int rankId) : base("Join", dt) // Pass dt to the base class constructor
        {
            this.taxiNum = taxiNum;
            this.rankID = rankId;
        }
        public override string ToString()
        {
            return TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + $" Join      - Taxi {taxiNum} in rank {rankID}";
        }
    }
}
