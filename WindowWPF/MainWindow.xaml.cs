﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.Win32;
using NAT.PY.WindowWPF;
using NATPY.vendor.Editor.EditorModules;
using System.Threading;
using System.Windows.Controls;

namespace NAT.PY
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void CreateProject(object sender, RoutedEventArgs e)
        {
            SimpleEditorWindow editorWindow = new SimpleEditorWindow();

            var item = new TreeViewItem();
            item.Header = "unknown";
            editorWindow.fileSelected = "unknown";
            editorWindow.FileTree.Items.Insert(1, item);

            editorWindow.Show();
            this.Hide();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            SimpleEditorWindow editorWindow = new SimpleEditorWindow();
            if (openFileDialog.ShowDialog() == true)
            {
                var range = new TextRange(editorWindow.Editor.Document.ContentStart, editorWindow.Editor.Document.ContentEnd);

                using (var fStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    range.Load(fStream, DataFormats.Text);
                    fStream.Close();
                }
                range.ClearAllProperties();

                Highlights.OpenHighlights(editorWindow.Editor, editorWindow.lineEditor);

                editorWindow.Show();
                this.Hide();
            }
        }

        private void FileDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                SimpleEditorWindow editorWindow = new SimpleEditorWindow();

                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                var range = new TextRange(editorWindow.Editor.Document.ContentStart, editorWindow.Editor.Document.ContentEnd);

                using (var fStream = new FileStream(files[0], FileMode.Open))
                {
                    range.Load(fStream, DataFormats.Text);
                    fStream.Close();
                }
                range.ClearAllProperties();

                Highlights.OpenHighlights(editorWindow.Editor, editorWindow.lineEditor);

                editorWindow.Show();
                this.Hide();

                //Добавить мульти добавление и сразу в дерево и в новые поля
            }
        }
    }
}
