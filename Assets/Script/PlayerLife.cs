using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerLife : MonoBehaviour
{
    private GameObject[] _lifesGo = new GameObject[MaxLifeValue];
    private Image[] _lifesImg = new Image[MaxLifeValue];

    private const int MaxLifeValue = 5;
    private int _curLifeValue = 5;

    private Sprite _blankLifeSp;
    private const string BlankLifePath = "newMaterial/figures/life_blank";

    void Awake()
    {
        InitWidget();
    }
	
	void Start () {
	
	}
	
	
	void Update () {
	
	}

    private void InitWidget()
    {
        _blankLifeSp = LoadSprite(BlankLifePath);

        for (int i = 0;i < MaxLifeValue;i++)
        {
            var go = transform.Find("life" + i.ToString()).gameObject;
            _lifesGo[i] = go;
            _lifesImg[i] = go.GetComponent<Image>();
        }
    }

    private Image _curLifeImg;
    public void UpdateLife()
    {
        if (_curLifeValue <= 0 || _curLifeValue > MaxLifeValue)
        {
            return;
        }

        var img = _lifesImg[MaxLifeValue - _curLifeValue];
        //心闪动tween效果 
        Sequence lifeSequence = DOTween.Sequence();
        lifeSequence.Append(img.transform.DOScale(Vector3.zero, 0.5f).SetDelay(0.1f))
            .Insert(0, DOTween.ToAlpha(() => img.color, x => img.color = x, 0f, 0.5f)).OnComplete(AfterLifeTweening);
    }

    private void AfterLifeTweening()
    {
        var img = _lifesImg[MaxLifeValue - _curLifeValue];
        //心形图片改变
        ChangeImage(img, _blankLifeSp);

        Sequence blankLifeSequence = DOTween.Sequence();
        blankLifeSequence.Append(img.transform.DOScale(Vector3.one, 0.3f))
            .Insert(0, DOTween.ToAlpha(() => img.color, x => img.color = x, 1f, 0.3f));

        --_curLifeValue;
        if (_curLifeValue == 0)
        {
            //失败结束 todo...

        }
        if (_curLifeValue <= 2)
        {
            //变红效果 todo...

        }
    }

    private void ChangeImage(Image src,Sprite sp)
    {
        if (src == null || sp == null)
        {
            return;
        }

        src.overrideSprite = sp;
    }

    private Sprite LoadSprite(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return null;
        }

        Sprite sp = Resources.Load(path, typeof(Sprite)) as Sprite;

        return sp;
    }
}
