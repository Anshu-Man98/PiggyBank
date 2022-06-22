using System;
using System.Collections.Generic;

namespace PiggyBank.Model
{
    public class UserExpenditure
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public bool isExpense { get; set; }
        public string color { get; set; }
        public string comments { get; set; }
        public string date { get; set; }

        internal List<UserExpenditure> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
