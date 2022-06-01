using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Team8.TopicTwister
{
    public class ScriptableObj : MonoBehaviour
    {
        void Start()
        {
            createScriptableObject();
        }

        void createScriptableObject()
        {
            Category newItem = ScriptableObject.CreateInstance<Category>();
            newItem.name = "name";
            AssetDatabase.CreateAsset(newItem, "Assets/PruebasRaras/Test.asset");
        }
    }
}
