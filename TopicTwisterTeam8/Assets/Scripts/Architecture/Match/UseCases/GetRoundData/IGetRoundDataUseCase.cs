public interface IGetRoundDataUseCase
{
    string[] GetCurrentCategories();
    char? GetCurrentLetter();
    string[] GetCurrentAnswers();
    bool[] GetCurrentResults();
    int GetCurrentTime();

}