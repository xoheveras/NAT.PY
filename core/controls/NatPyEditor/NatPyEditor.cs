using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        #region Fixed

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private extern static IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

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

            highlights.HighlightTexts(this.codeEditor, true);

        }

        private void EditorTextChanged(object sender, EventArgs e)
        {
            SendMessage(this.codeEditor.Handle, 0xb, (IntPtr)0, IntPtr.Zero);
            highlights.HighlightTexts(this.codeEditor, false);
            SendMessage(this.codeEditor.Handle, 0xb, (IntPtr)1, IntPtr.Zero);
            this.codeEditor.Invalidate();
        }
    }
}
