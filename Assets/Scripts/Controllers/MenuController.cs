using System;
using System.Collections.Generic;
using Models;
using Models.ScriptableObjects;
using UnityEngine;
using Views;
using Views.UI;

namespace Controllers
{
    public class MenuController : BaseController<UIRootMenu>
    {
        [SerializeField] private List<Scenario> scenarios;
        [SerializeField] private Transform scenariosParent;
        private GameObject _scenarioViewPrefab;

        private void Awake()
        {
            _scenarioViewPrefab = Resources.Load<GameObject>("UIPrefabs/ScenarioView");
        }

        public override void Activate(GameData gameData = null)
        {
            base.Activate();
            
            uiRoot.View.onQuitButtonClicked += Quit;

            if (scenariosParent.childCount == 0)
            {
                foreach (var scenario in scenarios)
                {
                    var go = Instantiate(_scenarioViewPrefab, scenariosParent);
                    go.GetComponent<ScenarioView>().Init(scenario, OnModelChosen);
                }
            }
        }

        public override void Deactivate()
        {
            base.Deactivate();
            uiRoot.View.onQuitButtonClicked -= Quit;
        }

        private void OnModelChosen(Scenario scenario)
        {
            MainController.SetController(ControllerType.Game, new GameData()
                {
                    GameTime = 0f,
                    ErrorsCount = 0,
                    Scenario = scenario
                });
        }

        private void Quit()
        {
            Application.Quit();
        }
    }
}