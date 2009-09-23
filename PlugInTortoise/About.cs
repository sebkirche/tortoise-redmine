using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TortoiseIssueList
{
    public partial class About : Form
    {
        private bool _needToClose;
        public About()
        {
            InitializeComponent();
            label1.Text = "Version : " + "1.0.3";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void About_Shown(object sender, EventArgs e)
        {
            progressBar.Value = 100;
            while (progressBar.Value > 0 && !_needToClose)
            {
                Application.DoEvents();
                Thread.Sleep(75);
                progressBar.Value--;
            }
            Close();
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            _needToClose = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}