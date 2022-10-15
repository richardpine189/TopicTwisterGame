using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Installer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void Init()
    {
        //IAnswersRepository _answerRepository;
        
        //ServiceLocator.Instance.RegisterService<IMatchRepository>(new JsonMatchServiceRepository());

        //ServiceLocator.Instance.RegisterService<ICurrentMatchService>(new SingletonCurrentMatchService());
    }
}
