using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Script
{
    public class BattleScene : BaseScene
    {
        public const float ONE_TO_THREE = 1;
        public const float ONE_TO_OTHER = 2;

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

		private GameObject _bullet3;


        private GameObject _player1Bottom;
        private GameObject _player2Bottom;

        private float _buttomMoveTime = 5f;
        private float _MoveLeftTime = 1f;
        private int _MoveNum = 2;

		public static int _bulletNum = 0;
        public static List<List<BaseMiddleObject>> middleList = new List<List<BaseMiddleObject>>();

        public static float[,] middlePos = new float[9, 2] { 
            //中间件x，中间件y
            { -82 ,165}, 
            { 82  ,115},    
            { 0   , 135}, 
            {  -82, 0 },
            {  82 , 30 },
            {  0  , 24 },
            {  -82, -135 },
            {  82 , -115 },
            {  0  , -165 },
           
        };

        #region PlayerLife --pzy
        private PlayerLife _player1Life;
        public PlayerLife player1Life { get { return _player1Life; } }
        private PlayerLife _player2Life;
        public PlayerLife player2Life { get { return _player2Life; } }

        private void InitPlayerLife()
        {
            _player1Life = transform.Find("Player1Life").GetComponent<PlayerLife>();
            _player2Life = transform.Find("Player2Life").GetComponent<PlayerLife>();
        }
        #endregion

        protected override void Awake()
        {
            base.Awake();
            gameObjectList = this.GetComponent<GameObjectList>();
            _player1Bottom = gameObjectList.gameobjectList[6];
            _player2Bottom = gameObjectList.gameobjectList[7];

            //init playerlife widget --pzy
            InitPlayerLife();
        }
        protected override void Update()
        {
            Debug.Log("zidan"+ BattleScene._bulletNum);
			if(_bullet1){
				
				_bullet1.transform.localPosition = new Vector3 (_bullet1.transform.localPosition.x + 300f * Time.deltaTime, _bullet1.transform.localPosition.y, _bullet1.transform.localPosition.z);
			}
			if(_bullet2){
				
				_bullet2.transform.localPosition = new Vector3 (_bullet2.transform.localPosition.x - 300f * Time.deltaTime, _bullet2.transform.localPosition.y, _bullet2.transform.localPosition.z);
			}


            _buttomMoveTime -= Time.deltaTime;
            if (_buttomMoveTime < 0 && _MoveNum > 0)
            {
                _MoveLeftTime -= Time.deltaTime;
                if (_MoveLeftTime < 0)
                {
                    _buttomMoveTime = 5f;
                    _MoveLeftTime = 1f;
                    _MoveNum -= 1;
                    _player1Bottom.GetComponent<BottomController1>().isMoving = false;
                    _player2Bottom.GetComponent<BottomController2>().isMoving = false;
                }
                else
                {
                    _player1Bottom.GetComponent<BottomController1>().isMoving = true;
                    _player2Bottom.GetComponent<BottomController2>().isMoving = true;
                }

                _player1.transform.localPosition = new Vector3(_player1.transform.localPosition.x + 1f, _player1.transform.localPosition.y, _player1.transform.localPosition.z);
                _player2.transform.localPosition = new Vector3(_player2.transform.localPosition.x - 1f, _player2.transform.localPosition.y, _player2.transform.localPosition.z);



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
           


            UIEventListener.Get(_player1Btn).onClicks.Add(OnClickPlayer1Btn);
            UIEventListener.Get(_player2Btn).onClicks.Add(OnClickPlayer2Btn);

            _player1.AddComponent<PlayerController1>();
            _player2.AddComponent<PlayerController2>();

            createMiddle();
        }

        private void OnClickPlayer1Btn(GameObject go, BaseEventData eventData)
        {
            //_player1.GetComponent<PlayerController1>().Shoot();
            if(_player1.GetComponent<PlayerController1>().isHasBullet)
            {
                string path = "Prefab/bullet";
                GameObject obj = Resources.Load(path) as GameObject;
                _bullet1 = GameObject.Instantiate(obj);
                _bullet1.transform.SetParent(this.transform, false);
                _bullet1.transform.position = _bulletPos1.transform.position;
				_bullet1.name = "bu";
                Bullet bullet = _bullet1.AddComponent<Bullet>();
                bullet.right = true;
				BattleScene._bulletNum++;
                _player1.GetComponent<PlayerController1>().isHasBullet = false;
            }
            else
            {
                _player1.GetComponent<PlayerController1>().moveUp = !_player1.GetComponent<PlayerController1>().moveUp;
            }



        }

        private void OnClickPlayer2Btn(GameObject go, BaseEventData eventData)
        {
            if(_player2.GetComponent<PlayerController2>().isHasBullet)
            {
                string path = "Prefab/bullet";
                GameObject obj = Resources.Load(path) as GameObject;
                _bullet2 = GameObject.Instantiate(obj);
                _bullet2.transform.SetParent(this.transform, false);
                _bullet2.transform.position = _bulletPos2.transform.position;
				_bullet2.name = "bu";
                Bullet bullet = _bullet2.AddComponent<Bullet>();
                bullet.right = false;
				BattleScene._bulletNum++;
                _player2.GetComponent<PlayerController2>().isHasBullet = false;


				//this.gameObject.transform.localPosition = initPosition;
            }
            else
            {
                _player2.GetComponent<PlayerController2>().moveUp = !_player2.GetComponent<PlayerController2>().moveUp;
            }
           
        }

        public void FillingBullet()
        {
           
            if (!_player1.GetComponent<PlayerController1>().isHasBullet && !_player2.GetComponent<PlayerController2>().isHasBullet)
            {
               if(_bulletNum == 0)
               {
					Debug.Log("可以开始新的一局，子弹装填完毕");
                   _player1.GetComponent<PlayerController1>().isHasBullet = true;
                   _player2.GetComponent<PlayerController2>().isHasBullet = true;
                   _bulletNum = 0;
                   //增加一个提示 下一个回合开始的UI提示

               }
            }
        }

        private void createMiddle() {
            Debug.Log(middlePos.Length);
            Debug.Log("jinrucreate");
            for (int i = 0; i < middlePos.Length/2; i++)
            {
                int count = 0;
                List<BaseMiddleObject> list = new List<BaseMiddleObject>();
                BaseMiddleObject baseMiddle;

                string path = "Prefab/zhuan";
                GameObject obj = Resources.Load(path) as GameObject;
                GameObject zhuan = GameObject.Instantiate(obj);
                zhuan.transform.SetParent(this.transform, false);
                zhuan.transform.localPosition = new Vector3(middlePos[i,0], middlePos[i, 1], -1000);
                baseMiddle = (BaseMiddleObject)zhuan.GetComponent<BaseMiddleObject>();
                baseMiddle.index = i;
               
                list.Add(baseMiddle);
                count++;


                string path2 = "Prefab/MiddleFantan";
                GameObject obj2 = Resources.Load(path2) as GameObject;
                GameObject zhuan2 = GameObject.Instantiate(obj2);
                zhuan2.transform.SetParent(this.transform, false);
                zhuan2.transform.localPosition = new Vector3(middlePos[i, 0], middlePos[i, 1], -1000); 
                baseMiddle = (BaseMiddleObject)zhuan2.GetComponent<BaseMiddleObject>();
                baseMiddle.index = i;
               
                list.Add(baseMiddle);
                count++;

                middleList.Add(list);
                //int showIndex = getRandoms(count);
                int showIndex=UnityEngine.Random.Range(0, count+3);

                Debug.Log(showIndex);
                if (showIndex < count)
                {
                    list[showIndex].showMiddle();
                }



            }




        }
















    }
}

