using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRADE_AITU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {

            int d = comboBox1.SelectedIndex + 1;
            for (int i = 1; i <= d * 5; i++)
            {
                this.Controls["L" + i].Visible = true;
            }
            for (int i = 1; i <= d * 3; i++)
            {
                this.Controls["textbox" + i].Visible = true;
            }

        }

        public double calculate(int i)
        {
            double markus = 0;
            double f = 0.3;
            for (int j = 1 + (3 * i); j <= 3 + (3 * i); j++)
            {
                if (j % 3 == 0)
                {
                    f = 0.4;
                }
                markus = markus + Convert.ToDouble((this.Controls["textbox" + j].Text)) * f;
            }
            return markus;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int d = comboBox1.SelectedIndex + 1;
            double mark;
            double[] f1 = new double[5];
            double[] f2 = new double[5];
            double[] d1 = new double[5];
           
            for (int i = 1; i <= d; i++)
            {
                f1[i] = Convert.ToDouble(this.Controls["textbox" + (1 + ((i - 1) * 3))].Text);
                    f2[i] = Convert.ToDouble(this.Controls["textbox" + (2 + ((i - 1) * 3))].Text);

                    if (f1[i] >= 0 && f1[i] <= 100 && f2[i] >= 0 && f2[i] <= 100)
                    {
                        if (!String.IsNullOrEmpty((this.Controls["textbox" + (i * 3)].Text)))
                        {
                            d1[i] = Convert.ToDouble(this.Controls["textBox" + (i * 3)].Text);
                            if (d1[i] >= 0 && d1[i] <= 100)
                            {
                                if (f1[i] >= 25 && f2[i] >= 25 && d1[i] >= 50)
                                {

                                    mark = calculate(i - 1);
                                    if (mark >= 70)
                                    {

                                        Controls["L" + (i * 5)].Text = Convert.ToString(mark);
                                    }
                                    else
                                    {
                                        Controls["L" + (i * 5)].Text = "Minus stepuha";
                                    }
                                }
                                else
                                {
                                    Controls["L" + (i * 5)].Text = "Good Summer";
                                }
                            }
                            else
                            {
                                MessageBox.Show("оценка меньше 100 или больше 0");
                            }
                        }
                        else
                        {
                            this.Controls["textbox" + (i * 3)].Visible = false;
                            this.Controls["libel" + (i)].Visible = true;
                            this.Controls["L" + (i * 5)].Visible = false;

                            if (f1[i] >= 50 && f2[i] >= 50)
                            {
                                this.Controls["libel" + (i)].MaximumSize = new Size(360, int.MaxValue);
                                double r1 = 50 - ((f1[i] * 0.3) + (f2[i] * 0.3));
                                double r2 = 70 - ((f1[i] * 0.3) + (f2[i] * 0.3));
                                double r3 = 90 - ((f1[i] * 0.3) + (f2[i] * 0.3));
                                r1 = (r1 / 0.4) >= 50 ? r1 = (r1 / 0.4) : r1 = 50;
                                r2 = (r2 / 0.4) >= 50 ? r2 = (r2 / 0.4) : r2 = 50;
                                r3 = (r3 / 0.4) <= 100 ? r3 = (r3 / 0.4) : r3 = 0;

                                this.Controls["libel" + (i)].Text = "Что бы не получить ретейк или пересдачу " + Convert.ToString(r1) + ". Для сохранения стипендии " + Convert.ToString(r2) + ". А Для получения повышенной стипендии " + Convert.ToString(r3);
                            }
                            else
                            {
                                Controls["libel" + (i)].Text = "Good summer";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("оценка меньше 100 или больше 0");
                    }
                
            }



        }

        private void libel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int d = comboBox1.SelectedIndex + 1;
            for (int i = 1; i <= d * 5; i++)
            {
                this.Controls["L" + i].Visible = false;
            }
            for (int i = 1; i <= d * 3; i++)
            {   
                this.Controls["textbox" + i].Visible = false;
            }
            for (int i = 1; i <= d; i++)
            {
                this.Controls["libel" + i].Visible = false;
            }
        }
    }
}
