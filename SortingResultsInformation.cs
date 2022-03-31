using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    public class SortingResultsInformation
    {
        public long Comparison = 0;
        public long NumberOfPermutations = 0;
        public int TimeSort = 0;
        public int Volume = 0;
        public string Time = "";
        public IStrategy Strategy;
        public string NameSortingMethod;

        public SortingResultsInformation(long Comparison, long NumberOfPermutations, string Time, IStrategy Strategy, int TimeSort, int Volume)
        {
            this.Comparison = Comparison;
            this.NumberOfPermutations = NumberOfPermutations;
            this.Time = Time;
            this.Strategy = Strategy;
            if(Strategy.GetType() == (new InsertionSort()).GetType())
            {
                this.NameSortingMethod = "Метод обмена";
            }
            else
            {
                this.NameSortingMethod = "Метод Шелла";
            }
            this.TimeSort = TimeSort;
            this.Volume = Volume;
        }

        public SortingResultsInformation()
        {

        }
    }
}
