using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(menuName = "TopicTwister/Category",fileName = "newCategory")]
    public class Category_not_use : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private List<string> words;

        public string Name { get => _name; private set => _name = value; }
    }

