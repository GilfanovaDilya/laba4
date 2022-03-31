using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class InsertionSort : IStrategy
    {
        public int iterationCount;
        public static Form1 form1;
        
        public int[] Algorithm(int[] arrayForSort, bool flag = true)
        {
            var myStopwatch = new System.Diagnostics.Stopwatch();
            int newElement, location;
            var length = arrayForSort.Length;

            if (flag)
            {
                IOFile.FillContent();
                myStopwatch.Start();
                for (var i = 1; i < length; i++)
                {
                    iterationCount++;
                    IOFile.content += iterationCount + " итерация: " + '\n';
                    newElement = arrayForSort[i];
                    location = i - 1;
                    while (location >= 0 && arrayForSort[location] > newElement)
                    {
                        IOFile.InputInfoAboutComparison(arrayForSort[location], newElement);
                        ComparativeAnalysis.Comparison++;

                        IOFile.InputInfoAboutTransposition(arrayForSort[location + 1], arrayForSort[location]);
                        ComparativeAnalysis.NumberOfPermutations++;

                        form1.AddItemsListBox(arrayForSort[location + 1], arrayForSort[location]);

                        arrayForSort[location + 1] = arrayForSort[location];
                        location -= 1;
                    }
                    IOFile.FillContent();
                    arrayForSort[location + 1] = newElement;
                }

                myStopwatch.Stop();
                var resultTime = myStopwatch.ElapsedTicks;
                var elapsedTime =
                    $"{resultTime}";
                form1.labelCountComparison.Text = Convert.ToString(ComparativeAnalysis.Comparison);
                form1.labelNumberOfPermutations.Text = Convert.ToString(ComparativeAnalysis.NumberOfPermutations);
                form1.labelTimeSort.Text = elapsedTime;
            }
            else
            {
                myStopwatch.Start();
                for (var i = 1; i < length; i++)
                {
                    newElement = arrayForSort[i];
                    location = i - 1;
                    while (location >= 0 && arrayForSort[location] > newElement)
                    {
                        ComparativeAnalysis.Comparison++;
                        arrayForSort[location + 1] = arrayForSort[location];
                        location -= 1;
                        ComparativeAnalysis.NumberOfPermutations++;
                    }
                    arrayForSort[location + 1] = newElement;
                }

                myStopwatch.Stop();
                var resultTime = myStopwatch.ElapsedTicks;
                var elapsedTime =
                    $"{resultTime}";
                ComparativeAnalysis.timeSort = resultTime;
                ComparativeAnalysis.elapsedTime = elapsedTime;
            }
            return arrayForSort;
        }
    }
}