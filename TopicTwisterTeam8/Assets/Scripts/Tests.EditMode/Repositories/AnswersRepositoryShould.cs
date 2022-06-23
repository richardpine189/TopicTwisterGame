using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tests.Repositories
{
    class AnswersRepositoryShould
    {
        [Test]
        public void SaveAnswersInScriptableObject()
        {
            //Arrenge
            string fileName = "newFileName.asset";
            string[] answers = { "hola", "que", "tal" };
            IAnswersRepository answersRepository = new SOAnswersRepository(fileName);
            //Act
            answersRepository.SaveAnswers(answers);
            //Assert
            Assert.IsTrue(File.Exists($"Assets/Scripts/Tests.EditMode/{fileName}"));
        }
    }
}
