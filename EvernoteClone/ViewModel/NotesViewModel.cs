using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using EvernoteClone.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace EvernoteClone.ViewModel
{
    public class NotesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }

        private Notebook _selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return _selectedNotebook; }
            set 
            { 
                _selectedNotebook = value;
                OnPropertyChanged(nameof(SelectedNotebook));
                GetNotes();
            }
        }

        private Note _selectedNote;

        public Note SelectedNote
        {
            get { return _selectedNote; }
            set 
            { 
                _selectedNote = value;
                OnPropertyChanged(nameof(SelectedNote));
                LoadNote();
            }
        }

        public ObservableCollection<Note> Notes { get; set; }

        private bool _isVisible;

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }
        private FlowDocument _richTextDocument;
        public FlowDocument RichTextDocument
        {
            get { return _richTextDocument; }
            set
            {
                _richTextDocument = value;
                OnPropertyChanged(nameof(RichTextDocument));
            }
        }

        private string _charCount;

        public string CharCount
        {
            get { return _charCount; }
            set 
            { 
                _charCount = value;
                OnPropertyChanged(nameof(CharCount));
            }
        }



        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public EditCommand EditCommand { get; set; }
        public StopEditingCommand StopEditingCommand { get; set; }
        public SaveCommand SaveCommand { get; set; }
        public CharacterCountCommand CharacterCountCommand { get; set; }

        public NotesViewModel()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
            EditCommand = new EditCommand(this);
            StopEditingCommand = new StopEditingCommand(this);
            SaveCommand = new SaveCommand(this);
            CharacterCountCommand = new CharacterCountCommand(this);
            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();
            GetNotebooks();
            IsVisible = false;
            LoadNote();
        }
        public void CreateNote(int notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                NoteCreatedAt = DateTime.Now,
                NoteUpdatedAt = DateTime.Now,
                NoteTitle = "New note"
            };
            DatabaseHelper.Insert(newNote);
            GetNotes();
        }
        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook()
            {
                NotebookName = "New notebook",
            };
            DatabaseHelper.Insert(newNotebook);
            GetNotebooks();
        }

        private void GetNotebooks()
        {
            List<Notebook> notebooks = DatabaseHelper.Select<Notebook>();
            Notebooks.Clear();
            foreach (Notebook notebook in notebooks)
            {
                Notebooks.Add(notebook);
            }
        }

        private void GetNotes()
        {
            if (SelectedNotebook != null)
            {
                List<Note> notes = DatabaseHelper.Select<Note>()
                    .Where(n => n.NotebookId == SelectedNotebook.NotebookId)
                    .OrderBy(n => n.NoteUpdatedAt)
                    .ToList();

                Notes.Clear();
                foreach (Note note in notes)
                {
                    Notes.Add(note);
                }
            }

        }

        public void StartEditig()
        {
            IsVisible = true;
        }
        public void StopEditing(Notebook notebook)
        {
            IsVisible = false;
            DatabaseHelper.Update(notebook);
            GetNotebooks();
        }

        public void RecountCharacters()
        {
            CharCount = "Pocet znaku: " + (new TextRange(RichTextDocument.ContentStart, RichTextDocument.ContentEnd)).Text.Length.ToString();
        }

        public void LoadNote()
        {
            if (SelectedNote != null && SelectedNote.NoteFileLocation != null && File.Exists(SelectedNote.NoteFileLocation))
            {
                using (FileStream fs = new FileStream(SelectedNote.NoteFileLocation, FileMode.Open))
                {
                    TextRange textRange = new TextRange(RichTextDocument.ContentStart, RichTextDocument.ContentEnd);
                    textRange.Load(fs, DataFormats.Rtf);
                }
            }
            else
            {
                RichTextDocument = new FlowDocument();
            }
            RecountCharacters();
        }
        public void SaveNote()
        {
            string rtfFile = Path.Combine(Environment.CurrentDirectory, $"{SelectedNote.NoteId}.rtf");
            SelectedNote.NoteFileLocation = rtfFile;
            DatabaseHelper.Update(SelectedNote);
            using (FileStream fs = new FileStream(SelectedNote.NoteFileLocation, FileMode.Create))
            {
                TextRange textRange = new TextRange(RichTextDocument.ContentStart, RichTextDocument.ContentEnd);
                textRange.Save(fs, DataFormats.Rtf);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
