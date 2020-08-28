using UnityEngine;

namespace Views.UI
{
    public class UIRootGame : UIRoot
    {
        [SerializeField] private UIViewGame view;
        [SerializeField] private UIUserFailView userFailView;

        public UIViewGame View => view;
        public UIUserFailView UserFailView => userFailView;

        public override void Show()
        {
            base.Show();
            view.Show();
            userFailView.Hide();
        }

        public override void Hide()
        {
            base.Hide();
            view.Hide();
            userFailView.Hide();
        }
    }
}