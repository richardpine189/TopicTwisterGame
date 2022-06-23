
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEditor;
using UnityEngine;


    public class SOAnswersRepository : IAnswersRepository
    {
        private string _fileName;
        private string _path = "Assets/Scripts/";
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

