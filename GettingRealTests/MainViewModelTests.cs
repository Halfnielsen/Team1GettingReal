using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal.ViewModel;
using GettingReal.Model;
using System.Linq;

namespace GettingReal.Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        private static Item CreateSampleItem(InWarehouse status = InWarehouse.Hjemme)
        {
            return new Book(
                itemId: null,
                name: "Test Item",
                condition: Condition.Ny,
                approvalRequirement: NeedsApproval.Nej,
                storageStatus: status,
                system: "Test",
                edition: "1st");
        }

        [TestMethod]
        public void CreateLoanCommand_ShouldNotAllowSecondLoan_OnAlreadyBorrowedItem()
        {
            var vm = new MainViewModel();
            var item = CreateSampleItem();
            vm.AddItemCommand.Execute(item);
            vm.SelectedItem = item;

            // Første lån — OK
            vm.CreateLoanCommand.Execute(null);

            // Prøv igen på samme genstand
            Assert.IsFalse(vm.CreateLoanCommand.CanExecute(null));   // eller forvent en exception
        }

        [TestMethod]
        public void AddItemCommand_ShouldAddItemToCollectionAndRepo()
        {
            var vm = new MainViewModel();
            var initialCount = vm.Items.Count;

            var item = CreateSampleItem();
            vm.AddItemCommand.Execute(item);

            Assert.AreEqual(initialCount + 1, vm.Items.Count);
            Assert.IsTrue(vm.Items.Contains(item));
        }

        [TestMethod]
        public void DeleteItemCommand_ShouldRemoveItemFromCollectionAndRepo()
        {
            var vm = new MainViewModel();
            var item = CreateSampleItem();
            vm.AddItemCommand.Execute(item);
            var countAfterAdd = vm.Items.Count;

            vm.DeleteItemCommand.Execute(item);

            Assert.AreEqual(countAfterAdd - 1, vm.Items.Count);
            Assert.IsFalse(vm.Items.Contains(item));
        }

        [TestMethod]
        public void CreateLoanCommand_ShouldCreateLoanAndUpdateItemStatus()
        {
            var vm = new MainViewModel();
            var item = CreateSampleItem();
            vm.AddItemCommand.Execute(item);
            vm.SelectedItem = item;

            Assert.IsTrue(vm.CreateLoanCommand.CanExecute(null));

            var initialLoanCount = vm.Loans.Count;
            vm.CreateLoanCommand.Execute(null);

            Assert.AreEqual(initialLoanCount + 1, vm.Loans.Count);

            var loan = vm.Loans.Last();
            Assert.AreEqual(item.ItemId, loan.ItemId);
            Assert.AreEqual(InWarehouse.Udlånt, item.StorageStatus);
        }

        [TestMethod]
        public void CompleteLoanCommand_ShouldSetReturnDateAndRestoreItemStatus()
        {
            var vm = new MainViewModel();
            var item = CreateSampleItem();
            vm.AddItemCommand.Execute(item);
            vm.SelectedItem = item;
            vm.CreateLoanCommand.Execute(null);

            var loan = vm.Loans.Last();
            vm.SelectedLoan = loan;

            Assert.IsTrue(vm.CompleteLoanCommand.CanExecute(null));

            vm.CompleteLoanCommand.Execute(null);

            Assert.IsNotNull(loan.ReturnDate);
            Assert.AreEqual(InWarehouse.Hjemme, item.StorageStatus);
        }

        [TestMethod]
        public void SelectedItem_ShouldRaisePropertyChangedEvent()
        {
            var vm = new MainViewModel();
            bool eventRaised = false;

            vm.PropertyChanged += (s, e) => {
                if (e.PropertyName == nameof(vm.SelectedItem))
                    eventRaised = true;
            };

            vm.SelectedItem = CreateSampleItem();

            Assert.IsTrue(eventRaised);
        }


    }
}
