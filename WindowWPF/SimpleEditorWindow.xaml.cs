using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.Win32;
using NATPY.vendor.Editor.EditorModules;

namespace NAT.PY.WindowWPF
{
    public partial class SimpleEditorWindow : Window
    {

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
            
            if (e.Key == Key.Tab)
                KeyEvents.KeyTab(Editor);
            else if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.S) 
                return;
        }

        private void Run(object sender, RoutedEventArgs e) => Highlights.OpenHighlights(Editor, lineEditor);

        private void Editor_KeyDownEvent(object sender, KeyEventArgs e)
        {
            // Вынести в отдельный файл
            Rect Example = Editor.CaretPosition.GetCharacterRect(LogicalDirection.Forward);
            ListBox test = new ListBox();
            //test.Margin = new Thickness(Example.X, -Example.Y, 0, 0);
            //test.Height = 100;
            //test.Width = 100;
            //test.Focus();

            if (e.Key == Key.Enter)
            {
                KeyEvents.KeyEnter(Editor);
                e.Handled = true;
            }
/*          else if(e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.V)
            {
                KeyEvents.KeyCtrlV(Editor);
                e.Handled = true;
            }*/

        }
    }
}
