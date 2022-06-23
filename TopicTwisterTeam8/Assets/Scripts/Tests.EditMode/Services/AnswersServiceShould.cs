using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tests.EditMode.Services
{
    class AnswersServiceShould
    {
        [Test]
        public void SendAnswersToRepository()
        {
            //Arrange
            string[] answers = { "hola", "que", "tal" };
            IAnswersRepository answersRepository = Substitute.For<IAnswersRepository>();
            IAnsweringService answeringService = new AnswersService(answersRepository);
            //Act
            answeringService.SendToRepository(answers);
            //Assert
            answersRepository.Received(1).SaveAnswers(answers);
        }
    }
}
