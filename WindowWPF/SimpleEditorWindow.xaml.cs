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
using NATPY.vendor.Editor.EditorModules;

namespace NAT.PY.WindowWPF
{
    /// <summary>
    /// Логика взаимодействия для SimpleEditorWindow.xaml
    /// </summary>
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

        private void Editor_KeyDown(object sender, KeyEventArgs e) => Highlights.HighlightsLine(Editor,Testa);
    }
}
