using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class BubbleSort : IStrategy
    {
        public int iterationCount = 0;
        public static Form1 form1;
        public int[] Algorithm(int[] mas, bool flag = true)
        {
            if (flag)
            {
                IOFile.FillContent();
                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();
                int temp;
                for (int i = 0; i < mas.Length; i++)
                {
                    for (int j = i + 1; j < mas.Length; j++)
                    {
                        this.iterationCount++;
                        IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                        IOFile.InputInfoAboutComparison(mas[i], mas[j]);
                        ComparativeAnalysis.Comparison++;
                        if (mas[i] > mas[j])
                        {
                            IOFile.InputInfoAboutTransposition(mas[i], mas[j]);
                            temp = mas[i];
                            mas[i] = mas[j];
                            mas[j] = temp;
                            ComparativeAnalysis.NumberOfPermutations++;

                            IOFile.FillContent();
                            form1.AddItemsListBox(mas[i], mas[j]);
                        }
                    }
                }
                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    resultTime.Hours,
                    resultTime.Minutes,
                    resultTime.Seconds,
                    resultTime.Milliseconds);
                form1.labelCountComparison.Text = Convert.ToString(ComparativeAnalysis.Comparison);
                form1.labelNumberOfPermutations.Text = Convert.ToString(ComparativeAnalysis.NumberOfPermutations);
                form1.labelTimeSort.Text = elapsedTime;
                return mas;
            }
            else
            {
                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();
                int temp;
                for (int i = 0; i < mas.Length; i++)
                {
                    for (int j = i + 1; j < mas.Length; j++)
                    {
                        ComparativeAnalysis.Comparison++;
                        if (mas[i] > mas[j])
                        {
                            temp = mas[i];
                            mas[i] = mas[j];
                            mas[j] = temp;
                            ComparativeAnalysis.NumberOfPermutations++;
                        }
                    }
                }
                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    resultTime.Hours,
                    resultTime.Minutes,
                    resultTime.Seconds,
                    resultTime.Milliseconds);
                ComparativeAnalysis.timeSort = resultTime.Seconds * 1000 + resultTime.Milliseconds;
                ComparativeAnalysis.elapsedTime = elapsedTime;
                return mas;
            }
            }
    }
}
