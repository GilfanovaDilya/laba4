using System;
using System.Collections;
using System.Collections.Generic;
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
            ArrayList[] lists = new ArrayList[range];
            for (int i = 0; i < range; ++i) lists[i] = new ArrayList();

            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            if (flag)
            {
                IOFile.FillContent();
                myStopwatch.Start();

                for (int step = 0; step < length; ++step)
                {
                   
                    //распределение по спискам
                    foreach (var element in array)
                    {
                        lists[(element % (int) Math.Pow(range, step + 1)) / (int) Math.Pow(range, step)].Add(element);
                    }

                    //сборка
                    int k = 0;
                    for (int i = 0; i < range; ++i)
                    {
                        iterationCount++;
                        IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                        for (int j = 0; j < lists[i].Count; ++j)
                        {
                            IOFile.InputInfoAboutTransposition(array[k], (int)lists[i][j]);
                            array[k++] = (int) lists[i][j];
                            ComparativeAnalysis.NumberOfPermutations++;
                        }
                        IOFile.FillContent();
                    }

                    for (int i = 0; i < range; ++i)
                        lists[i].Clear();
                }


                //for (step = array.Length / 2; step > 0; step /= 2)
                //{
                //    for (i = step; i < array.Length; i++)
                //    {
                //        iterationCount++;
                //        IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                //        tmp = array[i];
                //        for (j = i; j >= step; j -= step)
                //        {
                //            IOFile.InputInfoAboutComparison(tmp, array[j - step]);
                //            ComparativeAnalysis.Comparison++;
                //            if (tmp < array[j - step])
                //            {
                //                IOFile.InputInfoAboutTransposition(tmp, array[j - step]);
                //                array[j] = array[j - step];
                //                ComparativeAnalysis.NumberOfPermutations++;
                //            }
                //            else
                //            {
                //                break;
                //            }
                //        }

                //        array[j] = tmp;

                //        IOFile.FillContent();
                //        form1.AddItemsListBox(array[i], array[j]);
                //    }
                //}

                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed;

                string elapsedTime =
                    $"{resultTime.Hours:00}:{resultTime.Minutes:00}:{resultTime.Seconds:00}.{resultTime.Milliseconds:000}";

                form1.labelCountComparison.Text = Convert.ToString(ComparativeAnalysis.Comparison);
                form1.labelNumberOfPermutations.Text = Convert.ToString(ComparativeAnalysis.NumberOfPermutations);
                form1.labelTimeSort.Text = elapsedTime;
                return array;
            }
            else
            {
                myStopwatch.Start();

                for (int step = 0; step < length; ++step)
                {

                    //распределение по спискам
                    foreach (var element in array)
                    {
                        ComparativeAnalysis.Comparison++;
                        lists[(element % (int)Math.Pow(range, step + 1)) / (int)Math.Pow(range, step)].Add(element);
                    }

                    //сборка
                    int k = 0;
                    for (int i = 0; i < range; ++i)
                    {
                        iterationCount++;
                        for (int j = 0; j < lists[i].Count; ++j)
                        {
                            array[k++] = (int)lists[i][j];
                            ComparativeAnalysis.NumberOfPermutations++;
                        }
                    }

                    for (int i = 0; i < range; ++i)
                        lists[i].Clear();
                }


                //for (step = array.Length / 2; step > 0; step /= 2)
                //{
                //    for (i = step; i < array.Length; i++)
                //    {
                //        iterationCount++;
                //        tmp = array[i];
                //        for (j = i; j >= step; j -= step)
                //        {
                //            ComparativeAnalysis.Comparison++;
                //            if (tmp < array[j - step])
                //            {
                //                array[j] = array[j - step];
                //                ComparativeAnalysis.NumberOfPermutations++;
                //            }
                //            else
                //            {
                //                break;
                //            }
                //        }

                //        array[j] = tmp;
                //    }
                //}

                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed;

                string elapsedTime =
                    $"{resultTime.Hours:00}:{resultTime.Minutes:00}:{resultTime.Seconds:00}.{resultTime.Milliseconds:000}";
                ComparativeAnalysis.timeSort = resultTime.Seconds * 1000 + resultTime.Milliseconds;
                ComparativeAnalysis.elapsedTime = elapsedTime;
                return array;
            }
        }
    }
}