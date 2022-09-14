namespace Core.Match.TitleHeaderView
{
    public class TitleHeaderPresenter
    {

        private readonly ITitleHeaderView _titleHeaderView;

        public TitleHeaderPresenter(ITitleHeaderView titleHeaderView)
        {
            
            _titleHeaderView = titleHeaderView;
            /*
            _letterView = letterView;
            _answeringView = answeringView;
            _correctionView = correctionView;
            _endRoundView = endRoundView;

            _letterView.OnSendPanelName += SetTitleName;
            _answeringView.OnSendPanelName += SetTitleName;
            _correctionView.OnSendPanelName += SetTitleName;
            _endRoundView.OnSendPanelName += SetTitleName;
            */
            UnityEngine.Debug.Log("TitlePanelConstructor");
            TitleSetName.OnSendPanelName += SetTitleName;
        }

        ~TitleHeaderPresenter()
        {
            /*
            _letterView.OnSendPanelName -= SetTitleName;
            _answeringView.OnSendPanelName -= SetTitleName;
            _correctionView.OnSendPanelName -= SetTitleName;
            _endRoundView.OnSendPanelName -= SetTitleName;
            */
            TitleSetName.OnSendPanelName -= SetTitleName;
        }

        private void SetTitleName(string panelName)
        {
            UnityEngine.Debug.Log("panelTitleMustChange");
            _titleHeaderView.SetPanelTitleText(panelName);
        }
    }
}