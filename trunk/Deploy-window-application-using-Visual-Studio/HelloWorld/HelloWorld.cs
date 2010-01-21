using System;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class HelloWorld : Form
    {
        public HelloWorld()
        {
            InitializeComponent();
        }

        private void btnHello_Click(object sender, EventArgs e)
        {
            MessageBox.Show("http://code2code.info");
        }
    }
}
