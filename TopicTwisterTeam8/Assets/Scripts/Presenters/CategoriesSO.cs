using UnityEngine;

[CreateAssetMenu(menuName = "TopicTwister/CurrentCategories", fileName = "newCurrentCategories")]
public class CategoriesSO : ScriptableObject
{
    private string[] _categoriesName = new string[5];

    public string[] CategoriesName { get => _categoriesName; set => _categoriesName = value; }
}
