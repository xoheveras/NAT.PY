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

        static public void Colored(RichTextBox editor, string regex, int lineNumber, int startPos, Color color,bool alltext)
        {
            //text for all text
            string text = "";

            if (alltext == false)
                try
                {
                    text = editor.Lines[lineNumber];
                }
                catch { }
            else
                text = editor.Text;

            MatchCollection matches = Regex.Matches(text, regex);

            if (matches.Count < 0) return;

            foreach (Match match in matches)
            {
                editor.SelectionStart = startPos + match.Index;
                editor.SelectionLength = match.Length;
                editor.SelectionColor = color;
            }
        }

        static public void HighlightTexts(RichTextBox editor, bool alltext)
        {
            int posLine = editor.GetLineFromCharIndex(editor.SelectionStart);
            int posLineIndex = editor.GetFirstCharIndexFromLine(posLine);

            int originalIndex = editor.SelectionStart;
            int originalLength = editor.SelectionLength;
            Color originalColor = Color.White;


            Colored(editor, @".*", posLine, posLineIndex, Color.FromArgb(255, 255, 255),alltext);
            Colored(editor, @"\b(import|from|as|in|with|while|for|break|pass|except|try|finaly|def|return|print|max|min|sort|class|__init__|__str__|
            else|if|is|lambda|raise|yield|with|assert|continue|elif|global|nonlocal|input)\b", posLine, posLineIndex, Color.FromArgb(127, 41, 206),alltext);
            Colored(editor, @"#.*|\x22.*\x22|\x27.*\x27|[0-9]|or|not|and|<|>|<=|>=|int|str|float", posLine, posLineIndex, Color.FromArgb(147, 112, 219),alltext);
            Colored(editor, @"SELECT|WHERE|FROM|UPDATE|DELETE|CREATE", posLine, posLineIndex, Color.FromArgb(255, 160, 122), alltext);

            editor.SelectionStart = originalIndex;
            editor.SelectionLength = originalLength;
            editor.SelectionColor = originalColor;
        }
    }
}
