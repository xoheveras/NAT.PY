using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NAT.PY
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new NAT.PY.Model.UserGetSetting();
        }

        private void _EditorChanged(object sender, KeyEventArgs e) => NAT.PY.Model.Editor.EditorChanged(codeEditor, EditorLineNumber);

        private void _EditorKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Tab)
            {
                MessageBox.Show("gasg");
            }
        }
    }
}
