using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NATPY.vendor.Editor.EditorModules
{
    static class KeyEvents
    {
        public static void KeyEnter()
        {
            // Auto tambulation
        }

        public static void KeyTab(RichTextBox Editor) => Editor.CaretPosition.InsertTextInRun("  ");
    }
}
