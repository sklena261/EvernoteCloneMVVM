using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class EditCommand : ICommand
    {
        private NotesViewModel _notesViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public EditCommand(NotesViewModel notesViewModel)
        {
            _notesViewModel = notesViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _notesViewModel.StartEditig();
        }
    }
}
