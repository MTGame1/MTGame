using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class BottomController2 : MonoBehaviour
    {
        public bool isMoving { set; get; }
        void Update()
        {
            if (isMoving)
            {
                 this.transform.localPosition = new Vector3(this.transform.localPosition.x - 1f, this.transform.localPosition.y, this.transform.localPosition.z);
            }
        }

//         void OnTriggerEnter(Collider other)
//         {
// 
//             if (other.tag.CompareTo("Bullet") == 0)
//             {
//                 GameObject.Destroy(other.gameObject);
//             }
//         }
    }
}
