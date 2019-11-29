using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TianDiTuAPI
{
    public partial class FormRuntime : Form
    {
        public FormRuntime(int length)
        {
            InitializeComponent();
            progressBar1.Maximum = length;
        }

        public void Go()
        {
            if(progressBar1.Value < progressBar1.Maximum)
                progressBar1.Value += 1;
        }

        public void Ok()
        {
            this.Close();
        }

    }
}
