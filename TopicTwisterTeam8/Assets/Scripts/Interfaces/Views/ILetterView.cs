using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public interface ILetterView
    {
        void ShowLetter(char letter);

        void ShowCategories(string[] categories);

        event Action OnSpinClick;
    }

