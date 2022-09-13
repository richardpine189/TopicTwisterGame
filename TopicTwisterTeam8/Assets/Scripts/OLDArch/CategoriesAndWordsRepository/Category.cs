using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "TopicTwister/Category",fileName = "newCategory")]
public class Category : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private List<string> words;

    public string Name { get => _name; private set => _name = value; }
    public List<string> Words { get => words; set => words = value; }

    public bool ExisistInCategory(string word, char letter)
    {
        //return words.Any(x => x.ToUpper() == word.ToUpper());
            
        for (int i = 0; i < Words.Count; i++)
        {
            if (string.Equals(word.ToUpper(), Words[i].ToUpper()) && word.ToUpper().StartsWith(letter.ToString().ToUpper()))
            {
                return true;
            }
        }

        return false;
    }
}

