using System;
using TMPro;
public interface ICategoriesView
{
    event Action<int> OnUpdateCategoriesField;
    event Action<int> OnChangeCategory;
    void UpdateFields(string[] categoriesName);
    void UpdateSingleField(string categoryName, int index);

}
