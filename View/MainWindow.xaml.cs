﻿using System.Windows;
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

        private void _EditorKeyDown(object sender, KeyEventArgs e) => NAT.PY.Model.EditorEvents.KeyDownEvent(codeEditor,e);

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
