using Views.UI;

namespace Controllers
{
    public class FinishController : BaseController<UIRootFinish>
    {
        public override void Activate()
        {
            base.Activate();
            uiRoot.View.onMenuButtonClicked += OpenMenu;
        }

        public override void Deactivate()
        {
            base.Deactivate();
            uiRoot.View.onMenuButtonClicked -= OpenMenu;
        }

        private void OpenMenu() => MainController.SetController(ControllerType.Menu);
    }
}