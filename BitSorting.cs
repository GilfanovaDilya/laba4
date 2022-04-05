using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class BitSorting : IStrategy
    {
        public int iterationCount = 0;
        public static Form1 form1;

        public int[] Algorithm(int[] array, bool flag = true)
        {
            int range = 10,
                length = array.ToList().Max().ToString().Length;
            var lists = new ArrayList[range];
            for (var i = 0; i < range; ++i) lists[i] = new ArrayList();

            var myStopwatch = new System.Diagnostics.Stopwatch();
            if (flag)
            {
                IOFile.FillContent();
                myStopwatch.Start();

                for (var step = 0; step < length; ++step)
                {
                    foreach (var element in array)
                    {
                        ComparativeAnalysis.Comparison++;
                        lists[(element % (int) Math.Pow(range, step + 1)) / (int) Math.Pow(range, step)].Add(element);
                    }
                    var k = 0;
                    for (var i = 0; i < range; ++i)
                    {
                        iterationCount++;
                        IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                        for (var j = 0; j < lists[i].Count; ++j)
                        {
                            IOFile.InputInfoAboutTransposition(array[k], (int)lists[i][j]);
                            form1.AddItemsListBox(array[k], (int)lists[i][j]);

                            array[k++] = (int) lists[i][j];
                            ComparativeAnalysis.NumberOfPermutations++;
                        }
                        IOFile.FillContent();
                    }

                    for (var i = 0; i < range; ++i)
                        lists[i].Clear();
                }

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

                for (var step = 0; step < length; ++step)
                {
                    foreach (var element in array)
                    {
                        ComparativeAnalysis.Comparison++;
                        lists[(element % (int)Math.Pow(range, step + 1)) / (int)Math.Pow(range, step)].Add(element);
                    }
                    var k = 0;
                    for (var i = 0; i < range; ++i)
                    {
                        iterationCount++;
                        for (var j = 0; j < lists[i].Count; ++j)
                        {
                            array[k++] = (int)lists[i][j];
                            ComparativeAnalysis.NumberOfPermutations++;
                        }
                    }

                    for (var i = 0; i < range; ++i)
                        lists[i].Clear();
                }

                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed.TotalSeconds;

                var elapsedTime = $"{resultTime}";
                ComparativeAnalysis.timeSort = resultTime;
                ComparativeAnalysis.elapsedTime = elapsedTime;
                return array;
            }
        }
    }
}