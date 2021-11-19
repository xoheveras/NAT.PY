using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace NATPY.vendor.Editor.EditorModules
{
    static class Highlights
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

        public static void OpenHighlights(RichTextBox Editor)
        {
            Editor.BeginChange();

            string text = new TextRange(Editor.Document.ContentStart, Editor.Document.ContentEnd).Text;

            // Find Match in string
            Regex regex = new Regex(@"\b(for|while|def|with|elif|else|except|finally|if|import|try|raise|return|yield|class|pass)\b");
            MatchCollection kewWordsMatсhes = regex.Matches(text);

            Regex regexSecond = new Regex(@"\b(false|true|none|and|as|break|continue|del|from|global|in|is|lambda|nonlocal|not|or)\b");
            MatchCollection keySecondWord = regexSecond.Matches(text);

            // Colored keyWord
            var startCaretPos = Editor.CaretPosition;
            var startColorText = Editor.CaretBrush;

            foreach (Match match in kewWordsMatсhes)
            {
                Editor.Selection.Select(GetTextPointerAtOffset(Editor, match.Index), GetTextPointerAtOffset(Editor, match.Index + match.Value.Length));
                Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(101, 178, 198)));
            }

            foreach (Match match in keySecondWord)
            {
                Editor.Selection.Select(GetTextPointerAtOffset(Editor, match.Index), GetTextPointerAtOffset(Editor, match.Index + match.Value.Length));
                Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(213, 114, 118)));
            }

            // Return start value
            Editor.CaretPosition = startCaretPos;
            Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(166, 166, 166)));

            Editor.EndChange();
        }

        public static void HighlightsLine(RichTextBox Editor, Label T)
        {
            Editor.BeginChange();

            int startPosInt;

            TextPointer startDocument = Editor.Document.ContentStart;
            TextPointer caretPos = Editor.CaretPosition;
            TextPointer startPos = caretPos.GetLineStartPosition(0);
            TextPointer endPos = caretPos.GetLineStartPosition(1) != null ? caretPos.GetLineStartPosition(1) : caretPos.DocumentEnd;

            var range = new TextRange(startDocument, startPos);
            startPosInt = range.Text.Length;

            T.Content = $"startPosInt = {startPosInt} {caretPos.GetLineStartPosition(0)}";

            string text = new TextRange(startPos, endPos).Text;

            // Find Match in string
            Regex regex = new Regex(@"\b(and|with|as|assert|break|class|continue|def|del|elif|else|except|finally|for|from|global|if|import|in|is|lambda|nonlocal|not|or|pass|raise|return|try|while|yield)\b");
            MatchCollection kewWordsMatсhes = regex.Matches(text);

            Regex regexSecond = new Regex(@"\b(False|True|None|print|range|abs|all|any|ascii|bin|bool|bytearray|bytes|callable|
            chr|classmethod|compile|complex|delattr|dir|dict|divmod|enumerate|eval|exec|filter|float|format|frozenset|getattr|
            globals|hasattr|hash|hex|id|input|int|__import__|iter|isinstance|issubclass|len|list|locals|map|max|memoryview|min|next|
            oct|object|open|ord|pow|property|print|range|repr|reversed|round|set|setattr|slice|sorted|str|staticmethod|sum|super|tuple|type|vars|zip)\b");
            MatchCollection keySecondWord = regexSecond.Matches(text);

            Regex regexSymbol = new Regex(@"[+]|[-]|[*]|[%]|[**]|[!=]|[+=]|[-=]|[<]|[>]|[>=]|[<=]|[*=]|[%=]|[**=]");
            MatchCollection keyArifmSymbol = regexSecond.Matches(text);

            // Colored keyWord
            var startCaretPos = Editor.CaretPosition;
            var startColorText = Editor.CaretBrush;

            foreach (Match match in kewWordsMatсhes)
            {
                Editor.Selection.Select(GetTextPointerAtOffset(Editor, startPosInt + match.Index), GetTextPointerAtOffset(Editor, startPosInt + match.Index + match.Value.Length));
                Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(216, 51, 23)));
            }

            foreach (Match match in keySecondWord)
            {
                Editor.Selection.Select(GetTextPointerAtOffset(Editor, startPosInt + match.Index), GetTextPointerAtOffset(Editor, startPosInt + match.Index + match.Value.Length));
                Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(213, 114, 118)));
            }

            foreach (Match match in keyArifmSymbol)
            {
                Editor.Selection.Select(GetTextPointerAtOffset(Editor, startPosInt + match.Index), GetTextPointerAtOffset(Editor, startPosInt + match.Index + match.Value.Length));
                Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(213, 114, 118)));
            }

            // Return start value
            Editor.CaretPosition = startCaretPos;
            Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(166, 166, 166)));

            Editor.EndChange();
        }
    }
}
