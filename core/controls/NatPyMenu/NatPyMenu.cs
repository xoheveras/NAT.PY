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
    public partial class NatPyMenu : UserControl
    {

        #region Properties

        /* Menu custom color */
        public Color BackColor_ { get; set; }
        public Color FontColor_ { get; set; }
        public Color BorderColor_ { get; set; }
        public Color BorderItemColor_ { get; set; }
        public Color OpenMenuColor_ { get; set; }

        /* Menu bool and event */
        public bool isEditor { get; set; }

        #endregion

        public NatPyMenu()
        {
            /* Fixed resize component */
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }


        #region Events

        private void NatPyMenu_Load(object sender, EventArgs e)
        {
            /* Start component params */
            this.menuStrip1.ForeColor = FontColor_;
            this.menuStrip1.BackColor = BackColor_;
            this.fileToolStripMenuItem.ForeColor = FontColor_;
            this.menuStrip1.Renderer = new ToolStripProfessionalRenderer(new NatPyMenuColored(BackColor_, BorderColor_, BorderItemColor_, OpenMenuColor_));
        }

        /* Track button click */
        /* Assign each button its own event */

        #endregion
}
}
