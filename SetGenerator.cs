using System;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class SetGenerator : Form
    {
        private readonly Random _random = new Random();
        public static Form1 form1;
        public SetGenerator()
        {
            InitializeComponent();
            label2.Text = "";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBoxCountElements.Text = Convert.ToString(trackBar1.Value);
        }

        private void textBoxCountElements_TextChanged(object sender, EventArgs e)
        {
            if (!(int.TryParse(textBoxCountElements.Text, out _)))
            {
                label2.Text = "Введенно некорректное значение.";
                this.Height = 200;
                trackBar1.Value = trackBar1.Minimum;
            }
            else if ((int.Parse(textBoxCountElements.Text) > trackBar1.Maximum) || (int.Parse(textBoxCountElements.Text) < trackBar1.Minimum))
            {
                label2.Text = "Введенное значение вышло \nза допустимый интервал.";
                this.Height = 225;
                trackBar1.Value = trackBar1.Minimum;
            }
            else if (!(int.Parse(textBoxCountElements.Text) > trackBar1.Maximum))
            {
                label2.Text = ""; 
                this.Height = 200;
                trackBar1.Value = int.Parse(textBoxCountElements.Text);
            }
            
        }

        private void buttonCreateArray_Click(object sender, EventArgs e)
        {
            Context.array = new int[trackBar1.Value];
            for (var i = 0; i < Context.array.Length; i++)
            {
                Context.array[i] = _random.Next(0, 1000);
            }

            form1.listBox1.Items.Add("");
            foreach (var item in Context.array)
            {
                form1.listBox1.Items[form1.count] += Convert.ToString(item) + " ";
            }
            form1.count++;

            this.Close();
        }
    }
}
