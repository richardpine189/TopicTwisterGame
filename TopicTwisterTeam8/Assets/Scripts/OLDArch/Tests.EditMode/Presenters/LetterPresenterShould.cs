//using NSubstitute;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//public class LetterPresenterShould
//{
//    ILetterView _view;
//    IGetLetterUseCase _letterGetter;
//    ICategoriesGetter _categoriesGetter;

//    [SetUp]
//    public void SetUp()
//    {
//        _view = Substitute.For<ILetterView>();
//        _letterGetter = Substitute.For<IGetLetterUseCase>();
//        _categoriesGetter = Substitute.For<ICategoriesGetter>();
//    }

//    [Test]
//    public void ShowCategories_OnStart()
//    {
//        // Arrange
//        string[] categories = { "Objetos", "Animales", "Ropa", "Comida", "Paises" };
//        _categoriesGetter.GetCategories(5).Returns(categories);

//        // Act
//        LetterPresenter _presenter = new LetterPresenter(_view, _letterGetter, _categoriesGetter);

//        // Assert
//        _view.Received().ShowCategories(categories);
//    }

//    [Test]
//    public void ShowRandomLetter_WhenButtonClick()
//    {
//        // Arrange
//        char letter = 'A';
//        _letterGetter.Execute().Returns(letter);
//        LetterPresenter _presenter = new LetterPresenter(_view, _letterGetter, _categoriesGetter);

//        // Act
//        _view.OnSpinClick += Raise.Event<Action>();

//        // Assert
//        _view.Received().ShowLetter(letter);
//    }
//}

