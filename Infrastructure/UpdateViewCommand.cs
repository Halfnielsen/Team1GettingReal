using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GettingReal.ViewModel;

namespace GettingReal.Infrastructure
{
    class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {

            if (parameter.ToString() == "Bøger")
            {
                viewModel.SelectedViewModel = new BookViewModel();
            }
            else if (parameter.ToString() == "Brætspil")
            {
                viewModel.SelectedViewModel = new BoardGameViewModel();
            }
            else if (parameter.ToString() == "Live-Udstyr")
            {
                viewModel.SelectedViewModel = new LiveEquipmentViewModel();
            }
            else if (parameter.ToString() == "Alle")
            {
                viewModel.SelectedViewModel = null;
            }
        }
    }
}
