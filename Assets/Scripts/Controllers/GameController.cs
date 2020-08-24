using System;
using UnityEngine;
using Views.UI;

namespace Controllers
{
    public class GameController : BaseController<UIRootGame>
    {
        private float _gameTime = 0f;
        public void Update()
        {
            _gameTime += Time.deltaTime;
            uiRoot.View.UpdateTime(_gameTime);
        }

        public override void Activate()
        {
            base.Activate();

            uiRoot.View.onFinish += OnGameFinish;

            _gameTime = 0f;
            uiRoot.View.UpdateTime(_gameTime);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            
            uiRoot.View.onFinish -= OnGameFinish;
        }

        private void OnGameFinish()
        {
            MainController.SetController(ControllerType.Finish);
        }
    }
}