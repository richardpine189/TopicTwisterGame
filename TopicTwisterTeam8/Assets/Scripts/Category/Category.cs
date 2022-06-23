using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(menuName = "TopicTwister/Category",fileName = "newCategory")]
    public class Category : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private List<string> words;

        public string Name { get => name; private set => name = value; }
    }

