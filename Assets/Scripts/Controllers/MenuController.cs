using System;
using Models;
using UnityEngine;
using Views.UI;

namespace Controllers
{
    public class MenuController : BaseController<UIRootMenu>
    {
        public override void Activate(GameData gameData = null)
        {
            base.Activate();
            
            uiRoot.View.onModel1ButtonClicked += OnModelChosen(ModelType.Model1);
            uiRoot.View.onModel2ButtonClicked += OnModelChosen(ModelType.Model2);
            uiRoot.View.onQuitButtonClicked += Quit;
        }

        public override void Deactivate()
        {
            base.Deactivate();
            
            uiRoot.View.onModel1ButtonClicked -= OnModelChosen(ModelType.Model1);
            uiRoot.View.onModel2ButtonClicked -= OnModelChosen(ModelType.Model2);
            uiRoot.View.onQuitButtonClicked -= Quit;
        }

        private Action OnModelChosen(ModelType modelType)
        {
            return () =>
            {
                MainController.SetController(ControllerType.Game, new GameData()
                {
                    GameTime = 0f,
                    ErrorsCount = 0,
                    ModelType = modelType
                });
            };

        }

        private void Quit()
        {
            Application.Quit();
        }
    }
}