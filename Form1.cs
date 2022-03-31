using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Context context;
        public int count = 0;
        public Form1()
        {
            InitializeComponent();

            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            IOFile.form1 = this;
            BitSorting.form1 = this;
            InsertionSort.form1 = this;
        }

        private void сгенерироватьНаборToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Context.array == null)
            {
                SetGenerator setGenerator = new SetGenerator();
                SetGenerator.form1 = this;
                setGenerator.Show();

                buttonSort.Enabled = true;
            }
            else
            {
                MessageBox.Show("Массив уже сгенерирован. Очистите старый набор и повторите попытку");
            }
        }
        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (Context.array != null)
            {
                if (radioButtonBubbleSort.Checked == true)
                {
                    this.context = new Context(new InsertionSort());
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    IOFile.SaveData();
                    buttonSort.Enabled = false;
                }
                if (radioButton2.Checked == true)
                {
                    this.context = new Context(new BitSorting());
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    IOFile.SaveData();
                    buttonSort.Enabled = false;
                }
                IOFile.content = "";
            }
            else 
            {
                MessageBox.Show("Массив пуст, сортировка невозможна");
            }
        }
        public void AddItemsListBox(int first = -1, int second = -1)
        {
            listBox1.Items.Add("");
            foreach (var item in Context.array)
            {
                if (item == first || item == second)
                {
                    listBox1.Items[count] += '[' + Convert.ToString(item) + ']' + " ";
                }
                else
                {
                    listBox1.Items[count] += Convert.ToString(item) + " ";
                }
            }
            count++;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            buttonSort.Enabled = true;
            listBox1.Items.Clear();
            labelCountComparison.Text = "";
            labelTimeSort.Text = "";
            labelNumberOfPermutations.Text = "";
            ComparativeAnalysis.NumberOfPermutations = 0;
            ComparativeAnalysis.Comparison = 0;
            Context.array = null;
            this.count = 0;
        }

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOFile.LoadData();
        }

        private void выводСтатистикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComparativeAnalysis comparativeAnalysis = new ComparativeAnalysis();
            comparativeAnalysis.Show();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
