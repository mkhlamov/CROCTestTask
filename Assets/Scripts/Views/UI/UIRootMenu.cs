using UnityEngine;

namespace Views.UI
{
    public class UIRootMenu : UIRoot
    {
        [SerializeField] private UIViewMenu view;

        public UIViewMenu View => view;

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