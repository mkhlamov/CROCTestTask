using System;
using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Controllers
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private List<ControllerByType> controllers;
        //TODO: make SerializableDictionary. Maybe use Odin Inspector.
        //[SerializeField] private SerializableDictionary<ControllerType, BaseController> controllers;
        
        private void Start()
        {
            foreach (var controller in controllers)
            {
                controller.controller.Init(this);
            }

            SetController(ControllerType.Menu);
        }
        
        public void SetController(ControllerType controllerType, GameData gameData = null)
        {
            DeactivateAllControllers();
            controllers.Find(x => x.controllerType == controllerType).controller.Activate(gameData);
        }

        private void DeactivateAllControllers()
        {
            foreach (var controller in controllers)
            {
                controller.controller.Deactivate();
            }
        }
    }

    public enum ControllerType
    {
        Menu,
        Game,
        Finish
    }

    [Serializable]
    public class ControllerByType
    {
        public ControllerType controllerType;
        public BaseController controller;
    }
}