﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporProgramı
{
    public partial class GirişAnimasyon : Form
    {
        public GirişAnimasyon()
        {
            InitializeComponent();
        }

        bool islem = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!islem)
            {
                this.Opacity += 0.007;
            }
            if (this.Opacity == 1.0)
            {
                Thread.Sleep(2000);
                islem = true;
            }
            if (islem)
            {
                this.Opacity -= 0.007;
                if (this.Opacity == 0)
                {
                    Form1 form1 = new Form1();
                    form1.Show();
                    timer1.Enabled = false;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
