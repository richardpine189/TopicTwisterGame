using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LetterPresenter
{
    private ILetterView _view;
    private ILetterGetter _letterGetter;
    private ICategoriesGetter _categoriesGetter;
    private IMatchAction _matchActions;

    public LetterPresenter(ILetterView view, ILetterGetter letterGetter, ICategoriesGetter categoriesGetter)
    {
        _view = view;
        _letterGetter = letterGetter;
        _categoriesGetter = categoriesGetter;
        _matchActions = new HardcodedMatchActions();
        _matchActions.GetMatch();
        _view.OnSpinClick += GetLetter;

        GetRoundNumber();
        GetCategories();
    }

    private void GetRoundNumber()
    {
        int index = _matchActions.GetCurrentRoundIndex();
        _view.ShowRoundNumber(index + 1);
    }

    private void GetCategories()
    {
        string[] categories = _matchActions.GetCurrentRound() != null ? _matchActions.GetCurrentRound().assignedCategoryNames : _categoriesGetter.GetCategories();

        _view.ShowCategories(categories);
    }

    private void GetLetter()
    {
        char letter = _matchActions.GetCurrentRound() != null ? _matchActions.GetCurrentRound().letter : _letterGetter.GetLetter();

        _view.ShowLetter(letter);
    }
}