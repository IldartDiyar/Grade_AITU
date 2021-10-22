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
             for (int j=1+(3*i);j<=3+(3*i);j++)
             {
                if (j%3==0)
                {
                    f = 0.4;
                }
                markus = markus + Convert.ToDouble((this.Controls["textbox" + j].Text))*f;
             }
            return markus;
            }
        private void button2_Click(object sender, EventArgs e)
        {
            int d = comboBox1.SelectedIndex + 1;
            double mark;
            double[] f = new double[5];
            double[] d1 = new double[5];
            for (int i = 1; i <= d; i++)
            {
                f[i] = (Convert.ToDouble((this.Controls["textbox" + (1 + ((i - 1) * 3))].Text)) + Convert.ToDouble((this.Controls["textbox" + (2 + ((i - 1) * 3))].Text))) / 2;
                
                if (!String.IsNullOrEmpty((this.Controls["textbox" + (i*3)].Text)))
                {
                    d1[i] = Convert.ToDouble(this.Controls["textBox" + (i * 3)].Text);
                    if (f[i] > 50 )
                    {
                        if (d1[i] > 25)
                        {
                            mark = calculate(i - 1);
                            if (mark > 70)
                            {
                                Controls["L" + (i * 5)].Text = Convert.ToString(mark);
                            }
                            else
                            {
                                Controls["L" + (i * 5)].Text = "Minus stepuha";
                            }
                        }else
                        {
                            Controls["L" + (i * 5)].Text = "Good Summer";
                        }
                    }else
                    {
                        Controls["L" + (i * 5)].Text = "Good Summer";
                    }
                }
                else
                {
                    this.Controls["textbox" + (i * 3)].Visible = false;
                    this.Controls["libel" + (i)].Visible = true;
                    this.Controls["L" + (i * 5)].Visible = false;
                    
                    if (f[i]<50)
                    {
                        Controls["libel" + (i)].Text = "GOOD summer";
                    } else 
                    {
                        string retake = Convert.ToString((100-f[i]));
                        string stepuha = Convert.ToString((150 - f[i]));
                         this.Controls["libel"+(i)].MaximumSize = new Size(200,int.MaxValue);
                        Controls["libel" + (i)].Text = "Что бы не получить ретейк или пересдачу:  "+retake+
                                " файнале."
                            + " А для сохранения стипендии:"+stepuha+
                            " на файнале";
                    }
                }
            }
           
            
          
        }
    }
}
