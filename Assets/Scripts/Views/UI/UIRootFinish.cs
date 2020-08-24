using UnityEngine;

namespace Views.UI
{
    public class UIRootFinish : UIRoot
    {
        [SerializeField] private UIViewFinish view;

        public UIViewFinish View => view;

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