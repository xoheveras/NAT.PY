using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NATPY
{
    class NatPyMenuColored : ProfessionalColorTable
    {
        #region Properties

        private Color backGround;
        private Color borderColor;
        private Color borderItemColor;
        private Color openMenuColor;

        #endregion

        public NatPyMenuColored(Color backGround, Color borederColor, Color borderItemColor, Color openMenuColor)
        {
            this.backGround = backGround;
            this.borderColor = borederColor;
            this.borderItemColor = borderItemColor;
            this.openMenuColor = openMenuColor;
        }

        #region ColoredMenu

        public override Color MenuBorder
        {
            get { return this.borderColor; }
        }

        public override Color MenuItemBorder
        {
            get { return this.backGround; }
        }

        public override Color MenuItemSelected
        {
            get { return this.borderItemColor; }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return this.backGround; }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return this.backGround; }
        }

        public override Color MenuStripGradientBegin
        {
            get { return this.backGround; }
        }

        public override Color MenuStripGradientEnd
        {
            get { return this.backGround; }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return this.openMenuColor; }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return this.openMenuColor; }
        }

        /* Item Color */

        public override Color ToolStripDropDownBackground
        {
            get { return this.openMenuColor; }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return this.openMenuColor; }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return this.openMenuColor; }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return this.openMenuColor; }
        }

        #endregion

        #region GradientColored

        /* public override Color ToolStripGradientBegin
       { get { return test; } }

       public override Color ToolStripGradientMiddle
       { get { return Color.CadetBlue; } }

       public override Color ToolStripGradientEnd
       { get { return Color.CornflowerBlue; } }


       public override Color MenuStripGradientBegin
       { get { return Color.Salmon; } }

       public override Color MenuStripGradientEnd
       { get { return Color.OrangeRed; } } */

        #endregion
    }
}
