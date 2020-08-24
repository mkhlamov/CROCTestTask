using System;
using Misc;
using UnityEngine;
using Views.UI;

namespace Controllers
{
    public class MenuController : BaseController<UIRootMenu>
    {
        public override void Activate()
        {
            base.Activate();
            
            uiRoot.View.onModel1ButtonClicked += OnModelChosen(ModelType.Model1);
            uiRoot.View.onModel2ButtonClicked += OnModelChosen(ModelType.Model2);
            uiRoot.View.onQuitButtonClicked += Quit;
        }

        public override void Deactivate()
        {
            base.Deactivate();
            
            uiRoot.View.onModel1ButtonClicked -= OnModelChosen(ModelType.Model1);
            uiRoot.View.onModel2ButtonClicked -= OnModelChosen(ModelType.Model2);
            uiRoot.View.onQuitButtonClicked -= Quit;
        }

        private Action OnModelChosen(ModelType modelType)
        {
            return () => throw new NotImplementedException();

        }

        private void Quit()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}