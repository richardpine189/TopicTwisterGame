using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Installer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void Init()
    {
        IAnswersRepository _answerRepository;
        
        var fileName = "pruebaSO.asset";

        _answerRepository = new SOAnswersRepository(fileName);
        ServiceLocator.Instance.RegisterService<IAnswersRepository>(_answerRepository);

        ServiceLocator.Instance.RegisterService<IMatchRepository>(new JsonMatchRepository());

        ServiceLocator.Instance.RegisterService<ICurrentMatchService>(new SingletonCurrentMatchService());


    }
}
