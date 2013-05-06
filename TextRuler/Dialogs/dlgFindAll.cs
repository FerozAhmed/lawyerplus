using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TextRuler.Dialogs
{
    public partial class dlgFindAll : Form
    {

        frmMain caller;
        int lastStop = 0;

        internal frmMain Caller
        {
            set { caller = value; }
        }

        public dlgFindAll()
        {
            InitializeComponent();
        }
    }
}
