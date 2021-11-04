using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace NAT.PY.Model
{
    static class EditorEvents
    {
        static public void ChangedLineNumber(RichTextBox LineEditor, RichTextBox Editor)
        {
            TextRange MyText = new TextRange(Editor.Document.ContentStart, Editor.Document.ContentEnd);

            string[] splittedLines = MyText.Text.Split(new[] { Environment.NewLine } , StringSplitOptions.None);

            LineEditor.Document.Blocks.Clear();

            for(int i = 1; i <= splittedLines.Length-1; i++)
                LineEditor.Document.Blocks.Add(new Paragraph(new Run(i.ToString())));
        }

        static public void KeyDownEvent(RichTextBox Editor, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                if(!Editor.Selection.IsEmpty)
                {

                }
                else
                {
                    Editor.Selection.Text = "    ";
                }
            }
        }
    }
}
