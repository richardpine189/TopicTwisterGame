using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.LoginScene
{
    public interface ILoginView
    {
        event Action<string> OnLoginTrigger;

        void ShowErrorMessage(string message);

        void LoadMainScene(UserDTO user);
    }
}
