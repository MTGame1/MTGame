using UnityEngine;
using System.Collections;
namespace Assets.Script
{
public class BulletMovUp : MonoBehaviour {
	private bool istrigger = false;
	private GameObject bullect;
	private GameObject myparent;
		private GameObject bullet1;

		private Bullet b_bullet1;
	

	// Use this for initialization
	void Start () {
		
		string path3 = "Prefab/zidan";
		this.bullect = Resources.Load(path3) as GameObject;


	}
	
	// Update is called once per frame
	void Update () {
			if(bullet1){
				if (b_bullet1.right) {
					bullet1.transform.localPosition = new Vector3 (bullet1.transform.localPosition.x + 600f * Time.deltaTime, bullet1.transform.localPosition.y+ 300f * Time.deltaTime, bullet1.transform.localPosition.z);
				} else {
					bullet1.transform.localPosition = new Vector3 (bullet1.transform.localPosition.x - 600f * Time.deltaTime, bullet1.transform.localPosition.y+ 300f * Time.deltaTime, bullet1.transform.localPosition.z);

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
			bullet1 = GameObject.Instantiate(obj);
			bullet1.transform.SetParent(transform.parent.transform, false);
			bullet1.transform.position = otherObject.transform.position;

			b_bullet1 = bullet1.AddComponent<Bullet>();
			b_bullet1.right = otherBuller.right;
			BattleScene._bulletNum++;

	


        }
	}

}
}