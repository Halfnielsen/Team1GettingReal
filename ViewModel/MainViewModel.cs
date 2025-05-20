using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GettingReal.Model;
using GettingReal.Model.Repositories;
using GettingReal.Infrastructure;

namespace GettingReal.ViewModel
{   
    public class MainViewModel : ViewModelBase
    {
        // Repositories – lige til at udskifte med fil/database senere
        private readonly MemoryItemRepo _itemRepo = new();
        private readonly LoanRepo _loanRepo = new();       

        public ObservableCollection<Item> Items { get; }
        public ObservableCollection<Loan> Loans { get; }

        /* ---------- Selected-properties til bindings ---------- */

        private Item? _selectedItem;
        public Item? SelectedItem
        {
            get => _selectedItem;
            set { SetProperty(ref _selectedItem, value); }
        }

        private Loan? _selectedLoan;
        public Loan? SelectedLoan
        {
            get => _selectedLoan;
            set { SetProperty(ref _selectedLoan, value); }
        }

        //--------- Enabling changing "views" ---------
        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }
        

        /* ---------- Commands ---------- */

        public ICommand AddItemCommand { get; }
        public ICommand EditItemCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand CreateLoanCommand { get; }
        public ICommand CompleteLoanCommand { get; }
        public ICommand RefreshCommand { get; }

       

        public MainViewModel()
        {
            // Fyld collections fra repos
            Items = new ObservableCollection<Item>(_itemRepo.GetAllItems());
            Loans = new ObservableCollection<Loan>(_loanRepo.GetAllLoans());

            // Initialiser kommandoer

            

            AddItemCommand = new RelayCommand(p => AddItem(p as Item));
            EditItemCommand = new RelayCommand(p => EditItem(p as Item), p => p is Item);
            DeleteItemCommand = new RelayCommand(p => DeleteItem(p as Item), p => p is Item);
            CreateLoanCommand = new RelayCommand(_ => CreateLoan(), _ => SelectedItem is { StorageStatus: InWarehouse.Hjemme });
            CompleteLoanCommand = new RelayCommand(_ => CompleteLoan(), _ => SelectedLoan != null && SelectedLoan.ReturnDate == null);
            RefreshCommand = new RelayCommand(_ => Refresh());
            UpdateViewCommand = new UpdateViewCommand(this); // Added this for making multiple views work.
        }

        /* ---------- CRUD- og lånelogik ---------- */
     
        private void AddItem(Item? item)
        {
            if (item == null) return;

            _itemRepo.AddItem(item);
            Items.Add(item);
        }

        private void EditItem(Item? item)
        {
            if (item == null) return;

            _itemRepo.EditItem(item);
            Refresh();                 
        }

        private void DeleteItem(Item? item)
        {
            if (item == null) return;

            _itemRepo.DeleteItem(item);
            Items.Remove(item);
        }

        private void CreateLoan()
        {
            if (SelectedItem == null) return;

            var newLoanId = Loans.Any() ? Loans.Max(l => l.LoanId) + 1 : 1;

            var loan = new Loan(
                loanId: newLoanId,
                itemId: SelectedItem.ItemId,
                loaner: "[Indtast navn]",  // til UI-felt
                loanDate: DateTime.Now);

            _loanRepo.CreateLoan(loan);
            Loans.Add(loan);

            SelectedItem.StorageStatus = InWarehouse.Udlånt;
            _itemRepo.EditItem(SelectedItem);
        }

        private void CompleteLoan()
        {
            if (SelectedLoan == null) return;

            _loanRepo.CompleteLoan(SelectedLoan);
            SelectedLoan.ReturnDate = DateTime.Now;

            var item = _itemRepo.GetById(SelectedLoan.ItemId);
            item.StorageStatus = InWarehouse.Hjemme;
            _itemRepo.EditItem(item);

            Refresh();
        }

        private void Refresh()
        {
            // Simpel refresh – rydder og genindlæser fra repos
            Items.Clear(); 
            foreach (var item in _itemRepo.GetAllItems()) 
                Items.Add(item);

            Loans.Clear(); 
            foreach (var loan in _loanRepo.GetAllLoans()) 
                Loans.Add(loan);
        }

       

        

    }
}
