using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp9
{
    public class QuickSort : IStrategy
    {
        public int iterationCount = 0;
        public static Form1 form1;

        public int[] Algorithm(int[] array, bool flag = true)
        {
            var myStopwatch = new System.Diagnostics.Stopwatch();
            if (flag)
            {
                IOFile.FillContent();
                myStopwatch.Start();

                QuickSortOpen(array, 0, array.Length - 1);

                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed.TotalSeconds;

                var elapsedTime = $"{resultTime}";

                form1.labelCountComparison.Text = Convert.ToString(ComparativeAnalysis.Comparison);
                form1.labelNumberOfPermutations.Text = Convert.ToString(ComparativeAnalysis.NumberOfPermutations);
                form1.labelTimeSort.Text = elapsedTime;
                return array;
            }
            else
            {
                myStopwatch.Start();

                QuickSortClosed(array, 0, array.Length - 1);

                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed.TotalSeconds;

                var elapsedTime = $"{resultTime}";
                ComparativeAnalysis.timeSort = resultTime;
                ComparativeAnalysis.elapsedTime = elapsedTime;
                return array;
            }
        }

        private void QuickSortOpen(IList<int> array, int a, int b)
        {
            var i = a;
            var j = b;
            var middle = array[(a + b) / 2];

            iterationCount++;
            IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
            while (i <= j)
            {
                while (array[i] < middle)
                {
                    ComparativeAnalysis.Comparison++;
                    i++;
                }

                while (array[j] > middle)
                {
                    ComparativeAnalysis.Comparison++;
                    j--;
                }

                if (i > j) continue;
                IOFile.InputInfoAboutTransposition(array[i], array[j]);
                form1.AddItemsListBox(array[i], array[j]);

                (array[i], array[j]) = (array[j], array[i]);
                ComparativeAnalysis.NumberOfPermutations++;

                i++;
                j--;
            }

            IOFile.FillContent();
            if (a < j)
            {
                QuickSortOpen(array, a, j);
            }

            if (i < b)
            {
                QuickSortOpen(array, i, b);
            }
        }
        private void QuickSortClosed(IList<int> array, int a, int b)
        {
            var i = a;
            var j = b;
            var middle = array[(a + b) / 2];
            while (i <= j)
            {
                while (array[i] < middle)
                {
                    ComparativeAnalysis.Comparison++;
                    i++;
                }

                while (array[j] > middle)
                {
                    ComparativeAnalysis.Comparison++;
                    j--;
                }

                if (i > j) continue;
                (array[i], array[j]) = (array[j], array[i]);
                ComparativeAnalysis.NumberOfPermutations++;
                i++;
                j--;
            }

            if (a < j)
            {
                QuickSortClosed(array, a, j);
            }

            if (i < b)
            {
                QuickSortClosed(array, i, b);
            }
        }
    }
}