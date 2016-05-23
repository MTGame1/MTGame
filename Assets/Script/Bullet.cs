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

        void OnTriggerEnter()
        {
            Debug.Log("");
            //子弹销毁并没有处理 暂时
        }
    }
}
