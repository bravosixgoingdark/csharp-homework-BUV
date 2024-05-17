using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    abstract public class Transaction
    {
        private DateTime transactiondatetime;
        private string transactiontype;
        public DateTime TransactionDatetime { get { return transactiondatetime; } set { transactiondatetime = value; } }
        public string TransactionType { get { return transactiontype; } set { transactiontype = value; } }
        public int taxiNum;
        public int rankID;
        public Transaction(string type, DateTime dt)
        {
            TransactionType = type;
            TransactionDatetime = dt;
        }
    }
}
