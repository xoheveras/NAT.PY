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

        private const int WM_USER = 0x0400;
        private const int EM_SETEVENTMASK = (WM_USER + 69);
        private const int WM_SETREDRAW = 0x0b;
        private IntPtr OldEventMask;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public void BeginUpdate()
        {
            SendMessage(this.codeEditor.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
            OldEventMask = (IntPtr)SendMessage(this.codeEditor.Handle, EM_SETEVENTMASK, IntPtr.Zero, IntPtr.Zero);
        }

        public void EndUpdate()
        {
            SendMessage(this.codeEditor.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
            SendMessage(this.codeEditor.Handle, EM_SETEVENTMASK, IntPtr.Zero, OldEventMask);
        }

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
            BeginUpdate();
            highlights.HighlightTexts(this.codeEditor, false);
            EndUpdate();
        }
    }
}
