using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodownClient
{
    public static  class CustomControls
    {
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            var form = new InputBoxForm();
            DialogResult dialogResult = form.ShowDialog();
            value = form.textBox1.Text;
            return dialogResult;
        }
    }
}
