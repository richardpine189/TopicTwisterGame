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
    private MatchDTO _match;

    public LetterPresenter(ILetterView view, ILetterGetter letterGetter, ICategoriesGetter categoriesGetter)
    {
        _view = view;
        _letterGetter = letterGetter;
        _categoriesGetter = categoriesGetter;
        _matchActions = new HardcodedRoundActions();
        _match = _matchActions.Match;
        _view.OnSpinClick += GetLetter;

        GetRoundNumber();
        GetCategories();
    }

    private void GetRoundNumber()
    {
        int index = _matchActions.GetCurrentRoundIndex();
        _view.ShowRoundNumber(124);
    }

    private async void GetCategories()
    {
        string[] categories = _matchActions.Match.currentCategories != null ? _matchActions.Match.currentCategories : await _categoriesGetter.GetCategories(5);

        _match.currentCategories = categories;
        _matchActions.Match = _match;

        _view.ShowCategories(categories);
    }

    private void GetLetter()
    {
        char letter = (char)(_matchActions.Match.currentLetter != null ? _matchActions.Match.currentLetter : _letterGetter.GetLetter());

        _match.currentLetter = letter;
        _matchActions.Match = _match;

        _view.ShowLetter(letter);
    }
}