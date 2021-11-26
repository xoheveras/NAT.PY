using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using System.Windows;
using NAT.PY.WindowWPF;
using NATPY.vendor.Editor.EditorModules;
using System.Windows.Documents;

namespace NATPY.vendor.Editor.Tree
{
    static class Tree
    {
        static List<string> recentFile = new List<string>();
        static List<string> folders = new List<string>();

        public static void addRecent(string filePath, TreeView tree)
        {
            recentFile.Add(filePath);
            updateTreeAsync(tree);
        }
        public static void addFolder(string filePath, TreeView tree)
        {
            folders.Add(filePath);
            updateTreeAsync(tree);
        }


        public static TextBlock createTextBox(string text, string font, List<int> margin, Brush color)
        {
            TextBlock newBox = new TextBlock();
            newBox.Text = text;
            newBox.FontFamily = new FontFamily(font);
            newBox.Margin = new System.Windows.Thickness(margin[0], margin[1], margin[2], margin[3]);
            newBox.Foreground = color;
            return newBox;
        }

        public static string getFullName(string path)
        {
            var newPath = path.Split('/');
            return newPath[newPath.Length-1];
        }


        public static void updateTreeAsync(TreeView tree)
        {
            tree.Items.Add(createTextBox("Recent", "Montserrat Medium", new List<int> {0,10,0,3}, new SolidColorBrush(Color.FromRgb(110, 109, 109))));
            foreach (string items in recentFile)
            {
                tree.Items.Add(new TreeViewItem()
                {
                    Header = getFullName(items.Replace(@"\", "/")),
                    FontFamily = new FontFamily("Montserrat Medium"),
                    Foreground = new SolidColorBrush(Color.FromRgb(166, 166, 166)),

                });
            }

            tree.Items.Add(createTextBox("Folder", "Montserrat Medium", new List<int> { 0, 10, 0, 3 }, new SolidColorBrush(Color.FromRgb(110, 109, 109))));
        }
    }
}
