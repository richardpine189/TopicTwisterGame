using System.Collections;
using System.Collections.Generic;
using TopicTwister.Assets.Scripts.Models;
using UnityEngine;

public class CategoriesDB : MonoBehaviour, ICategoriesRepository
{
    [SerializeField] List<Category> _categories;

    public List<Category> GetCategories()
    {
        return _categories;
    }
}

public interface ICategoriesRepository
{
    public List<Category> GetCategories();
}