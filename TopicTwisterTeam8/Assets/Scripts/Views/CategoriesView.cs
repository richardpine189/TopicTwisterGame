using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesView : MonoBehaviour, ILetterView
{
    [SerializeField] private GameObject _header;
    public event Action OnSpinClick;

    [SerializeField]
    private TMP_Text _letter;

    [SerializeField]
    private TMP_Text _countdownText;

    [SerializeField]
    private Button _getLetterButton;

    [SerializeField]
    private TMP_Text[] _categories;

    [SerializeField]
    private GameObject _nextPanel;

    [SerializeField]
    private LetterSO _letterSO;

    [SerializeField]
    private CategoriesSO _categoriesSO;

    [SerializeField] private GameObject _spiner;

    private LetterPresenter _presenter;
    [SerializeField] private RouteConfig _config;
    private void Start()
    {
        _header.SetActive(true);
        Initialize();
        _getLetterButton.onClick.AddListener(OnSpinClick.Invoke);
    }

    void OnEnable()
    {
        Initialize();
        _getLetterButton.gameObject.SetActive(true);
        _letter.text = null;
        _letter.gameObject.SetActive(false);
        _countdownText.gameObject.SetActive(false);
    }

    private void Initialize()
    {
        _presenter = new LetterPresenter(this, new RandomLetterGetter(), new CategoriesGetter(new CategoryService(_config.path)));
    }

    public void ShowLetter(char letter)
    {
        _letter.text = letter.ToString();
        _letter.gameObject.SetActive(true);
        _getLetterButton.gameObject.SetActive(false);
        _letterSO.Letter = letter; // SAVING LETTER
        StartCoroutine(CoutdownAnimation());
    }

    private IEnumerator CoutdownAnimation()
    {
        _countdownText.gameObject.SetActive(true);

        for(int i = 3; i > 0; i--)
        {
            _countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        _nextPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ShowCategories(string[] categories)
    {
        _spiner.SetActive(false);
        for(int i = 0; i < 5; i++)
        {
            _categories[i].gameObject.SetActive(true);
            _categories[i].text = categories[i];
        }
        _categoriesSO.CategoriesName = categories; // SAVING CATEGORIES NAME
    }


}
