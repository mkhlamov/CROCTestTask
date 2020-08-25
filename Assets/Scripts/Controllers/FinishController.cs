using Models;
using Views.UI;

namespace Controllers
{
    public class FinishController : BaseController<UIRootFinish>
    {
        public override void Activate(GameData gameData = null)
        {
            base.Activate(gameData);
            uiRoot.View.onMenuButtonClicked += OpenMenu;
            
            uiRoot.View.UpdateResults(GameData);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            uiRoot.View.onMenuButtonClicked -= OpenMenu;
        }

        private void OpenMenu() => MainController.SetController(ControllerType.Menu);
    }
}