using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class Bullet : MonoBehaviour
    {
        Vector3 initPosition;
        public bool right = true;
        void Awake()
        {
            Vector3 position = this.gameObject.transform.localPosition;
            initPosition = new Vector3(position.x, position.y, position.z);
        }
        void Update()
        {
			
//            if (right)
//            {
//                initPosition.x += 300f*Time.deltaTime;
//
//
//            }
//            else
//            {
//                initPosition.x -= 300f * Time.deltaTime;
//
//
//            }
//
//            this.gameObject.transform.localPosition = initPosition;
        }

        public void SetUp()
        {

        }

        void OnTriggerEnter(Collider other)
        {

            if (other.name.CompareTo("Player1Bottom") == 0)
            {
                GameObject battleScene = SceneManager.GetInstance()._currentScene;
                BattleScene._bulletNum--;
                battleScene.GetComponent<BattleScene>().FillingBullet();
                GameObject.Destroy(this.gameObject);
            }
            else if (other.name.CompareTo("Player2Bottom") == 0)
            {
                GameObject battleScene = SceneManager.GetInstance()._currentScene;
                BattleScene._bulletNum--;
                battleScene.GetComponent<BattleScene>().FillingBullet();
                GameObject.Destroy(this.gameObject);
            }
            else if (other.tag.CompareTo("Player1") == 0)
            {//子弹击中玩家1
                GameObject battleScene = SceneManager.GetInstance()._currentScene;
                BattleScene._bulletNum--;
                battleScene.GetComponent<BattleScene>().FillingBullet();
                Debug.Log("子弹击中玩家1");
                GameObject.Destroy(this.gameObject);
            }
            else if (other.tag.CompareTo("Player2") == 0)
            {//子弹击中玩家2
                GameObject battleScene = SceneManager.GetInstance()._currentScene;
                BattleScene._bulletNum--;
                battleScene.GetComponent<BattleScene>().FillingBullet();
                Debug.Log("子弹击中玩家2");
                GameObject.Destroy(this.gameObject);
            }
            else if (other.tag.CompareTo("UpWall") == 0)
            {
                GameObject battleScene = SceneManager.GetInstance()._currentScene;
                BattleScene._bulletNum--;
                battleScene.GetComponent<BattleScene>().FillingBullet();
               
                GameObject.Destroy(this.gameObject);
            }
            else if (other.tag.CompareTo("DownWall") == 0)
            {
                GameObject battleScene = SceneManager.GetInstance()._currentScene;
                BattleScene._bulletNum--;
                battleScene.GetComponent<BattleScene>().FillingBullet();

                GameObject.Destroy(this.gameObject);
            }


        }
    }
}
