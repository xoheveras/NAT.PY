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

        static public void Colored(RichTextBox editor, string regex, int lineNumber, int startPos, Color color, int varable = 0, bool alltext = false)
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
                if (varable > 0)
                    editor.SelectionStart = startPos + match.Index;
                else
                    editor.SelectionStart = startPos + (match.Index - varable);

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


            Colored(editor, @".*", posLine, posLineIndex, Color.FromArgb(255, 255, 255),0,alltext);
            Colored(editor, @"\b(import|from|as|in|with|while|for|)\b", posLine, posLineIndex, Color.FromArgb(166,166,166), 0, alltext);
            Colored(editor, @"\b\w*[(]", posLine, posLineIndex, Color.FromArgb(166, 166, 166), 0, alltext);
            Colored(editor, @"\*.+?\*", posLine, posLineIndex, Color.FromArgb(166, 166, 166),1,alltext);

            editor.SelectionStart = originalIndex;
            editor.SelectionLength = originalLength;
            editor.SelectionColor = originalColor;
        }
    }
}
