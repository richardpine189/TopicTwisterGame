namespace Core.Match.TitleHeaderView
{
    public class TitleHeaderPresenter
    {

        private readonly ITitleHeaderView _titleHeaderView;

        public TitleHeaderPresenter(ITitleHeaderView titleHeaderView)
        {
            
            _titleHeaderView = titleHeaderView;
           TitleSetName.OnSendPanelName += SetTitleName;
        }

        ~TitleHeaderPresenter()
        {
           TitleSetName.OnSendPanelName -= SetTitleName;
        }

        private void SetTitleName(string panelName)
        {
            _titleHeaderView.SetPanelTitleText(panelName);
        }
    }
}