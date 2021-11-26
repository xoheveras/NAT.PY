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
            {
                KeyEvents.KeyEnter(Editor);
            }
            else if (e.Key == Key.Tab)
                KeyEvents.KeyTab(Editor);
            else if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.S) 
                return;
            else if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.A)
                KeyEvents.KeyCtrlS(Editor);
        }

        private void Run(object sender, RoutedEventArgs e) => Highlights.OpenHighlights(Editor, lineEditor);
    }
}
