using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingReal.Model.Interfaces;

namespace GettingReal.Model.Repositories
{
    public class LoanRepo : ILoanRepo
    {
        private readonly List<Loan> loans = new List<Loan>();

        public void CreateLoan(Loan loan)
        {
            if (loan == null)
                throw new ArgumentNullException(nameof(loan));

            if (loans.Any(l => l.LoanId == loan.LoanId))
                throw new InvalidOperationException("Loan with the same ID already exists.");

            loans.Add(loan);
        }

        public void CompleteLoan(Loan loan)
        {
            var existingLoan = loans.FirstOrDefault(l => l.LoanId == loan.LoanId);
            if (existingLoan != null)
            {
                existingLoan.ReturnDate = DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException("Loan not found.");
            }
        }
        public List<Loan> GetAllLoans()
        {
            return new List<Loan>(loans);
        }
        
        public Loan GetLoanById(int loanId)
        {
            return loans.FirstOrDefault(l => l.LoanId == loanId);
        }

    }
    
}
