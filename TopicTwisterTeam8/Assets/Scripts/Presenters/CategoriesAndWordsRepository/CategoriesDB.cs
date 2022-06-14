using System;
using System.Collections;
using System.Collections.Generic;
using TopicTwister.Assets.Scripts.Models;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Interfaces;

public class CategoriesDB : MonoBehaviour, ICategoriesRepository
{
    [SerializeField] List<Category> _categories;

    public List<Category> GetCategories()
    {
        return _categories;
    }

    public List<Category> GetCategories(int quantity)
    {
        var random = new System.Random();
        List<Category> tempCategories = new List<Category>(_categories); 
        List<Category> asignedCategories = new List<Category>();
        int index;
        for(int i=0; i < quantity; i++)
        {
            index = random.Next(tempCategories.Count);

            asignedCategories.Add(tempCategories[index]);
            tempCategories.RemoveAt(index);
        }
        return asignedCategories;
    }
}
