using System;
using SQLite;

namespace PiggyBank.Model
{
    public class UserStatus
    {
        public int UserId { get; set; }
        public double TotalBalance{get;set;}
        public double Monthbalance{ get; set; }
    }
}
