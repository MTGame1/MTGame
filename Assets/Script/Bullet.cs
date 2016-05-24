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
			
            if (right)
            {
                initPosition.x += 300f*Time.deltaTime;


            }
            else
            {
                initPosition.x -= 300f * Time.deltaTime;


            }

            this.gameObject.transform.localPosition = initPosition;
        }

        public void SetUp()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            //子弹销毁并没有处理 暂时
            //如果是碰撞到子弹，逻辑在这里加
            if (other.name.CompareTo("Player1Bottom") == 0)
            {
                GameObject battleScene = SceneManager.GetInstance()._currentScene;
                int bulletNum = battleScene.GetComponent<BattleScene>()._bulletNum;
                bulletNum++;
                battleScene.GetComponent<BattleScene>()._bulletNum = bulletNum;
                battleScene.GetComponent<BattleScene>().FillingBullet();
                Debug.Log("ddddd");
                GameObject.Destroy(this.gameObject);
            }
            if (other.name.CompareTo("Player2Bottom") == 0)
            {
                GameObject battleScene = SceneManager.GetInstance()._currentScene;
                int bulletNum = battleScene.GetComponent<BattleScene>()._bulletNum;
                bulletNum++;
                battleScene.GetComponent<BattleScene>()._bulletNum = bulletNum;
                battleScene.GetComponent<BattleScene>().FillingBullet();
                Debug.Log("ddddd");
                GameObject.Destroy(this.gameObject);
            }
            if (other.tag.CompareTo("Player1") == 0)
            {
                GameObject battleScene = SceneManager.GetInstance()._currentScene;
                int bulletNum = battleScene.GetComponent<BattleScene>()._bulletNum;
                bulletNum++;
                battleScene.GetComponent<BattleScene>()._bulletNum = bulletNum;
                battleScene.GetComponent<BattleScene>().FillingBullet();
                Debug.Log("ddddd");

                GameObject.Destroy(this.gameObject);
            }
            if (other.tag.CompareTo("Player2") == 0)
            {
                GameObject battleScene = SceneManager.GetInstance()._currentScene;
                int bulletNum = battleScene.GetComponent<BattleScene>()._bulletNum;
                bulletNum++;
                battleScene.GetComponent<BattleScene>()._bulletNum = bulletNum;
                battleScene.GetComponent<BattleScene>().FillingBullet();
                Debug.Log("ddddd");
                GameObject.Destroy(this.gameObject);
            }

		
        }
    }
}
