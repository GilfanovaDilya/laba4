using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class ComparativeAnalysis : Form
    {
        private readonly Random _random = new Random();
        public static long Comparison = 0;
        public static long NumberOfPermutations = 0;
        public static string elapsedTime = "";
        public static double timeSort = 0;
        public static List<SortingResultsInformation> sortingResults = new List<SortingResultsInformation>();
        private Context _context = new Context();

        public ComparativeAnalysis()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Volume", "Объем выборки");
            dataGridView1.Columns.Add("InsertionSort", "Метод вставки");
            dataGridView1.Columns.Add("BitSorting", "Метод поразрядной сортировки");
            dataGridView1.Rows.Add("10");
            dataGridView1.Rows.Add("100");
            dataGridView1.Rows.Add("1000");
            dataGridView1.Rows.Add("10000");
            dataGridView1.Rows.Add("100000");
            for (var i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].ReadOnly = true;
            }

            label1.Text = "";
            label2.Text = "";
        }

        private void FillArray(int[] vs)
        {
            for (var i = 0; i < vs.Length; i++)
            {
                vs[i] = _random.Next(0, 100000);
            }
        }

        private void Sort(int n, int number)
        {
            this._context = new Context(new InsertionSort());
            Context.array = new int[n];
            FillArray(Context.array);
            _context.ExecuteAlgorithm(false);
            dataGridView1.Rows[number].Cells[1].Value += "С: " + Comparison + " ";
            dataGridView1.Rows[number].Cells[1].Value += "П: " + NumberOfPermutations + " ";
            dataGridView1.Rows[number].Cells[1].Value += "t: " + elapsedTime;
            sortingResults.Add(new SortingResultsInformation(Comparison, NumberOfPermutations, elapsedTime, new InsertionSort(), timeSort, n));
            Comparison = 0;
            NumberOfPermutations = 0;
            timeSort = 0;
            elapsedTime = "";
            Context.array = null;

            this._context = new Context(new BitSorting());
            Context.array = new int[n];
            FillArray(Context.array);
            _context.ExecuteAlgorithm(false);
            dataGridView1.Rows[number].Cells[2].Value += "С: " + Comparison + " ";
            dataGridView1.Rows[number].Cells[2].Value += "П: " + NumberOfPermutations + " ";
            dataGridView1.Rows[number].Cells[2].Value += "t: " + elapsedTime;
            sortingResults.Add(new SortingResultsInformation(Comparison, NumberOfPermutations, elapsedTime, new BitSorting(), timeSort, n));
            Comparison = 0;
            NumberOfPermutations = 0;
            timeSort = 0;
            elapsedTime = "";
            Context.array = null;
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 5; i++)
            {
                for (var j = 1; j < 3; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }

            Sort(10, 0);
            Sort(100, 1);
            Sort(1000, 2);
            Sort(10000, 3);
            Sort(100000, 4);

            var maxElement = sortingResults.Where(elementsForMax =>
                elementsForMax.Comparison ==
                sortingResults.Select(selectingElements => selectingElements.Comparison).Max()).ToList()[0];
            var minElement = sortingResults.Where(elementsForMin =>
                elementsForMin.Comparison ==
                sortingResults.Select(selectingElements => selectingElements.Comparison).Min()).ToList()[0];
            label1.Text = maxElement.NameSortingMethod + " с количеством сраненений равным " + maxElement.Comparison +
                          " дает худшие показатели трудоемкости сортировки\n для массива с количеством элементов равным " +
                          maxElement.Volume + ".";
            label2.Text = minElement.NameSortingMethod + " с количеством сраненений равным " + minElement.Comparison +
                          " дает лучшие показатели трудоемкости сортировки\n для массива с количеством элементов равным " +
                          minElement.Volume + ".";

            sortingResults.Clear();
        }
    }
}