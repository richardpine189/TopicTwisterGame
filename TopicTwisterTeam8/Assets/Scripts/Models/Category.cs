using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    [CreateAssetMenu(menuName = "TopicTwister/Category",fileName = "newCategory")]
    public class Category : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private List<string> words;

        public string Name { get => name; private set => name = value; }

        public bool ExisistInCategory(string word, char letter)
        {
            //return words.Any(x => x.ToUpper() == word.ToUpper());
            
            for (int i = 0; i < words.Count; i++)
            {
                if (string.Equals(word.ToUpper(), words[i].ToUpper()) && word.ToUpper().StartsWith(letter.ToString().ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }
    }

