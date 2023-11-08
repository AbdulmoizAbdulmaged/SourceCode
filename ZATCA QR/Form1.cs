using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZATCA_QR
{
    public partial class Form1 : Form
    {
       public List<string> lines = new List<string>();
        public Image qrImage;
        public Form1()
        {
            
            InitializeComponent();
            textBox1.Text = "Aziz Bro";
            textBox2.Text = "300526281800003";
            textBox3.Text = "1.15";
            textBox4.Text = "0.15";
        }

        private void button1_Click(object sender, EventArgs e)


        {
            string rn = "202310310198421.txt";
            StringBuilder sb = new StringBuilder();
            

            string path = "C:\\Users\\Abdu\\OneDrive\\Desktop\\.NET\\C#\\ZATCA QR\\ZATCA QR\\" + rn;

            lines = Zatca.readReceipt(path);

            foreach(string txt in lines)
            {
                sb.Append(txt);
                sb.Append("\n");
               
            }



            richTextBox1.Text = sb.ToString();

            
        }

        private void printZatcaQR_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Font f8 = new Font("Calibri", 11, FontStyle.Regular);
            Font f9 = new Font("Calibri", 9, FontStyle.Bold);

            int leftmargin = printZatcaQR.DefaultPageSettings.Margins.Left;
            int centermagin = printZatcaQR.DefaultPageSettings.PaperSize.Width / 2;
            int rightmargin = printZatcaQR.DefaultPageSettings.PaperSize.Width;

            StringFormat right = new StringFormat();
            StringFormat center = new StringFormat();
            StringFormat left = new StringFormat();

            int hight = 5;


            right.Alignment = StringAlignment.Far;
            center.Alignment = StringAlignment.Center;
            left.Alignment = StringAlignment.Near;

            foreach(String txt in lines)
            {
                e.Graphics.DrawString(txt, f9, Brushes.Black, leftmargin, hight, center);
                hight = hight + 13;
            }
            e.Graphics.DrawImage(qrImage,Convert.ToInt32((e.PageBounds.Width - 170) / 2), hight + 11, 120, 120);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            qrImage = Zatca.generateQR(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

            pictureBox1.Image = qrImage;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                

                printZatcaQR.Print();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
