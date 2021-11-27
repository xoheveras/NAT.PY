using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace NATPY.vendor.Editor.EditorModules
{
    static class LineMeneger
    {
        static int CountLine = 1;
        
        public static void CountLines(RichTextBox editor, RichTextBox lineEditor)
        {
            TextRange text = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd);
            string[] splittedLines = text.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            SetLine(lineEditor,splittedLines.Length - 1);
        }

        public static void SetLine(RichTextBox lineEditor, int lines)
        {
            if (CountLine == lines)
                return;

            lineEditor.Document.Blocks.Clear();
            for (int i = 1; i <= lines; i++)
            {
                lineEditor.Document.Blocks.Add(new Paragraph(new Run(i.ToString())));
            }
            CountLine = lines;
        }
    }
}
