using UnityEngine;
using System.Collections;
using System;

namespace Assets.Script
{
    public class SceneManager : MonoBehaviour
    {
        public GameObject _sceneObject;
        private GameObject _currentScene;
        private BaseScene _baseScene;
        public Canvas UIList{get;set;}
        public Canvas PopList{get;set;}

        public static SceneManager Instance
        {
            get;
            set;
        }

        public SceneManager()
        {
            Instance = this;
        }
        void Start()
        {

            Initialize();

        }


        void Update()
        {


        }

        public void Initialize()
        {
            DontDestroyOnLoad(this.gameObject);

            Canvas[] canvas = _sceneObject.GetComponentsInChildren<Canvas>();
            UIList = canvas[0];
            PopList = canvas[1];

            EnterFirstScene();
        }

        public static SceneManager GetInstance()
        {
            return Instance;
        }

        private  void EnterFirstScene()
        {
            _currentScene = UIList.transform.GetChild(0).gameObject;
            GameStartScene dd = _currentScene.AddComponent<GameStartScene>() as GameStartScene;
            dd.Initialize();
        }

        public void ShowScene<T>(String sceneNama)
        {
            ReleaseLastScene();
            Type sceneType = typeof(T);
            string path = "Scene/" + sceneNama;
            GameObject obj = Resources.Load(path) as GameObject;
            _currentScene = GameObject.Instantiate(obj);
            _currentScene.transform.SetParent(UIList.transform, false);

            _baseScene = _currentScene.AddComponent(sceneType) as BaseScene;
            _baseScene.Initialize();
        }

        private void ReleaseLastScene()
        {
            if(_currentScene != null)
            {
                GameObject.Destroy(_currentScene);
            }
        }
    }
}

