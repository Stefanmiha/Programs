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

namespace Uticaj_KM_na_TK_linije
{
    public partial class Form3 : Form
    {
        private string Nazivkabla = "";
        private string putanja = "";
        List<string> linija = new List<string>();
        List<string> linije = new List<string>();
        List<string> fin = new List<string>();
        public double Koeficijenta = 1;
        private int voltf = 0;
        private double Volts = 0;
        private bool nadjen = false;
        private double Rs=0.45;
        
        private double E = 0;
        
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Add("Кабал без заштита");
            comboBox1.Items.Add("Оловни Ом. 0.5мм Пречник 22-33мм");
            comboBox1.Items.Add("Оловни Ом. 0.5мм Пречник 43мм");
            comboBox1.Items.Add("Оловни Ом. 0.8мм Пречник 33-45мм");
            comboBox1.Items.Add("Оловни Ом. 0.8мм Пречник 45мм");
            comboBox1.Items.Add("Челични Ом. 0.5мм Пречник 15-19мм");
            comboBox1.Items.Add("Челични Ом. 0.5мм Пречник 24-30мм");
            comboBox1.Items.Add("Челични Ом. 0.5мм Пречник 34-40мм");
            comboBox1.Items.Add("Челични Ом. 0.5мм Пречник 45-49мм");
            comboBox1.Items.Add("Челични Ом. 0.8мм Пречник 15-19мм");
            comboBox1.Items.Add("Челични Ом. 0.8мм Пречник 24-30мм");
            comboBox1.Items.Add("Челични Ом. 0.8мм Пречник 40-45мм");
            comboBox1.Items.Add("Челични Ом. 0.8мм Пречник 49-55мм");

            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text== "Оловни Ом. 0.5мм Пречник 22-33мм")
            {
                Nazivkabla = "O0.523-33";
            }
            else if (comboBox1.Text == "Оловни Ом. 0.5мм Пречник 43мм")
            {
                Nazivkabla = "O0.543";
            }
            else if (comboBox1.Text == "Оловни Ом. 0.8мм Пречник 33-45мм")
            {
                Nazivkabla = "O0.833-43.5";
            }
            else if (comboBox1.Text == "Оловни Ом. 0.8мм Пречник 45мм")
            {
                Nazivkabla = "O0.845";
            }
            else if (comboBox1.Text == "Челични Ом. 0.5мм Пречник 15-19мм")
            {
                Nazivkabla = "C0.514-19";
            }
            else if (comboBox1.Text == "Челични Ом. 0.5мм Пречник 24-30мм")
            {
                Nazivkabla = "C0.524-30";
            }
            else if (comboBox1.Text == "Челични Ом. 0.5мм Пречник 34-40мм")
            {
                Nazivkabla = "C0.534-40";
            }
            else if (comboBox1.Text == "Челични Ом. 0.5мм Пречник 45-49мм")
            {
                Nazivkabla = "C0.545-49";
            }
            else if (comboBox1.Text == "Челични Ом. 0.8мм Пречник 15-19мм")
            {
                Nazivkabla = "C0.814-19";
            }
            else if (comboBox1.Text == "Челични Ом. 0.8мм Пречник 24-30мм")
            {
                Nazivkabla = "C0.824-30";
            }
            else if (comboBox1.Text == "Челични Ом. 0.8мм Пречник 40-45мм")
            {
                Nazivkabla = "C00.840-45";
            }
            else if (comboBox1.Text == "Челични Ом. 0.8мм Пречник 49-55мм")
            {
                Nazivkabla = "C0.849-55";
            }
            else if (comboBox1.Text == "Кабал без заштита")
            {
                Nazivkabla = "empty";
            }
            else
            {
                MessageBox.Show("Морате унети неки вид заштите кабла");
            }













            if (Form1.Em > 0)
            {
                E = Form1.Em;
            }
            else
            {
                E = Form1.Ek;
            }
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                putanja = Path.GetFullPath("kablovi.txt");
                if (File.Exists(putanja))
                {
                    linija = File.ReadAllLines(putanja).ToList();
                    foreach (var item in linija)
                    {
                        linije = item.Split(',').ToList();

                        if (linije[0] == Nazivkabla)
                        {
                            nadjen = true;
                            continue;
                        }
                        if (linije[0] != "--K--" && nadjen==true)
                        { 
                            voltf = int.Parse(linije[0]);
                            Volts = double.Parse(linije[1]);
                            if (voltf > E)
                            {
                                Koeficijenta = Volts;
                                break;
                            }if (voltf == 500)
                            {
                                Koeficijenta = Volts;
                                MessageBox.Show(Koeficijenta.ToString());
                                break;

                            }
                        }
                    }
                }else
                    MessageBox.Show("Morate popuniti listbox");



                var obj = new Form1();

                if (radioButton1.Checked)
                {
                    Form1.Ru = 0.45;
                }
                if (radioButton2.Checked)
                {
                    Form1.trafo = true;
                }
                
                Form1.Rk = Koeficijenta;
                if (Form1.Button1_is_clicked)
                {

                    obj.Izracunaj();
                    
                    this.Close();
                   
                    
                }
                else
                {
                    obj.Izracunajk();
                    this.Close();
                }


            }
        }
    }
}
