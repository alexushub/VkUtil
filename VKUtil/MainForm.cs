using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkAPILib;

namespace VKAuthorizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(VkApiLib.AccessToken))
            {
                var authForm = new AuthForm();
                authForm.ShowDialog(this);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
