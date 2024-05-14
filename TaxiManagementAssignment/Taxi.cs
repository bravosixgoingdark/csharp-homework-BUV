using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class Taxi
    {
        public int Number;
        public float CurrentFare;
        public Taxi(int num, float currentFare)
        {
            Number = num;
            CurrentFare = currentFare;
        }
    }
}
