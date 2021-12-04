using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NATPY
{
    class LinesCount
    {
        #region Vars

        private int linesCount = 1;

        #endregion

        #region Publics

        public void WriteLines(int lineCount, RichTextBox linesBox)
        {
            if (this.linesCount == lineCount) return;

            linesBox.Text = "";
            for (int i = 1; i <= lineCount; i++)
            {
                linesBox.Text += i.ToString() + "\n";
            }
            linesCount = lineCount;
        }

        #endregion
    }
}
