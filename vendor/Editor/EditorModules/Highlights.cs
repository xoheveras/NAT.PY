using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace NATPY.vendor.Editor.EditorModules
{
    static class Highlights
    {

        public static void LineColored(RichTextBox Editor, string regexText, byte r, byte g, byte b, string text, int start = 0, int end = 0)
        {
            Regex regex = new Regex(regexText);
            MatchCollection matches = regex.Matches(text);

            if(matches.Count < 1)
                return;

            foreach (Match match in matches)
            {
                if(end < 0)
                    Editor.Selection.Select(GetTextPointerAtOffset(Editor, start + match.Index), GetTextPointerAtOffset(Editor, start + match.Index + (match.Value.Length + end)));
                else
                    Editor.Selection.Select(GetTextPointerAtOffset(Editor, start + match.Index), GetTextPointerAtOffset(Editor, start + match.Index + match.Value.Length));

                Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(r, g, b)));
            }
        }

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

            }
            return navigator;
        }

        public static void OpenHighlights(RichTextBox Editor, RichTextBox lineEditor)
        {
            Editor.BeginChange();

            string text = new TextRange(Editor.Document.ContentStart, Editor.Document.ContentEnd).Text;

            // Writing start value
            var startCaretPos = Editor.CaretPosition;
            var startColorText = Editor.CaretBrush;

            // Colored keyWord
            LineColored(Editor, @".*", 240, 246, 252, text);
            LineColored(Editor, @"\b(and|with|as|assert|break|class|continue|def|del|elif|else|except|finally|for|from|global|if|import|in|is|lambda|nonlocal|not|or|pass|raise|return|try|while|yield)\b", 255, 123, 114, text);
            LineColored(Editor, @"\b\w*[(]", 255, 166, 87, text);
            LineColored(Editor, @"\x27.*\x27|\x22.*\x22", 165, 214, 255, text);
            LineColored(Editor, @"^#.*", 139, 148, 158, text);

            // Return start value
            Editor.CaretPosition = startCaretPos;
            Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(240, 246, 252)));

            Editor.EndChange();

            //lineEditor.BeginChange();
            //LineMeneger.CountLines(Editor, lineEditor);
            //lineEditor.EndChange();
        }

        public static void HighlightsLine(RichTextBox Editor, RichTextBox lineEditor)
        {
            Editor.BeginChange();

            int startPosInt;

            //Find line
            TextPointer startDocument = Editor.Document.ContentStart;
            TextPointer caretPos = Editor.CaretPosition;
            TextPointer startPos = caretPos.GetLineStartPosition(0);
            TextPointer endPos = caretPos.GetLineStartPosition(1) != null ? caretPos.GetLineStartPosition(1) : caretPos.DocumentEnd;

            //Copy Find Text
            var range = new TextRange(startDocument, startPos);
            startPosInt = range.Text.Length;
            string text = new TextRange(startPos, endPos).Text;

            // Writing start value
            var startCaretPos = Editor.CaretPosition;
            var startColorText = Editor.CaretBrush;

            // Colored keyWord
            LineColored(Editor, @".*", 240, 246, 252, text, startPosInt);
            LineColored(Editor, @"\b(and|with|as|assert|break|class|continue|def|del|elif|else|except|finally|for|from|global|if|import|in|is|lambda|nonlocal|not|or|pass|raise|return|try|while|yield)\b", 255, 123, 114, text, startPosInt);
            LineColored(Editor, @"\b\w*[(]", 255, 166, 87, text, startPosInt, -1);
            LineColored(Editor, @"\x27.*\x27|\x22.*\x22", 165, 214, 255, text, startPosInt);
            LineColored(Editor, @"(?<=\x27)(.*)(?=\x27)", 165, 214, 255, text, startPosInt);
            LineColored(Editor, @"^#.*", 139, 148, 158, text, startPosInt);

            // Return start value
            Editor.CaretPosition = startCaretPos;
            Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(240, 246, 252)));
            Editor.EndChange();

            //lineEditor.BeginChange();
            //LineMeneger.CountLines(Editor,lineEditor);
            //lineEditor.EndChange();
        }
    }
}
