
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class SendAnswersActionShould
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

