using System.IO;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AnswersRepositoryShould
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
        Assert.IsTrue(File.Exists($"../Assets/Scripts/Answers/{fileName}"));
    }

}

public class SOAnswersRepository : IAnswersRepository
{
    string _fileName;
    public SOAnswersRepository(string fileName)
    {
        _fileName = fileName;
    }
    public void SaveAnswers(string[] answers)
    {
        throw new System.NotImplementedException();
    }
}