using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object = UnityEngine.Object;


public interface ILoginView
    {
        event Action<string> OnLoginTrigger;

        void ShowErrorMessage(string message);

        void LoadMainScene();
    }

