using System;
using Models;
using UnityEngine;
using Views.UI;

namespace Controllers
{
    public class GameController : BaseController<UIRootGame>
    {
        [SerializeField] private Transform modelParent;
        [SerializeField] private ModelController modelController;
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

            modelController.OnScenarioCompleted += OnGameFinish;
            modelController.Init(gameData.Scenario, _instantiatedModel);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            
            uiRoot.View.onFinish -= OnGameFinish;
            if (_instantiatedModel != null)
            {
                Destroy(_instantiatedModel);
            }
            modelController.OnScenarioCompleted -= OnGameFinish;
        }

        private void OnGameFinish()
        {
            MainController.SetController(ControllerType.Finish, GameData);
        }
        
        private void OnGameFinish(int errorsCount)
        {
            UpdateErrorsCount(errorsCount);
            OnGameFinish();
        }
        
        private void UpdateErrorsCount(int errorsCount)
        {
            GameData.ErrorsCount = errorsCount;
        }
    }
}