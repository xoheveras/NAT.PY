using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NATPY
{
    public partial class NatPyEditor : UserControl
    {
        #region Propertes
        #endregion

        #region Vars

        //LinesCount lineCounter = new LinesCount();

        #endregion

        public NatPyEditor()
        {
            InitializeComponent();

            /* Start editor setting */
            this.codeEditor.Multiline = true;
            this.codeEditor.WordWrap = false;
            this.codeEditor.AcceptsTab = true;
            this.codeEditor.ScrollBars = RichTextBoxScrollBars.Both;
            this.linesBox.ScrollBars = RichTextBoxScrollBars.None;
            this.panel1.AutoScroll = true;

        }

        private void EditorTextChanged(object sender, EventArgs e)
        {
            highlights.HighlightTexts(this.codeEditor);
        }
    }
}
