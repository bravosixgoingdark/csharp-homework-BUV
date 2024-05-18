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
        private int taxinum;
        private int rankid;
        public int taxiNum { set { taxinum = value; } get { return taxinum; } }
        public int rankID { set { rankid = value; } get { return rankid; } }
        public Transaction(string type, DateTime dt)
        {
            TransactionType = type;
            TransactionDatetime = dt;
        }
    }
}
