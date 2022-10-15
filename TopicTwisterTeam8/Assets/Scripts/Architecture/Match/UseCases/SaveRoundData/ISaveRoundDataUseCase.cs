namespace Architecture.Match.UseCases.SaveRoundData
{
    public interface ISaveRoundDataUseCase
    {
        void SaveLetter(char letter);
        void SaveCurrentCategories(string[] categories);
        void SaveCurrentAnswers(string[] answers);
        void SaveCurrentResults(bool[] results);
        void SaveCurrentTime(int time);
    }
}