using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConversorDeMoedas
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_uptDollar_Click(object sender, EventArgs e)
        {
            string fileDollar = "C:\\Windows\\Temp\\dollarValue.txt";
            if (tb_coinValue.Text != null)
            {
                if (File.Exists(fileDollar))
                {
                    File.Delete(fileDollar);
                    File.WriteAllText(fileDollar, tb_coinValue.Text);
                }
                else
                {
                    File.WriteAllText(fileDollar, tb_coinValue.Text);
                }
            }
        }
    }
}
