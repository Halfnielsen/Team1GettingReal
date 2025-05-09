using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal.Model.Interfaces
{
    public interface ILoanRepo
    {
        public void CreateLoan(Loan loan);
        public void CompleteLoan(Loan loan);
        List<Loan> GetAllLoans();
        Loan GetLoanById(int loanId);
    }
}
