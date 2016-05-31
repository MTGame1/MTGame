using UnityEngine;
using System.Collections;
namespace Assets.Script
{
	public class BaseMiddleObject : MonoBehaviour {

        public bool isShowed = false;
        public int index = 0;
        public static int showCount=0;

        public static int typeCount = 2;
        // Use this for initialization
        void Start () {
			
			

		}
		
		// Update is called once per frame
		void Update () {
				


		}
		public void hideMiddle(){
            if (showCount < 5) {
                return;
            }
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -200f);
            this.isShowed = false;
            showCount--;
        }

        public void showMiddle()
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f);
            this.isShowed = true;
            showCount++;
        }
        public void showNext()
        {
            this.hideMiddle();

            int currentShow = UnityEngine.Random.Range(0, BattleScene.middlePos.Length/2 - showCount);
            Debug.Log("currentShow"+ currentShow);

            for (int i = 0; i < currentShow; i++) {
                int nextIndex = UnityEngine.Random.Range(0, BattleScene.middlePos.Length/2 - 1);//展示的下一个
                int typeIndex = UnityEngine.Random.Range(0, typeCount);//展示的下一个
                Debug.Log("typeIndex" + typeIndex);
                Debug.Log("nextIndex" + nextIndex);

                if (BattleScene.middleList[nextIndex][0].isShowed==false&& BattleScene.middleList[nextIndex][1].isShowed == false) {
                    Debug.Log("jinrule" );

                    BattleScene.middleList[nextIndex][typeIndex].showMiddle();
                }
             }

        }



    }



}