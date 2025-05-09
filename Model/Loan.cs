using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal.Model
{
    public class Loan
    {
        public int LoanId { get; private set; } 
        public int ItemId { get; private set; }
        public string Loaner { get; private set; } 
        public DateTime LoanDate { get; set; } 
        public DateTime? ReturnDate { get;  set; }

        public Loan(int loanId, int itemId, string loaner, DateTime loanDate, DateTime? returnDate = null)
        {
            LoanId = loanId;
            ItemId = itemId;
            Loaner = loaner;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }


    }
}
