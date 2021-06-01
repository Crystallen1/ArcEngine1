using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWindowsApplication1
{
    public partial class AdmitBookmarkName : Form
    {
        public AdmitBookmarkName()
        {
            InitializeComponent();
        }

        public Form1 m_frm;
        public AdmitBookmarkName(Form1 frm)
        {
            InitializeComponent();
            if (frm != null)
            {
                m_frm = frm;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_frm != null || textBox1.Text == "")
            {
                m_frm.CreatBookMark(textBox1.Text);
            }
            this.Close();
        }
    }
}
