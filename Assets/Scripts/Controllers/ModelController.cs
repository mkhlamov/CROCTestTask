using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Models.ScriptableObjects;
using UnityEngine;
using Views;

namespace Controllers
{
    [RequireComponent(typeof(AudioSource))]
    public class ModelController : BaseController
    {
        [SerializeField] private AudioClip correctActionAudio;
        [SerializeField] private AudioClip wrongActionAudio;
        
        /// <summary>
        /// Action on scenario end with number of errors
        /// </summary>
        public Action<int> onScenarioCompleted;
        public Action onUserMistake;
        
        private Scenario _currentScenario;
        private List<ObjectView> _deviceParts;
        private int _scenarioStep = 0;
        private int _errorsCount = 0;
        private GameObject _model;
        private AudioSource _audioSource;
        
        public void Init(Scenario scenario, GameObject model)
        {
            _currentScenario = scenario;
            _scenarioStep = 0;
            _errorsCount = 0;
            _model = model;
            _audioSource = GetComponent<AudioSource>();

            _deviceParts = _model.GetComponentsInChildren<ObjectView>().ToList();
            var defaultDeviceParts = scenario.modelDefaultState.deviceStates.Select(x => x.deviceName).ToList();

            foreach (var devicePart in _deviceParts)
            {
                if (defaultDeviceParts.Contains(devicePart.gameObject.name))
                {
                    devicePart.IsOn = scenario.modelDefaultState.deviceStates
                        .First(x => x.deviceName == devicePart.gameObject.name).state;
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
                PlayAudio(correctActionAudio);
            }
            else
            {
                _errorsCount++;
                PlayAudio(wrongActionAudio);
                objectView.ToggleObjectWithNotification(false);
                onUserMistake?.Invoke();
            }

            if (_scenarioStep == _currentScenario.deviceStates.Count)
            {
                Finalize();
            }
        }

        private void PlayAudio(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}