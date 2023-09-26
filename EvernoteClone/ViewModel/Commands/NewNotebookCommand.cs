using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class NewNotebookCommand : ICommand
    {



        private NotesViewModel _notesViewModel;
        public NewNotebookCommand(NotesViewModel notesViewModel)
        {
            _notesViewModel = notesViewModel;
        }



        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _notesViewModel.CreateNotebook();
        }
    }
}
