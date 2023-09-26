using EvernoteClone.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EvernoteClone.View
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        public NotesWindow()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ContentRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextRange selectionRange = new TextRange(ContentRichTextBox.Selection.Start, ContentRichTextBox.Selection.End);
            BoldButton.IsChecked = selectionRange.GetPropertyValue(FontWeightProperty).Equals(FontWeights.Bold);
            ItalicButton.IsChecked = selectionRange.GetPropertyValue(FontStyleProperty).Equals(FontStyles.Italic);
            UnderlineButton.IsChecked = selectionRange.GetPropertyValue(Inline.TextDecorationsProperty) == TextDecorations.Underline;
        }


    }
}
