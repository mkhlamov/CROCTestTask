using System;
using Models;
using UnityEngine;
using Views.UI;

namespace Controllers
{
    public class GameController : BaseController<UIRootGame>
    {
        public void Update()
        {
            GameData.GameTime += Time.deltaTime;
            uiRoot.View.UpdateTime(GameData.GameTime);
        }

        public override void Activate(GameData gameData = null)
        {
            base.Activate(gameData);

            uiRoot.View.onFinish += OnGameFinish;
            uiRoot.View.UpdateTime(GameData.GameTime);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            
            uiRoot.View.onFinish -= OnGameFinish;
        }

        private void OnGameFinish()
        {
            MainController.SetController(ControllerType.Finish, GameData);
        }
    }
}