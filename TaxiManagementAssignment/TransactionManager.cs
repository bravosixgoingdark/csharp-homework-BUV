using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class TransactionManager
    {
        public TransactionManager() {
            _transactions = new List<Transaction>();
        }
        private List<Transaction> _transactions;
        public List<Transaction> transactions { get { return _transactions; } }
        public void RecordJoin(int taxiNum, int rankID) {
            DateTime dateTime = DateTime.Now;
            Transaction transaction = new JoinTransaction(dateTime, taxiNum, rankID);
            _transactions.Add(transaction);
        }
        public void RecordLeave(int rankID, Taxi taxi)
        {
            DateTime dateTime = DateTime.Now;
            Transaction transaction = new LeaveTransaction(dateTime, rankID, taxi);
            _transactions.Add(transaction);
        }
        public void RecordDrop(int taxiNum, bool pricePaid)
        {
            DateTime dateTime = DateTime.Now;
            Transaction transaction = new DropTransaction(dateTime, taxiNum, pricePaid);
            _transactions.Add(transaction);
        }
        public List<Transaction> GetAllTransactions() { return _transactions; }
    }
}
