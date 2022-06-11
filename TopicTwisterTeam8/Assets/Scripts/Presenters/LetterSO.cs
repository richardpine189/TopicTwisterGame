using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TopicTwister/Letter", fileName = "newLetter")]
public class LetterSO : ScriptableObject
{
    public char _letter;

    public char Letter { get => _letter; set => _letter = value; }
}
