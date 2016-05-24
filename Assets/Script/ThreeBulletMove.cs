using UnityEngine;
using System.Collections;

public class ThreeBulletMove : MonoBehaviour {
	private bool istrigger = false;
	private GameObject bullect;
	private GameObject myparent;
	private Rigidbody2D rigid1;
	private Rigidbody2D rigid2;
	private Rigidbody2D rigid3;

	// Use this for initialization
	void Start () {
		
		string path3 = "Prefab/zidan";
		this.bullect = Resources.Load(path3) as GameObject;
		this.myparent = GameObject.Find("BattleScene") as GameObject;

	}
	
	// Update is called once per frame
	void Update () {
		
		//Rigidbody2D rigid=((GameObject)GameObject.Instantiate (bullect,new Vector2(0,0),Quaternion.identity)).GetComponent<Rigidbody2D>();
		//Rigidbody2D rigid=GameObject.Find("bullet").GetComponent<Rigidbody2D>();
		//rigid.velocity = new Vector2 (0, 1f);
		if (istrigger) {
			rigid1.velocity = new Vector2 (8,0f);
			rigid2.velocity = new Vector2 (8, 8f);
			rigid3.velocity = new Vector2 (8, -8f);
		} 
	}
	public void OnTriggerEnter2D(Collider2D  other){
		//if (other.name == "bu") {
			Debug.Log ("triger");
			Destroy (other.gameObject);

			istrigger = true;
			rigid1 = ((GameObject)GameObject.Instantiate (bullect, transform.position,Quaternion.Euler(0,0,0))).GetComponent<Rigidbody2D> ();
			rigid1.gameObject.transform.SetParent(myparent.transform,true);
            rigid1.gameObject.transform.localScale=new Vector3(60,60,0);

            Destroy (rigid1.gameObject.GetComponent<BoxCollider2D> ());
            rigid1.name="r1";


            rigid2 = ((GameObject)GameObject.Instantiate (bullect, new Vector2 (0, 2), Quaternion.Euler(0, 0, 45))).GetComponent<Rigidbody2D> ();
            rigid2.gameObject.transform.SetParent(myparent.transform,false);
            Destroy (rigid2.gameObject.GetComponent<BoxCollider2D> ());
            rigid2.name = "r2";
            rigid3 = ((GameObject)GameObject.Instantiate (bullect, new Vector2 (0, 2),Quaternion.Euler(0,0,-45))).GetComponent<Rigidbody2D> ();
            rigid3.gameObject.transform.SetParent(myparent.transform,false);
            Destroy (rigid3.gameObject.GetComponent<BoxCollider2D> ());
            	rigid3.name = "r3";
       // }
	}
}
