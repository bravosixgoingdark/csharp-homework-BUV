using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class DropTransaction : Transaction
    {
       private bool pricewaspaid;
       public bool pricewasPaid { set { pricewaspaid = value; } get { return pricewaspaid; } } 
       public DropTransaction(DateTime dt, int taxiNum, bool pricewasPaid) : base("Drop fare", dt)
        {
            this.taxiNum = taxiNum;
            this.pricewasPaid = pricewasPaid;
        }
        public override string ToString()
        {
            if (pricewasPaid == true) {
                return TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + $" Drop fare - Taxi {taxiNum}, price was paid";
            }
            else
            {
                return TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + $" Drop fare - Taxi {taxiNum}, price was not paid";
            }
           
        }
    }
}
