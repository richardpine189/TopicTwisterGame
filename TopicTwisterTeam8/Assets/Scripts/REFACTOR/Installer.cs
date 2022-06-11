using Assets.Scripts.Actions;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Repositories;
using Assets.Scripts.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] ServiceLocator servicesLocatorInstance;
    
    
    
    void Start()
    {
        IAnswerSender _answerSender;
        IAnsweringService _answeringService;
        IAnswersRepository _answerRepository;
        

        var fileName = "pruebaSO.asset";

        _answerRepository = new SOAnswersRepository(fileName);
        servicesLocatorInstance.RegisterService<IAnswersRepository>(_answerRepository);

        _answeringService = new AnswersService(servicesLocatorInstance.GetService<IAnswersRepository>());
        servicesLocatorInstance.RegisterService<IAnsweringService>(_answeringService);

        _answerSender = new SendAnswersAction(servicesLocatorInstance.GetService<IAnsweringService>());
        servicesLocatorInstance.RegisterService<IAnswerSender>(_answerSender);
        
    }
}
