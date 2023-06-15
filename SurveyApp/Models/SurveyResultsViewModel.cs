namespace SurveyApp.Models
{
    public class SurveyResultsViewModel
    {
        public int TotalSurveys { get; set; }
        public double AverageAge { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
        public double PizzaPercentage { get; set; }
        public double PastaPercentage { get; set; }
        public double PapWorsPercentage { get; set; }
        public double EatOutRatingAverage { get; set; }
        public double WatchMoviesRatingAverage { get; set; }
        public double WatchTVRatingAverage { get; set; }
        public double ListenToRadioRatingAverage { get; set; }
    }
}
