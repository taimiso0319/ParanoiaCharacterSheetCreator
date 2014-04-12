using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCSC
{
    public partial class StatusForm : Form
    {
        Form1 F1 = new Form1();
        public StatusForm()
        {
            this.FormClosing += new FormClosingEventHandler(this.StatusForm_Close);
            InitializeComponent();
        }

        private void StatusForm_Load(object sender, EventArgs e)
        {
        }

        private void StatusForm_Close(object sender, EventArgs e)
        {
        }

    }
}
