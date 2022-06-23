
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;


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
