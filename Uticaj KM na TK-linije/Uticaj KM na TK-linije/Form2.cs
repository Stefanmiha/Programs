using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uticaj_KM_na_TK_linije
{
    public partial class Form2 : Form
    { 
        
        Form1 obj1=new Form1();
        
        Form3 obj3 = new Form3();
        private int VrednostEMS = 50;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            radioButton3.Hide();
            button2.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        { 
           if(Form1.trafo==true && Form1.Button1_is_clicked == true)
            {
                VrednostEMS = 150;
            }
           if(Form1.Button2_is_clicked == true)
            {
                VrednostEMS = 430;
            }
            if(Form1.trafo == true && Form1.Button2_is_clicked == true)
            {
                VrednostEMS = 1200;
            }
            if (Form1.Button1_is_clicked == true)
            {
                if (Form1.Em > VrednostEMS)
                {
                    if (radioButton1.Checked)
                    {
                        MessageBox.Show($"Odgovor nije tacan zato sto je E>{VrednostEMS.ToString()}V");
                        MessageBox.Show("Odaberite odgovarajucu zasitu kablova");
                        obj3.Show();
                        this.Close();
                    }
                    if (radioButton2.Checked)
                    {
                        MessageBox.Show("Odgovor je tacan");
                        MessageBox.Show("Odaberite odgovarajucu zasitu kablova");
                        obj3.Show();
                        this.Close();
                    }
                }
                else if (Form1.Em < VrednostEMS)
                {
                    if (radioButton1.Checked)
                    {
                        MessageBox.Show("Odgovor je tacan");
                        radioButton3.Show();
                        button2.Show();   
                    }
                    if (radioButton2.Checked)
                    {
                        MessageBox.Show($"Odgovor nije tacan zato sto je E<{VrednostEMS.ToString()}V");
                        radioButton3.Show();
                        button2.Show();
                    } 
                }
            }






            //    if (Form1.Em > klasik && Form1.Button1_is_clicked == true)
            //{
            //    if (radioButton1.Checked)
            //    {
            //        MessageBox.Show($"Odgovor nije tacan zato sto je E>{klasik.ToString()}V");
            //        MessageBox.Show("Morate odabrati dodatni vid zastite kablova");
            //    }
            //    else if (radioButton2.Checked)
            //    {
            //        MessageBox.Show("Odgovor je tacan");
            //        MessageBox.Show("Odaberite odgovarajucu zasitu kablova");
            //    }
                
            //    obj3.Show();
            //    this.Close();
            //}












            if(Form1.Button2_is_clicked == true)
            {
                if(Form1.Ek > VrednostEMS)
                {
                    if (radioButton1.Checked)
                    {
                        MessageBox.Show($"Одговор није тачан зато што је E>{VrednostEMS.ToString()}V");
                        MessageBox.Show("Одаберите одговарајућу заштиту кабла");
                        obj3.Show();
                        this.Close();
                    }
                        

                    if (radioButton2.Checked)
                    {
                        MessageBox.Show("Одговор је тачан");
                        MessageBox.Show("Одаберите одговарајућу заштиту кабла");
                        obj3.Show();
                        this.Close();
                    }
                }
                else if (Form1.Ek < VrednostEMS)
                {
                    if (radioButton1.Checked)
                    {
                        MessageBox.Show("Одговор је тачан");
                        radioButton3.Show();
                        button2.Show();

                    }
                    if (radioButton2.Checked)
                    {
                        MessageBox.Show($"Одговор није тачан зато што је E<{VrednostEMS.ToString()}V");
                        radioButton3.Show();
                        button2.Show();
                    }
                    
                }
            }








            if (radioButton3.Checked)
            {
                Form1.obj.Ponovz();
                Form1.trafo = false;
                this.Close(); 
            }   
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
