using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Models.ScriptableObjects;
using UnityEngine;
using Views;

namespace Controllers
{
    public class ModelController : BaseController
    {
        /// <summary>
        /// Action on scenario end with number of errors
        /// </summary>
        public Action<int> onScenarioCompleted;

        public Action onUserMistake;
        
        private Scenario _currentScenario;
        [SerializeField] private List<ObjectView> _deviceParts;
        [SerializeField] private int _scenarioStep = 0;
        [SerializeField] private int _errorsCount = 0;
        private GameObject _model;
        
        public void Init(Scenario scenario, GameObject model)
        {
            _currentScenario = scenario;
            _scenarioStep = 0;
            _errorsCount = 0;
            _model = model;

            _deviceParts = _model.GetComponentsInChildren<ObjectView>().ToList();
            var defaultDeviceParts = scenario.modelDefaultState.deviceStates.Select(x => x.deviceName).ToList();

            foreach (var devicePart in _deviceParts)
            {
                if (defaultDeviceParts.Contains(devicePart.gameObject.name))
                {
                    devicePart.TurnObjectToState(scenario.modelDefaultState.deviceStates
                        .First(x => x.deviceName == devicePart.gameObject.name).state);
                }
                devicePart.OnDeviceStateChanged += OnDevicePartStateChanged;
            }
        }

        /// <summary>
        /// Return next correct DevicePartState
        /// </summary>
        public DevicePartState GetNextStep()
        {
            return _currentScenario.deviceStates[_scenarioStep];
        }

        private void Finalize()
        {
            onScenarioCompleted?.Invoke(_errorsCount);
            foreach (var devicePart in _deviceParts)
            {
                devicePart.OnDeviceStateChanged -= OnDevicePartStateChanged;
            }
        }

        private void OnDevicePartStateChanged(ObjectView objectView, bool state)
        {
            var devicePartState = _currentScenario.deviceStates[_scenarioStep];
            
            // User made correct action
            if (devicePartState.deviceName == objectView.gameObject.name &&
                devicePartState.state == state)
            {
                _scenarioStep++;
            }
            else
            {
                _errorsCount++;
                objectView.ToggleObjectWithNotification(false);
                onUserMistake?.Invoke();
            }

            if (_scenarioStep == _currentScenario.deviceStates.Count)
            {
                Finalize();
            }
        }
    }
}