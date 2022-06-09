using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _letterText;
    [SerializeField] private TextMeshProUGUI _challengingUserText;
    [SerializeField] private TextMeshProUGUI _oponentUserText;
    [SerializeField] private TextMeshProUGUI[] _categoriesText;

    private RoundPresenter _roundPresenter;
    private void Start()
    {
        _roundPresenter = new RoundPresenter(ServiceLocator.Instance);
    }
}
public class ServicesInstaller : MonoBehaviour
{
    private ServiceLocator _serviceLocator;

    private void Awake()
    {
        _serviceLocator = new ServiceLocator();
    }
}
public class RoundPresenter
{
    IServiceGiver _serviceGiver;
    IRoundAction _roundAction;


    public RoundPresenter(IServiceGiver serviceGiver)
    {
        _serviceGiver = serviceGiver;
        
    }
    public void InstallRoundAction(IRoundAction roundAction)
    {
        _roundAction = roundAction;
    }
}