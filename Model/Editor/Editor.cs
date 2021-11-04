using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace NAT.PY.Model
{
    static class Editor
    {
        public static TextPointer GetTextPointerAtOffset(this RichTextBox richTextBox, int offset)
        {
            var navigator = richTextBox.Document.ContentStart;
            int cnt = 0;

            while (navigator.CompareTo(richTextBox.Document.ContentEnd) < 0)
            {
                switch (navigator.GetPointerContext(LogicalDirection.Forward))
                {
                    case TextPointerContext.ElementStart:
                        break;
                    case TextPointerContext.ElementEnd:
                        if (navigator.GetAdjacentElement(LogicalDirection.Forward) is Paragraph)
                            cnt += 2;
                        break;
                    case TextPointerContext.EmbeddedElement:
                        cnt++;
                        break;
                    case TextPointerContext.Text:
                        int runLength = navigator.GetTextRunLength(LogicalDirection.Forward);

                        if (runLength > 0 && runLength + cnt < offset)
                        {
                            cnt += runLength;
                            navigator = navigator.GetPositionAtOffset(runLength);
                            if (cnt > offset)
                                break;
                            continue;
                        }
                        cnt++;
                        break;
                }

                if (cnt > offset)
                    break;

                navigator = navigator.GetPositionAtOffset(1, LogicalDirection.Forward);

            } // End while.

            return navigator;
        }

        static public void EditorChanged(RichTextBox Editor, RichTextBox EditorLineNumber)
        {
            string text = new TextRange(Editor.Document.ContentStart, Editor.Document.ContentEnd).Text;

            // Find Match in string
            Regex regex = new Regex(@"\b(for|while|def|with|elif|else|except|finally|if|import|try|raise|return|yield|class|pass)\b");
            MatchCollection kewWordsMatсhes = regex.Matches(text);

            Regex regexSecond = new Regex(@"\b(false|true|none|and|as|break|continue|del|from|global|in|is|lambda|nonlocal|not|or)\b");
            MatchCollection keySecondWord = regexSecond.Matches(text);

            // Colored keyWord
            var startCaretPos = Editor.CaretPosition;
            var startColorText = Editor.CaretBrush;

            foreach(Match match in kewWordsMatсhes)
            {
                Editor.Selection.Select(GetTextPointerAtOffset(Editor, match.Index), GetTextPointerAtOffset(Editor, match.Index + match.Value.Length));
                Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(101,178,198)));
            }

            foreach (Match match in keySecondWord)
            {
                Editor.Selection.Select(GetTextPointerAtOffset(Editor, match.Index), GetTextPointerAtOffset(Editor, match.Index + match.Value.Length));
                Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(213, 114, 118)));
            }

            // Return start value
            Editor.CaretPosition = startCaretPos;
            Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(0, 0, 0)));

            // Check Line
            EditorEvents.ChangedLineNumber(EditorLineNumber,Editor);
        }
    }
}
