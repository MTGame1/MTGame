using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Script
{
    public class GameStartScene : BaseScene
    {

        private GameObject button;
        public virtual void Initialize()
        {
            base.Initialize();

            InitializeUI();
        }

        private void InitializeUI()
        {
            button = this.gameObject.GetComponent<GameObjectList>().gameobjectList[0];
            UIEventListener.Get(button).onClicks.Add(OnClickGoBack);
        }

        private void OnClickGoBack(GameObject go, BaseEventData eventData)
        {
            SceneManager.GetInstance().ShowScene<BattleScene>("BattleScene");
        }

    }
}

