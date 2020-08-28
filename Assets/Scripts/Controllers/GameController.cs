using System;
using Models;
using UnityEngine;
using Views;
using Views.UI;

namespace Controllers
{
    public class GameController : BaseController<UIRootGame>
    {
        [SerializeField] private Transform modelParent;
        [SerializeField] private ModelController modelController;
        [SerializeField] private ScenarioInfoView scenarioInfoView;
        
        private GameObject _instantiatedModel;
        private const string MistakeTextStart = "You made a mistake!\n";
        private const string MistakeTextEnd = "Do you want to retry or continue?";
        
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

            modelController.onScenarioCompleted += OnGameFinish;
            modelController.onUserMistake += OnUserMistake;
            modelController.Init(gameData.Scenario, _instantiatedModel);
            
            scenarioInfoView.Init(gameData.Scenario.deviceStates);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            
            uiRoot.View.onFinish -= OnGameFinish;
            DestroyScenarioModel();
            modelController.onScenarioCompleted -= OnGameFinish;
        }

        private void DestroyScenarioModel()
        {
            if (_instantiatedModel != null)
            {
                Destroy(_instantiatedModel);
            }
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
        
        private void OnUserMistake()
        {
            uiRoot.UserFailView.Init(MistakeTextStart
                                     + " Next step: "
                                     + modelController.GetNextStep().ToString()
                                     + "\n"
                                     + MistakeTextEnd,
                RestartScenario,
                () =>
                {
                    uiRoot.UserFailView.Hide();                    
                });
            uiRoot.UserFailView.Show();
        }

        private void RestartScenario()
        {
            DestroyScenarioModel();
            GameData.GameTime = 0f;
            GameData.ErrorsCount = 0;
            FinalizeUserFailView();
            Activate(GameData);
        }

        private void FinalizeUserFailView()
        {
            uiRoot.UserFailView.Finalize();
            uiRoot.UserFailView.Hide();
        }
    }
}