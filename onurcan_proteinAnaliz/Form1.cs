using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace onurcan_proteinAnaliz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int atomSayisi = 0;
            int x = 0; 
            string atomAdiArama = "ATOM"; 
            string proteinAdiArama = "HEADER"; 
            string dosyaYolu = @"E:\protein.pdb"; // Dosya yolunu değiştirmeyi unutmayın ... 
            string[] satirlar = System.IO.File.ReadAllLines(dosyaYolu); 

            int kontrol;
            foreach (string s in satirlar) 
            {

                kontrol = s.IndexOf(atomAdiArama);

                if (kontrol == 0)
                {

                    listBox1.Items.Add(s); 

                  atomSayisi++; 
                }
            }

            double[] atomXkordinat = new double[atomSayisi]; 
            string[] atomAdi = new string[atomSayisi]; 



            foreach (string s in satirlar) 
            {

                kontrol = s.IndexOf(atomAdiArama); 

                if (kontrol == 0)
                {

                    string xTemp = s.Substring(32, 6); 
                    atomAdi[x] = s.Substring(13, 3);
                    double xTempConvertedType = Convert.ToDouble(xTemp); 
                    atomXkordinat[x] = xTempConvertedType; 

                    x++; 



                }


                kontrol = s.IndexOf(proteinAdiArama); 
                if (kontrol == 0)      
                {

                    string proteinAdi = s.Substring(9, 32); 
                    label4.Text = proteinAdi; 


                }



            }



            label5.Text = Convert.ToString(atomSayisi); 




            double maxKordinat = 0; 

            for (int t = 0; t < atomSayisi; t++)
            {
                if (atomXkordinat[t] > maxKordinat)   
                {
                    maxKordinat = atomXkordinat[t];  
                    label6.Text = Convert.ToString("Atom numarası:"+ (t + 1) + " ,  X kordinatı:"+ atomXkordinat[t] +" ,  Atom adı:"+ atomAdi[t]); 
                    
                }   

            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
