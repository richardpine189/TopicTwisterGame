public class GetRandomLetterUseCase : IGetLetterUseCase
{
    //Inyectar
    public char Execute()
    {
        
        //COMBROBAR
        
        System.Random rnd = new System.Random();
        //char randomChar = (char)rnd.Next('A', 'Z');
        char randomChar = (char)rnd.Next('A', 'E');
        
        //OBTENEMOS
        
        return randomChar;
    }
}

public class GetLetter
{
    
}

