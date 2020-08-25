using System;
using Models;
using UnityEngine;
using Views.UI;

namespace Controllers
{
    [Serializable]
    public abstract class BaseController : MonoBehaviour
    {
        protected MainController MainController;
        protected GameData GameData;

        /// <summary>
        /// Used to set reference to Main game controller
        /// </summary>
        /// <param name="controller">MainController for game</param>
        public void Init(MainController controller)
        {
            MainController = controller;
        }
        public virtual void Activate(GameData gameData = null)
        {
            gameObject.SetActive(true);
            GameData = gameData;
        }

        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
    
    public abstract class BaseController<TUIRoot> : BaseController
        where TUIRoot : UIRoot
    {
        [SerializeField] protected TUIRoot uiRoot;
        public TUIRoot UIRoot => uiRoot;
        
        public override void Activate(GameData gameData = null)
        {
            base.Activate(gameData);
            uiRoot.Show();
        }

        public override void Deactivate()
        {
            base.Deactivate();
            uiRoot.Hide();
        }
    }
}