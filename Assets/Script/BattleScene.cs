using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Script
{
    public class BattleScene : BaseScene
    {

        private GameObject button;
        private GameObjectList gameObjectList;

        private GameObject _player1;
        private GameObject _player2;
        private GameObject _player1Btn;
        private GameObject _player2Btn;
        private GameObject _bulletPos1;
        private GameObject _bulletPos2;

        private GameObject _bullet1;
        private GameObject _bullet2;

        private GameObject _player1Bottom;
        private GameObject _player2Bottom;

        private float _buttomMoveTime = 5f;

        protected override void Update()
        {
            _buttomMoveTime -= Time.deltaTime;
            if(_buttomMoveTime < 0)
            {
                _buttomMoveTime = 5f;

                _player1Bottom.transform.localPosition = new Vector3(_player1Bottom.transform.localPosition.x + 20f, _player1Bottom.transform.localPosition.y, _player1Bottom.transform.localPosition.z);
                _player2Bottom.transform.localPosition = new Vector3(_player2Bottom.transform.localPosition.x - 20f, _player2Bottom.transform.localPosition.y, _player2Bottom.transform.localPosition.z);

                _player1.transform.localPosition = new Vector3(_player1.transform.localPosition.x + 20f, _player1.transform.localPosition.y, _player1.transform.localPosition.z);
                _player2.transform.localPosition = new Vector3(_player2.transform.localPosition.x - 20f, _player2.transform.localPosition.y, _player2.transform.localPosition.z);
            
            }
        }


        public override void Initialize()
        {
            base.Initialize();

            gameObjectList = this.GetComponent<GameObjectList>();

            InitScene();
        }



        private void InitScene()
        {
            _player1Btn = gameObjectList.gameobjectList[0];
            _player2Btn = gameObjectList.gameobjectList[1];
            _player1 = gameObjectList.gameobjectList[2];
            _player2 = gameObjectList.gameobjectList[3];
            _bulletPos1 = gameObjectList.gameobjectList[4];
            _bulletPos2 = gameObjectList.gameobjectList[5];
            _player1Bottom = gameObjectList.gameobjectList[6];
            _player2Bottom = gameObjectList.gameobjectList[7];


            UIEventListener.Get(_player1Btn).onClicks.Add(OnClickPlayer1Btn);
            UIEventListener.Get(_player2Btn).onClicks.Add(OnClickPlayer2Btn);

            _player1.AddComponent<PlayerController1>();
            _player2.AddComponent<PlayerController2>();
        }

        private void OnClickPlayer1Btn(GameObject go, BaseEventData eventData)
        {
            //_player1.GetComponent<PlayerController1>().Shoot();

            string path = "Prefab/bullet";
            GameObject obj = Resources.Load(path) as GameObject;
            _bullet1 = GameObject.Instantiate(obj);
            _bullet1.transform.SetParent(this.transform, false);
            _bullet1.transform.position = _bulletPos1.transform.position;

            Bullet bullet = _bullet1.AddComponent<Bullet>();
            bullet.right = true;
        }

        private void OnClickPlayer2Btn(GameObject go, BaseEventData eventData)
        {

            string path = "Prefab/bullet";
            GameObject obj = Resources.Load(path) as GameObject;
            _bullet2 = GameObject.Instantiate(obj);
            _bullet2.transform.SetParent(this.transform, false);
            _bullet2.transform.position = _bulletPos2.transform.position;

            Bullet bullet = _bullet2.AddComponent<Bullet>();
            bullet.right = false;
        }

    }
}

