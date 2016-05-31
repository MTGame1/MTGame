using UnityEngine;
using System.Collections;
namespace Assets.Script
{
public class BulletMoveBack : MonoBehaviour {
	private bool istrigger = false;
	private GameObject bullect;
	private GameObject myparent;

		private GameObject bullet3;
	
		private Bullet b_bullet3;

	// Use this for initialization
	void Start () {
		
		string path3 = "Prefab/zidan";
		this.bullect = Resources.Load(path3) as GameObject;


	}
	
	// Update is called once per frame
	void Update () {
		

			if(bullet3){
				if (b_bullet3.right) {
					bullet3.transform.localPosition = new Vector3 (bullet3.transform.localPosition.x - 600f * Time.deltaTime, bullet3.transform.localPosition.y, bullet3.transform.localPosition.z);
				} else {
					bullet3.transform.localPosition = new Vector3 (bullet3.transform.localPosition.x + 600f * Time.deltaTime, bullet3.transform.localPosition.y, bullet3.transform.localPosition.z);

				}
			}


	}
	void OnTriggerEnter(Collider other){
		if (other.name == "bu") {
			Destroy (other.gameObject);

			istrigger = true;

			BattleScene._bulletNum--;

			GameObject otherObject = other.gameObject;
			Bullet otherBuller=otherObject.GetComponent<Bullet>();
		

			string path = "Prefab/bullet";
			GameObject obj = Resources.Load(path) as GameObject;

                Debug.Log("back");

                bullet3 = GameObject.Instantiate(obj);
			bullet3.transform.SetParent(transform.parent.parent.transform, false);
			bullet3.transform.position = otherObject.transform.position;
			b_bullet3 = bullet3.AddComponent<Bullet>();
			b_bullet3.right = otherBuller.right;
			BattleScene._bulletNum++;

             GameObject parentGm=   transform.parent.gameObject;

                BaseMiddleObject baseMiddle = (BaseMiddleObject)parentGm.GetComponent<BaseMiddleObject>();
              //  baseMiddle.showNext();
            }
        }

}
}