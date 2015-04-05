using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyOXML;

namespace OpenXML25
{
    public partial class Form1 : Form
    {
        XMLManager eoxml = new XMLManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.ShowDialog();
                if (dlg.FileName != "") eoxml.CreatePackage(dlg.FileName);
            }

        }
        
    }
    
}
