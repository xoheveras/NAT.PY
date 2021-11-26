using System;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.Win32;
using NATPY.vendor.Editor.EditorModules;

namespace NAT.PY.WindowWPF
{
    public partial class SimpleEditorWindow : Window
    {
        public string fileSelected;
        public string fileSelectedPath;

        public SimpleEditorWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            Highlights.HighlightsLine(Editor, lineEditor);

            if (e.Key == Key.Enter)
                KeyEvents.KeyEnter();
            if (e.Key == Key.Tab)
                KeyEvents.KeyTab(Editor);

            if(e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.S)
            {
                MessageBox.Show("save");

                if(fileSelected == "unknown" || fileSelectedPath == "")
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Python|*.py";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        TextRange text = new TextRange(Editor.Document.ContentStart, Editor.Document.ContentEnd);
                        FileStream filesystem = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        text.Save(filesystem, DataFormats.Text);
                        filesystem.Close();

                        fileSelectedPath = saveFileDialog.FileName;
                        fileSelected = saveFileDialog.FileName;
                    }
                }
                else
                {
                    TextRange text = new TextRange(Editor.Document.ContentStart, Editor.Document.ContentEnd);
                    FileStream filesystem = new FileStream(fileSelectedPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    text.Save(filesystem, DataFormats.Text);
                    filesystem.Close();
                }
            }
        }

        private void Run(object sender, RoutedEventArgs e)
        {
            Highlights.OpenHighlights(Editor, lineEditor);
        }
    }
}
