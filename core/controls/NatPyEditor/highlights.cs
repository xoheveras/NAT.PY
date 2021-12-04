using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NATPY
{
    static class highlights
    {

        static public void Colored(RichTextBox editor, string regex, int lineNumber, int startPos, Color color)
        {
            MatchCollection matches = Regex.Matches(editor.Lines[lineNumber], regex);

            if (matches.Count < 0) return;

            foreach (Match match in matches)
            {
                editor.SelectionStart = startPos + match.Index;
                editor.SelectionLength = match.Length;
                editor.SelectionColor = color;
            }
        }

        static public void HighlightTexts(RichTextBox editor)
        {
            int posLine = editor.GetLineFromCharIndex(editor.SelectionStart);
            int posLineIndex = editor.GetFirstCharIndexFromLine(posLine);

            int originalIndex = editor.SelectionStart;
            int originalLength = editor.SelectionLength;
            Color originalColor = Color.White;


            Colored(editor, @".*", posLine, posLineIndex, Color.FromArgb(255, 255, 255));
            Colored(editor, @"\b(for)\b", posLine, posLineIndex, Color.FromArgb(166,166,166));

            editor.SelectionStart = originalIndex;
            editor.SelectionLength = originalLength;
            editor.SelectionColor = originalColor;

            editor.Focus();
        }
    }
}
