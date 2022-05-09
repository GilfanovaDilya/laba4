namespace WindowsFormsApp9
{
    public class SortingResultsInformation
    {
        public long Comparison = 0;

        public long NumberOfPermutations = 0;

        public double TimeSort = 0;

        public int Volume = 0;

        public string Time = string.Empty;

        public IStrategy Strategy;

        public string NameSortingMethod;

        public SortingResultsInformation(
            long Comparison,
            long NumberOfPermutations,
            string Time,
            IStrategy Strategy,
            double TimeSort,
            int Volume)
        {
            this.Comparison = Comparison;
            this.NumberOfPermutations = NumberOfPermutations;
            this.Time = Time;
            this.Strategy = Strategy;
            this.NameSortingMethod = Strategy.GetType() == (new InsertionSort()).GetType()
                                         ? "Метод вставки"
                                         : "Метод быстрой сортировки";
            this.TimeSort = TimeSort;
            this.Volume = Volume;
        }

        public SortingResultsInformation()
        {
        }
    }
}