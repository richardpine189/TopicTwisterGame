using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TopicTwister/AnswersFile", fileName = "newAnswersFile")]
public class Answers : ScriptableObject
{
    [SerializeField] private string[] _answersString = new string[5];
    public string[] AnswersString { get => _answersString; set => _answersString = value; }
}
