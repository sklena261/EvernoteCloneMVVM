using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class StopEditingCommand : ICommand
    {
        private NotesViewModel _notesViewModel;
        public event EventHandler CanExecuteChanged;

        public StopEditingCommand(NotesViewModel notesViewModel)
        {
            _notesViewModel = notesViewModel;
        }

        public bool CanExecute(object parameter)
        {
             return true;
        }

        public void Execute(object parameter)
        {
            Notebook notebook = parameter as Notebook;
            if (notebook != null)
            {
                _notesViewModel.StopEditing(notebook);

            }
        }
    }
}
