using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class AnswersServiceShould
{
    
    [Test]
    public void SendAnswersToRepository()
    {
        //Arrange
        string[] answers = { "hola", "que", "tal" };
        IAnswersRepository answersRepository= Substitute.For<IAnswersRepository>();
        IAnsweringService answeringService = new AnswersService(answersRepository);
        //Act
        answeringService.SendToRepository(answers);
        //Assert
        answersRepository.Received(1).SaveAnswers(answers);
    }
}
public class AnswersService : IAnsweringService
{
    IAnswersRepository _answersRepository;
    public AnswersService(IAnswersRepository answersRepository)
    {
        _answersRepository = answersRepository;
    }
    public void SendToRepository(string[] answers)
    {
        _answersRepository.SaveAnswers(answers);
    }
}

public interface IAnswersRepository
{
    void SaveAnswers(string[] answers);
}