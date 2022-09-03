public class GetRandomLetterUseCase : IGetLetterUseCase
{
    public char Execute()
    {
        System.Random rnd = new System.Random();
        //char randomChar = (char)rnd.Next('A', 'Z');
        char randomChar = (char)rnd.Next('A', 'E');
        return randomChar;
    }
}

