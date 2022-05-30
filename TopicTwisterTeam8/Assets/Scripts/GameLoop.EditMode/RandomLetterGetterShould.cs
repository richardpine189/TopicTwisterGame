using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RandomLetterGetterShould
{
    ILetterGetter _letterGetter;
    char _letter;

    [SetUp]
    public void SetUp()
    {
        // Arrange
        _letterGetter = new RandomLetterGetter();

        // Act
        _letter = _letterGetter.GetLetter();
    }

    [Test]
    public void GivenARequest_ReturnAChar()
    {
        // Assert
        Assert.AreEqual(typeof(char), _letter.GetType());
    }

    [Test]
    public void GivenARequest_ReturnALetter()
    {
        // Assert
        Assert.IsTrue(char.IsLetter(_letter));
    }

    [Test]
    public void GivenARequest_ReturnAnUpperLetter()
    {
        // Assert
        Assert.IsTrue(char.IsUpper(_letter));
    }
}

public class RandomLetterGetter : ILetterGetter
{
    public char GetLetter()
    {
        System.Random rnd = new System.Random();
        char randomChar = (char)rnd.Next('A', 'Z');
        return randomChar;
    }
}

public interface ILetterGetter
{
    char GetLetter();
}