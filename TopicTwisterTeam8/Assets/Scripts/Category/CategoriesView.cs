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
    
    [SerializeField] 
    private TextMeshProUGUI[] _categoriesLetterSelectionPanel;

    [SerializeField] 
    private TextMeshProUGUI[] _categoriesAnsweringPanel;

    [SerializeField] 
    private TextMeshProUGUI[] _categoriesCorrectionPanel;

    [SerializeField] 
    private TextMeshProUGUI[] _categoriesEndRoundPanel;

    [SerializeField]
    private GameObject _loadingSpinner;
    
    private const int StandardCategoriesAmount = 5;

    private void OnEnable()
    {
        _header.SetActive(true);
        CleanView();
        OnUpdateCategoriesField?.Invoke(StandardCategoriesAmount);
    }

    public void UpdateFields(string[] categoriesName)
    {
        for (int i = 0; i < StandardCategoriesAmount; i++)
        {
            _categoriesLetterSelectionPanel[i].text =
                  _categoriesAnsweringPanel[i].text =
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
              _categoriesAnsweringPanel[index].text =
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

    void CleanView()
    {
        _loadingSpinner.SetActive(true);
        foreach (var categoryText in _categoriesLetterSelectionPanel)
        {
            categoryText.gameObject.SetActive(false);
        }
    }
}