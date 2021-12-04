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
            foreach (Match match in Regex.Matches(editor.Lines[lineNumber], regex))
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

            Colored(editor, @"\b(for)\b", posLine, posLineIndex, Color.FromArgb(166,166,166));
        }
    }
}
