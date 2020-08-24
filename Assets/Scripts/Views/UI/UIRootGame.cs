using UnityEngine;

namespace Views.UI
{
    public class UIRootGame : UIRoot
    {
        [SerializeField] private UIViewGame view;

        public UIViewGame View => view;

        public override void Show()
        {
            base.Show();
            view.Show();
        }

        public override void Hide()
        {
            base.Hide();
            view.Hide();
        }
    }
}