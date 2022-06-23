using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class RandomLetterGetterShould
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

