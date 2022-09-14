using System;

namespace Core.Match.TitleHeaderView
{
    public interface ITitleSetName
    {
        static event Action<String> OnSendPanelName;
    }
    
    public class TitleSetName
    {
        public static event Action<String> OnSendPanelName;
        public static void SendPanelName(string panelName)
        {
            OnSendPanelName?.Invoke(panelName);
        }
    }
}