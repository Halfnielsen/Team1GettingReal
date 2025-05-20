using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal.Model.Repositories;
using GettingReal.Model;

namespace GettingRealTests
{
    [TestClass]
    public class LoanTests
    {
        [TestMethod]
        public void CreateLoan_ShouldAddLoanToRepository()
        {
            // Arrange
            var repo = new LoanRepo();
            var loan = new Loan(1, 1, "Tobias", DateTime.Now, DateTime.Now);

            // Act
            repo.CreateLoan(loan);
            var result = repo.GetLoanById(loan.LoanId);
            var allLoans = repo.GetAllLoans();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(loan.LoanId, result.LoanId);
            Assert.IsNotNull(allLoans);
            Assert.AreEqual(loan.LoanId, loan.LoanId, loan.Loaner, loan.LoanDate, loan.ReturnDate, result.LoanId, result.Loaner, result.LoanDate, result.ReturnDate);
        }
        [TestMethod]
        public void CompleteLoan_ShouldUpdateReturnDate()
        {
            // Arrange
            var repo = new LoanRepo();
            var loan = new Loan(1, 1, "Tobias", DateTime.Now, null);
            repo.CreateLoan(loan);
            // Act
            loan.ReturnDate = DateTime.Now;
            repo.CompleteLoan(loan);
            var result = repo.GetLoanById(loan.LoanId);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(loan.ReturnDate, result.ReturnDate);
        }
        //[TestMethod]
        //public void GetLoanById_ShouldThrow_WhenNotFound()
        //{
        //    // Arrange
        //    var repo = new LoanRepo();
        //    // Act & Assert
        //    Assert.ThrowsException<Exception>(() => repo.GetLoanById(999));
        //}
        [TestMethod]
        public void GetAllLoans_ShouldReturnEmpty_WhenNoLoans()
        {
            // Arrange
            var repo = new LoanRepo();
            // Act
            var allLoans = repo.GetAllLoans();
            // Assert
            Assert.IsNotNull(allLoans);
            Assert.AreEqual(0, allLoans.Count());
        }
        [TestMethod]
        public void CompleteLoan_ShouldThrow_WhenLoanNotFound()
        {
            // Arrange
            var repo = new LoanRepo();
            var loan = new Loan(999, 1, "Tobias", DateTime.Now, null);

            // Act & Assert
            Assert.ThrowsException<Exception>(() => repo.CompleteLoan(loan));
        }
        [TestMethod]
        public void CreateLoan_ShouldThrowException_WhenLoanAlreadyExists()
        {
            // Arrange
            var repo = new LoanRepo();
            var loan = new Loan(1, 1, "Tobias", DateTime.Now, null);
            repo.CreateLoan(loan);
            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => repo.CreateLoan(loan));
        }
    }
}
