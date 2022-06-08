using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTwister.Assets.Scripts.Models;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Repositories
{
    public class SOAnswersRepository : IAnswersRepository
    {
        private string _fileName;
        private string _path = "Assets/Scripts/Tests.EditMode/";
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


}
