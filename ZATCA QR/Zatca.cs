using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Drawing;
using ZXing;
using QRCoder;


namespace ZATCA_QR
{
    class Zatca

    {
       
        

        public static List<string> readReceipt(String path)
        {

            List<string> list = new List<string>();
            string receiptLine = "";

            FileStream f = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader s = new StreamReader(f);
            
            using (s)
            {
                //receiptLine = s.ReadToEnd();

                while (!s.EndOfStream)
                {

                    receiptLine = s.ReadLine();

                    if (receiptLine.Length > 0)
                        list.Add(receiptLine);
                }
                
            }



            return list;
        }

        public static Image generateQR(String aCompanyName,String aVATNumber,String aReceiptTotal,String aVATValue)
        {
            string value1 = getTLV(1, aCompanyName);
            string value2 = getTLV(2, aVATNumber);
            string value3 = getTLV(3, System.DateTime.Now.ToString());
            string value4 = getTLV(4, aReceiptTotal);
            string value5 = getTLV(5, aVATValue);

            Byte[] b = System.Text.Encoding.UTF8.GetBytes(value1 + value2 + value3 + value4 + value5);
            String t = Convert.ToBase64String(b);

            QRCodeGenerator gen = new QRCodeGenerator();

            QRCode qR = new QRCode(gen.CreateQrCode(t, QRCodeGenerator.ECCLevel.M));

            Image qrImage;

            qrImage = new Bitmap(qR.GetGraphic(6));

            return qrImage;


        }
        public static String getTLV(int tag,String value)
        {

            string s = (char)tag + (char)value.Length + value;
            return null;
        }
    }
                

           
            



            

    
}
