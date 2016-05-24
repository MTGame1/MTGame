using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class PlayerController1 : MonoBehaviour
    {
        private Vector3 initPosition;
        public bool moveUp = true;

        public bool isHasBullet = true;
        void Awake()
        {
            /*initPosition = this.gameObject.transform.localPosition;*/
        }
        void Update()
        {
            initPosition = this.gameObject.transform.localPosition;
            if (moveUp)
            {
                initPosition.y += 3;
            }
            else
            {
                initPosition.y -= 3;
            }

            this.gameObject.transform.localPosition = initPosition;
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.tag.CompareTo("UpWall") == 0)
            {
                moveUp = false;
            }

            if (other.tag.CompareTo("DownWall") == 0)
            {
                moveUp = true;
            }

           

            //如果是碰撞到子弹，逻辑在这里加
            if (other.tag.CompareTo("Bullet") == 0)
            {
                Debug.Log("player1 Hp down");
            }
        }
    }
}