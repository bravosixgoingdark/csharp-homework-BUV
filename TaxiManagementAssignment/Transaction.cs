using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    abstract public class Transaction
    {
        public DateTime TransactionDatetime;
        public string TransactionType;
        public int taxiNum;
        public int rankID;
        public Transaction(string type, DateTime dt)
        {
            TransactionType = type;
            TransactionDatetime = dt;
        }
    }
}
