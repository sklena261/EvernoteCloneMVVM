using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class SaveCommand : ICommand
    {
        private NotesViewModel _notesViewModel;
        public SaveCommand(NotesViewModel notesViewModel)
        {
            _notesViewModel = notesViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            Note note = parameter as Note;
            if (note != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            Note note = parameter as Note;
            if (note != null)
            {
                _notesViewModel.SaveNote();
            }
        }
    }
}
