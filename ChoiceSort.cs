using System;

namespace WindowsFormsApp9
{
    public class ChoiceSort : IStrategy
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
                for (var i = 0; i < length - 1; i++)
                {
                    iterationCount++;
                    IOFile.content += iterationCount + " итерация: " + '\n';
                    //поиск минимального числа
                    var min = i;
                    for (var j = i + 1; j < length; j++)
                    {
                        IOFile.InputInfoAboutComparison(arrayForSort[j], arrayForSort[min]);
                        ComparativeAnalysis.Comparison++;
                        form1.AddItemsListBox(arrayForSort[j], arrayForSort[min]);
                        if (arrayForSort[j] < arrayForSort[min])
                        {
                            min = j;
                        }
                    }
                    IOFile.InputInfoAboutTransposition(arrayForSort[min], arrayForSort[i]);
                    //обмен элементов
                    (arrayForSort[min], arrayForSort[i]) = (arrayForSort[i], arrayForSort[min]);
                    ComparativeAnalysis.NumberOfPermutations++;
                    IOFile.FillContent();
                }
                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed.TotalSeconds;
                var elapsedTime = $"{resultTime}";
                form1.labelCountComparison.Text = Convert.ToString(ComparativeAnalysis.Comparison);
                form1.labelNumberOfPermutations.Text = Convert.ToString(ComparativeAnalysis.NumberOfPermutations);
                form1.labelTimeSort.Text = elapsedTime;
            }
            else
            {
                myStopwatch.Start();
                for (var i = 0; i < length - 1; i++)
                {
                    //поиск минимального числа
                    var min = i;
                    for (var j = i + 1; j < length; j++)
                    {
                        ComparativeAnalysis.Comparison++;
                        if (arrayForSort[j] < arrayForSort[min])
                        {
                            min = j;
                        }
                    }
                    //обмен элементов
                    (arrayForSort[min], arrayForSort[i]) = (arrayForSort[i], arrayForSort[min]);
                    ComparativeAnalysis.NumberOfPermutations++;
                }
                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed.TotalSeconds;
                var elapsedTime = $"{resultTime}";
                ComparativeAnalysis.timeSort = resultTime;
                ComparativeAnalysis.elapsedTime = elapsedTime;
            }

            return arrayForSort;
        }
    }
}