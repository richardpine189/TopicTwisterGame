namespace Architecture.Letter.UseCase
{
    public class GetRandomLetter : IGetLetterUseCase
    {
        public char Invoke()
        {
        
            System.Random rnd = new System.Random();
            //char randomChar = (char)rnd.Next('A', 'Z');
            char randomChar = (char)rnd.Next('A', 'E');

            return randomChar;
        }
    }
}


