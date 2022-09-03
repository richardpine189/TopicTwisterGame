public class GetRandomLetterUseCase : ILetterGetter
{
    public char GetLetter()
    {
        System.Random rnd = new System.Random();
        //char randomChar = (char)rnd.Next('A', 'Z');
        char randomChar = (char)rnd.Next('A', 'E');
        return randomChar;
    }
}

