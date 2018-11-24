using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Uticaj_KM_na_TK_linije
{
    public partial class Form1 : Form
    {
         static Form1 obj;
        public double E = 0.0;
        public static double Em = 0;
        public static bool Button1_is_clicked = false;
        public static bool Button2_is_clicked = false;
        internal static bool trafo = false;
        public static double Ek= 0.0;
        private static double I = 0.0;
        static  int M = 0;
        internal static double Rs = 1.0;
        internal static double Ru = 1.0;
        internal static double Rx = 1.0;
        internal static double Rk = 1.0;
        private bool Tacnost = false;
        private string putanja = "";
        private List<string> lista = new List<string>();
        private List<string> lista2 = new List<string>();
        private List<string> lista3 = new List<string>();
        private static double Udaljenostpada = 0;
        public string putanja2;
        public  static double Duzina_lokalnog_kabla = 0;
        private static double Udaljenosta = 0.0;
        private static double Udaljenost = 0;
        private bool tacnostint = false;
        public static Form1 sule = new Form1();
        static Form2 obj2;


        public Form1()
        {
            InitializeComponent();
            
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            obj = this;
            comboBox1.Items.Add("Лаке глинe");
            comboBox1.Items.Add("Глине");
            comboBox1.Items.Add("Лaпор");
            comboBox1.Items.Add("Порозни кречњак");
            comboBox1.Items.Add("Пешчани камен");
            comboBox1.Items.Add("Кварцити");
            comboBox1.Items.Add("Гранит");

            comboBox2.Items.Add("Лаке глинe");
            comboBox2.Items.Add("Глине");
            comboBox2.Items.Add("Лaпор");
            comboBox2.Items.Add("Порозни кречњак");
            comboBox2.Items.Add("Пешчани камен");
            comboBox2.Items.Add("Кварцити");
            comboBox2.Items.Add("Гранит");

            comboBox3.Items.Add("Двоколосечна пруга са 4П шине и 2 Трансф.");
            comboBox3.Items.Add("Двоколосечна пруга са 4П шине и 1 Трансф.");
            comboBox3.Items.Add("Двоколосечна пруга са 2П шине и 2 Трансф.");
            comboBox3.Items.Add("Двоколосечна пруга са 2П шине и 1 Трансф.");
            comboBox3.Items.Add("Једноколосечна пруга са 2П шине и 2 Трансф.");
            comboBox3.Items.Add("Једноколосечна пруга са 2П шине и 1 Трансф.");
            comboBox3.Items.Add("Једноколосечна пруга са 1П шине и 2 Трансф.");
            comboBox3.Items.Add("Једноколосечна пруга са 1П шине и 1 Трансф.");


















            //comboBox1.Items.Add("Lake gline");
            //comboBox1.Items.Add("Gline");
            //comboBox1.Items.Add("Lapor");
            //comboBox1.Items.Add("Porozni krecnjak");
            //comboBox1.Items.Add("Pescani kamen");
            //comboBox1.Items.Add("Kvarciti");
            //comboBox1.Items.Add("Granit");
            //comboBox2.Items.Add("Lake gline");
            //comboBox2.Items.Add("Gline");
            //comboBox2.Items.Add("Lapor");
            //comboBox2.Items.Add("Porozni krecnjak");
            //comboBox2.Items.Add("Pescani kamen");
            //comboBox2.Items.Add("Kvarciti");
            //comboBox2.Items.Add("Granit");
            //comboBox3.Items.Add("Dvokolosecna pruga sa 4P sine 2Transf");
            //comboBox3.Items.Add("Dvokolosecna pruga sa 4P sine 1Transf");
            //comboBox3.Items.Add("Dvokolosecna pruga sa 2P sine 2Transf");
            //comboBox3.Items.Add("Dvokolosecna pruga sa 2P sine 1Transf");
            //comboBox3.Items.Add("Jednokolosecna pruga sa 2P sine 2Transf");
            //comboBox3.Items.Add("Jednokolosecna pruga sa 2P sine 1Transf");
            //comboBox3.Items.Add("Jednokolosecna pruga sa 1P sine 2Transf");
            //comboBox3.Items.Add("Jednokolosecna pruga sa 1P sine 1Transf");
            
           

        }

        public void button2_Click_1(object sender, EventArgs e)
        {
            
            Button2_is_clicked = true;
            tacnostint = double.TryParse(textBox3.Text, out Udaljenostpada);
            if (!tacnostint && string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Унесите регуларну вредност за удаљеност места кратког споја у односз на ЕВП");
                tacnostint = false;
            }

            tacnostint = double.TryParse(textBox5.Text, out Duzina_lokalnog_kabla);
            if (!tacnostint && string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Унесите регуларну вредност за дужину локалног кабла под утицајем струје вуче");
                tacnostint = false;
            }


            tacnostint = Double.TryParse(textBox4.Text, out Udaljenosta);
            if (!tacnostint && string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Унесите регуларну вредност за удаљеност осе колосека од ТК кабла");
                tacnostint = false;
            }
            Odabir();
            if (!string.IsNullOrEmpty(comboBox3.Text))
            {
                if (comboBox3.Text == "Двоколосечна пруга са 4П шине и 2 Трансф.")
                {
                    putanja = "DVP4PS2T.txt";
                    Odradi2();
                }
                else if (comboBox3.Text == "Двоколосечна пруга са 4П шине и 1 Трансф.")
                {
                    putanja = "DVP4PS1T.txt";
                    Odradi2();
                }
                else if (comboBox3.Text == "Двоколосечна пруга са 2П шине и 2 Трансф.")
                {
                    putanja = "DVP2PS2T.txt";
                    Odradi2();
                }
                else if (comboBox3.Text == "Двоколосечна пруга са 2П шине и 1 Трансф.")
                {
                    ;
                    putanja = "DVP2PS1T.txt";
                    Odradi2();
                }
                else if (comboBox3.Text == "Једноколосечна пруга са 2П шине и 2 Трансф.")
                {
                    putanja = "JKP2PS2T.txt";
                    Odradi2();
                }
                else if (comboBox3.Text == "Једноколосечна пруга са 2П шине и 1 Трансф.")
                {
                    putanja = "JKP2PS1T.txt";
                    Odradi2();
                }
                else if (comboBox3.Text == "Једноколосечна пруга са 1П шине и 2 Трансф.")
                {
                    putanja = "JKP1PS2T.txt";
                    Odradi2();
                }
                else if (comboBox3.Text == "Једноколосечна пруга са 1П шине и 1 Трансф.")
                {
                    putanja = "JKP1PS1T.txt";
                    Odradi2();
                }
                else
                    tacnostint = false;
                
            }
            if (tacnostint == true)
            {
                Izracunajk();
            }
               
            
        }
        public  void Izracunajk()
        {
            Ek = 2 * 3.14 * 50 * M * I * Duzina_lokalnog_kabla * 0.000001 * Rk * Rs * Ru;
            MessageBox.Show("Резултат у режиму кратког споја је " + Ek.ToString() + "V");
            obj2 = new Form2();
            obj2.Show();
        }


        public void Odabir()
        {
                putanja = "empty";
            if (!string.IsNullOrEmpty(comboBox1.Text) || !string.IsNullOrEmpty(comboBox2.Text))
            {
                if ((comboBox1.Text == "Лаке глинe") || (comboBox2.Text == "Лаке глинe"))
                {

                    putanja = "m-5.txt";
                    Odradi();
                }
                else if ((comboBox1.Text == "Глине") || (comboBox2.Text == "Глине"))
                {
                    putanja = "m-10.txt";
                    Odradi();
                }
                else if ((comboBox1.Text == "Лaпор") || (comboBox2.Text == "Лaпор"))
                {
                    putanja = "m-20.txt";
                    Odradi();
                }
                else if ((comboBox1.Text == "Порозни кречњак") || (comboBox2.Text == "Порозни кречњак"))
                {
                    putanja = "m-50.txt";
                    Odradi();
                }
                else if ((comboBox1.Text == "Пешчани камен") || (comboBox2.Text == "Пешчани камен"))
                {
                    putanja = "m-100.txt";
                    Odradi();
                }
                else if ((comboBox1.Text == "Кварцити") || (comboBox2.Text == "Кварцити"))
                {
                    putanja = "m-333.txt";
                    Odradi();
                }
                else if ((comboBox1.Text == "Гранит") || (comboBox2.Text == "Гранит"))
                {
                    putanja = "m-1000.txt";
                    Odradi();
                }
                 
                    
            }
        }

        public void Odradi()
        {
           if(putanja== "empty")
            {
                MessageBox.Show("Морате одабрати земљиште");
                tacnostint = false;
                
            }
            
            putanja2 = Path.GetFullPath(putanja);
            
            if (File.Exists(putanja2))
            {
                
                lista = File.ReadAllLines(putanja2).ToList();
                foreach (string str in lista)
                {
                    
                    lista2 = str.Split(',').ToList();
                    if (Udaljenosta <= int.Parse(lista2[0]))
                    {
                        M = int.Parse(lista2[1]);
                    }
                }
            }
        }

        public void Odradi2()
        {
            putanja2 = Path.GetFullPath(putanja);
            if (File.Exists(putanja2))
            {
                
                lista = File.ReadAllLines(putanja2).ToList();
                foreach (string str in lista)
                {
                    
                   
                    lista2 = str.Split(',').ToList();
                   
                    if (Udaljenostpada <= double.Parse(lista2[0]))
                    {
                        I = double.Parse(lista2[1]);
                        
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Button1_is_clicked = true;
            //if (!(radioButton5.Checked || radioButton4.Checked))
            //{
            //    Tacnost = false;
            //}
            //else
            //{
            //    if (radioButton5.Checked)
            //    {
            //        Rx = 0.5;
            //    }
            //    else if (radioButton4.Checked)
            //    {
            //        Rx = 0.35;
            //    }
            //    Tacnost = true;
            //}





            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            {
                
                if (radioButton1.Checked)
                {
                    I = 0.2;
                }
                if (radioButton2.Checked)
                {
                    I = 0.4;
                }
                if (radioButton3.Checked)
                {
                    I = 0.6;
                }
                Tacnost = true;
            }
            else
            {
                Tacnost = false;
            }
            tacnostint = double.TryParse(textBox1.Text, out Udaljenosta);
            if (!tacnostint && string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Унесите регуларну вредност за удаљеност осе колосека од ТК кабла");
                tacnostint = false;
            }
            tacnostint = double.TryParse(textBox2.Text, out Udaljenost);
            if (!tacnostint && string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Унесите регуларну вредност за дужину локалног кабла под утицајем струје вуче");
                tacnostint = false;
            }
            Odabir();
            Odradi();
            if (Tacnost && tacnostint)
            {
                Izracunaj();
            }
        }

        public void Izracunaj()
        {
            E = 2 * 3.14 * 50 * M * Udaljenost * I * Rs * Rk * Ru * 0.000001;
            MessageBox.Show("Резултат у принудном режиму је " + E.ToString() + "V");
            Em = E;
            obj2 = new Form2();
            obj2.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        public  void Ponovz()
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
          
        }

       

    }
}
