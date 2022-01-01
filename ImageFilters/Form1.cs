using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZGraphTools;

namespace ImageFilters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        byte[,] ImageMatrix;
        int N;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            }

            
        }

        private void btnZGraph_Click(object sender, EventArgs e)
        {
            double[] x_values = new double[N/2];
            double[] y_values_Count = new double[N/2];
            double[] y_values_Quick = new double[N/2];
            adaptive_median_filter a = new adaptive_median_filter();
            int index = 0;
            for (int i = 3; i <= N; i+=2)
            {
                x_values[index] = i;
                index++;
            }
            index = 0;
            for (int i = 3; i<= N;i+=2)
            {
                int Time_Befor = System.Environment.TickCount;
                a.NewImage(ImageMatrix, N, 1);
                int Time_After = System.Environment.TickCount;
                y_values_Count[index] = Time_After - Time_Befor;
                index++;
            }
            index = 0;
            for (int i = 3; i <= N; i += 2)
            {
                int Time_Befor = System.Environment.TickCount;
                a.NewImage(ImageMatrix, N, 0);
                int Time_After = System.Environment.TickCount;
                y_values_Quick[index] = Time_After - Time_Befor;
                index++;
            }
            //Create a graph and add two curves to it
            ZGraphForm ZGF = new ZGraphForm("Sample Graph", "N", "f(N)");
            ZGF.add_curve("f(N) = Quick Sort", x_values, y_values_Quick,Color.Red);
            ZGF.add_curve("f(N) = Count Sort", x_values, y_values_Count, Color.Blue);
            ZGF.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TB_T_TextChanged(object sender, EventArgs e)
        {

        }

        private void CB_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_Sort.Items.Clear();
            if (CB_type.Text == "Alpha-trim filter")
            {
                CB_Sort.Items.AddRange(new object[] {
                "Count Sort",
                "Without Sort"});
                label2.Text = "N";
                label1.Visible = true;
                label2.Visible = true;
                TB_N.Visible = true;
                TB_T.Visible = true;
            }
            else if (CB_type.Text == "Adaptive median filter")
            {
                CB_Sort.Items.AddRange(new object[] {
                "Quick Sort",
                "Count Sort"});
                label1.Visible = false;
                TB_T.Visible= false;
                label2.Text = "Max N";
                label2.Visible= true;
                TB_N.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Filter_Type = CB_type.Text;
            N = Int16.Parse(TB_N.Text);
            if (N % 2 != 0)
            {
                if (Filter_Type == "Alpha-trim filter")
                {
                    int T = Int16.Parse(TB_T.Text);
                    Alpha_trim_filter a = new Alpha_trim_filter();
                    byte[,] newMatrix = a.NewImage(ImageMatrix, T, N);
                    ImageOperations.DisplayImage(newMatrix, pictureBox2);
                }
                else if (Filter_Type == "Adaptive median filter")
                {
                    adaptive_median_filter a = new adaptive_median_filter();
                    byte[,] newMatrix = a.NewImage(ImageMatrix, N, CB_Sort.SelectedIndex);
                    ImageOperations.DisplayImage(newMatrix, pictureBox2);


                }
            }
            else
                MessageBox.Show("Enter Odd Number in N Text Box!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            ImageMatrix = null;
        }
    }
}