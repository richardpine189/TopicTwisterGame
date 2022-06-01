using System.IO;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

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
        Assert.IsTrue(File.Exists($"Assets/Scripts/GameLoop.EditMode/{fileName}"));
    }

}

public class SOAnswersRepository : IAnswersRepository
{
    private string _fileName;
    private string _path = "Assets/Scripts/GameLoop.EditMode/";
    private Answers _answersScriptable;
    public SOAnswersRepository(string fileName)
    {
        _fileName = fileName;
    }
    public void SaveAnswers(string[] answers)
    {
        _answersScriptable = ScriptableObject.CreateInstance<Answers>();
        _answersScriptable.AnswersString = answers;
        AssetDatabase.CreateAsset(_answersScriptable, _path + _fileName);
    }
}

public class JsonAnswersRepository : IAnswersRepository
{
    private string _fileName;
    private string _path = "Assets/Scripts/GameLoop.EditMode/";
    private Answers _answersScriptable;
    public JsonAnswersRepository(string fileName)
    {
        _fileName = fileName;
    }
    public void SaveAnswers(string[] answers)
    {
        _answersScriptable = ScriptableObject.CreateInstance<Answers>();
        _answersScriptable.AnswersString = answers;
        AssetDatabase.CreateAsset(_answersScriptable, _path + _fileName);
    }
}