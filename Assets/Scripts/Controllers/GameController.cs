using System;
using Models;
using UnityEngine;
using Views.UI;

namespace Controllers
{
    public class GameController : BaseController<UIRootGame>
    {
        [SerializeField] private Transform modelParent;
        private GameObject _instantiatedModel;
        
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

            if (gameData.Scenario.modelPrefab != null)
            {
                _instantiatedModel = Instantiate(gameData.Scenario.modelPrefab, modelParent);
            }
        }

        public override void Deactivate()
        {
            base.Deactivate();
            
            uiRoot.View.onFinish -= OnGameFinish;
            if (_instantiatedModel != null)
            {
                Destroy(_instantiatedModel);
            }
        }

        private void OnGameFinish()
        {
            MainController.SetController(ControllerType.Finish, GameData);
        }
    }
}