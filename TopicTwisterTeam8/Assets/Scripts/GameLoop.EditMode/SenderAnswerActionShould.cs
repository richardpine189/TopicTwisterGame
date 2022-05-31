using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class SenderAnswerActionShould
{

    [Test]
    public void SendAnswersToService()
    {
        //Arrange
        string[] answers = { "hola", "que", "tal" };
        IAnsweringService answeringService = Substitute.For<IAnsweringService>();
        IAnswerSender sendAnswersAction = new SendAnswersAction(answeringService);
        //Act
        sendAnswersAction.SendAnswers(answers);
        //Assert
        answeringService.Received(1).SendToRepository(answers);
    }


}

public class SendAnswersAction : IAnswerSender
{
    IAnsweringService _answersService;
    public SendAnswersAction(IAnsweringService answeringService)
    {
        _answersService = answeringService;
    }
    public void SendAnswers(string[] answers)
    {
        _answersService.SendToRepository(answers);
    }
}

public interface IAnsweringService
{
    void SendToRepository(string[] answers);
}