using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class NewNoteCommand : ICommand
    {

        private NotesViewModel _notesViewModel;
        public NewNoteCommand(NotesViewModel notesViewModel)
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
            Notebook notebook = parameter as Notebook;
            if (notebook != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            Notebook notebook = parameter as Notebook;
            _notesViewModel.CreateNote(notebook.NotebookId);
        }
    }
}
