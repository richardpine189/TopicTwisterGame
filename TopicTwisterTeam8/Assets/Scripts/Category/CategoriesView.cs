using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CategoriesView : MonoBehaviour, ICategoriesView
{
    [SerializeField]
    private GameObject _header;

    public event Action<int> OnUpdateCategoriesField;

    public event Action<int> OnChangeCategory;
    
    [SerializeField] private TextMeshProUGUI[] _categoriesLetterSelectionPanel;

    [SerializeField] private TextMeshProUGUI[] _categoriesAnsweringPanelPanel;

    [SerializeField] private TextMeshProUGUI[] _categoriesCorrectionPanel;

    [SerializeField] private TextMeshProUGUI[] _categoriesEndRoundPanel;

    [SerializeField]
    private GameObject _loadingSpinner;
    
    private const int StandardCategoriesAmount = 5;

    private void Start()
    {
        _header.SetActive(true);
        OnUpdateCategoriesField?.Invoke(StandardCategoriesAmount);
    }

    public void UpdateFields(string[] categoriesName)
    {
        for (int i = 0; i < StandardCategoriesAmount; i++)
        {
            _categoriesLetterSelectionPanel[i].text =
             _categoriesAnsweringPanelPanel[i].text =
                 _categoriesCorrectionPanel[i].text =
                   _categoriesEndRoundPanel[i].text =
                                    categoriesName[i];
        }

        _loadingSpinner.SetActive(false);

        foreach(var categoryText in _categoriesLetterSelectionPanel)
        {
            categoryText.gameObject.SetActive(true);
        }
    }

    public void UpdateSingleField(string categoryName, int index)
    {

        _categoriesLetterSelectionPanel[index].text =
         _categoriesAnsweringPanelPanel[index].text =
             _categoriesCorrectionPanel[index].text =
               _categoriesEndRoundPanel[index].text =
                categoryName;

    }

    void ChangeOneCategory(TextMeshProUGUI categoryToChange)
    {
        int tempIndex=0;
        for (int i = 0; i < StandardCategoriesAmount; i++)
        {
            if (_categoriesLetterSelectionPanel[i].text == categoryToChange.text)
                tempIndex = i;
        }

        OnChangeCategory?.Invoke(tempIndex);
    }
}

//public class CategoriesPresenter
//{
//    private ICategoriesView _categoriesView;
//    private ICategoriesGetter _categoriesGetter;
    
//    CategoriesPresenter(ICategoriesView categoriesView)
//    {
//        _categoriesView = categoriesView;
//        _categoriesGetter = new CategoriesGetter(new CategoryService());
//        SuscribeEvents();
//    }

//    void SuscribeEvents()
//    {
//        _categoriesView.OnUpdateCategoriesField += ObtainCategories;
//        _categoriesView.OnChangeCategory += ObtainSingleCategory;
//    }

//    private async void ObtainCategories(int amount = 5)
//    {
//        string[] tempCategoriesName = await _categoriesGetter.GetCategories(amount);
//        _categoriesView.UpdateFields(tempCategoriesName);
//    }

//    private async void ObtainSingleCategory(int index)
//    {
//        string[] tempCategory = await _categoriesGetter.GetCategories(1);
//        _categoriesView.UpdateSingleField(tempCategory[0], index);
//    }

//    ~CategoriesPresenter()
//    {
//        _categoriesView.OnUpdateCategoriesField -= ObtainCategories;
//        _categoriesView.OnChangeCategory -= ObtainCategories;
//    }
//}
