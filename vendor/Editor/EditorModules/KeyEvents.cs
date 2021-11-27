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
    static class KeyEvents
    {
        private static int startPosInt;

        public static void KeyEnter(RichTextBox Editor)
        {
            //Find line
            TextPointer startDocument = Editor.Document.ContentStart;
            TextPointer caretPos = Editor.CaretPosition;
            TextPointer startPos = caretPos.GetLineStartPosition(0);
            TextPointer endPos = caretPos.GetLineStartPosition(1) != null ? caretPos.GetLineStartPosition(1) : caretPos.DocumentEnd;

            //Copy Find Text
            var range = new TextRange(startDocument, startPos);
            startPosInt = range.Text.Length;
            string text = new TextRange(startPos, endPos).Text;


            if (text.Contains(":"))
            {
                int countTabs = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != ' ')
                        break;
                    else countTabs++;
                }

                try
                {
                    //Editor.CaretPosition.InsertTextInRun("\r\n");
                    Editor.CaretPosition.InsertTextInRun(Environment.NewLine);
                    Editor.CaretPosition = caretPos.GetLineStartPosition(1);
                    Editor.CaretPosition.InsertTextInRun(String.Concat(Enumerable.Repeat(" ", countTabs + 4)));
                }
                catch { }
            }
            else
            {
                try 
                {
                    Editor.CaretPosition.InsertTextInRun(Environment.NewLine);
                    Editor.CaretPosition = caretPos.GetLineStartPosition(1);
                }
                catch { }
        }
        }
        public static void KeyCtrlV(RichTextBox editor)
        {
            string s = (string)Clipboard.GetDataObject().GetData(DataFormats.Text);
            editor.Document.Blocks.Add(new Paragraph(new Run(s)));
        }
        public static void KeyCtrlS(RichTextBox editor) => editor.Selection.Select(editor.Document.ContentStart, editor.Document.ContentEnd);
        public static void KeyTab(RichTextBox Editor) => Editor.CaretPosition.InsertTextInRun("  ");
    }
}
