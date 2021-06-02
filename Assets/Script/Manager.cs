using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading;
public class Manager : MonoBehaviour
{
    //紫色宝箱打开闪耀特效
    public GameObject Shop_TreasureChest_Purple;
    //开始按钮
    public Button openButton;
    //宝箱界面
    public Image boxImage;

    //宝箱打开和关闭
    public Image boxOpen;
    public Image boxClose;

    //金币移动的目的地
    public RectTransform TargetReckTransform;

    //金币的五个旋转角度预置体
     public GameObject moveCoin1;
     public GameObject moveCoin2;
     public GameObject moveCoin3;
     public GameObject moveCoin4;
     public GameObject moveCoin5;

     //点击次数
     private int count=0;
     //金币个数
     private int coinCount=0;
     //金币总数
     private int coinSum=100;
     //编辑金币数的Text
     public Text coinSumText;

     //五个金币的预置件定义
     private GameObject newGameObject1;
     private GameObject newGameObject2;
     private GameObject newGameObject3;
     private GameObject newGameObject4;
     private GameObject newGameObject5;
    //初始化金币text
    void Start()
    {
        //初始化金币信息
        coinSumText.text=coinSum.ToString();
        boxImage.gameObject.SetActive(false);
    }

    //点击购买生成五个预置件并移动到目的地
    public void openBox()
    {
        //播放特效
        Instantiate(Shop_TreasureChest_Purple,boxOpen.gameObject.transform);
        boxClose.gameObject.SetActive(false);
        boxOpen.gameObject.SetActive(true);
        if(count==3)return;
        count++;
        newGameObject1=Instantiate(moveCoin1,transform)as GameObject;
        Invoke("onClick2",0.2f);
    }

    //没有找到sleep的方法，所以只能依次用Invoke调用一个一个生成金币，并一个一个调用DOTween来网上移动金币。
     public void onClick2()
    {
        newGameObject2=Instantiate(moveCoin2,transform)as GameObject;
        Invoke("onClick3",0.2f);
    }
    public void onClick3()
    {
        newGameObject3=Instantiate(moveCoin3,transform)as GameObject;
        Invoke("onClick4",0.2f);
    }
    public void onClick4()
    {
        newGameObject4=Instantiate(moveCoin4,transform)as GameObject;
        Invoke("onClick5",0.2f);
    }
    public void onClick5()
    {
        newGameObject5=Instantiate(moveCoin5,transform)as GameObject;
        Invoke("doMoveCoin1",0);
    }

    public void doMoveCoin1()
    {
        RectTransform moveCoin1RectTransform=newGameObject1.GetComponent<RectTransform>();
        moveCoin1RectTransform.DOLocalMoveY(850,1);
        Invoke("doMoveCoin2",0.2f);
    }
    public void doMoveCoin2()
    {
        RectTransform moveCoin2RectTransform=newGameObject2.GetComponent<RectTransform>();
        moveCoin2RectTransform.DOLocalMoveY(850,1);
        Invoke("doMoveCoin3",0.2f);
    }
    public void doMoveCoin3()
    {
        RectTransform moveCoin3RectTransform=newGameObject3.GetComponent<RectTransform>();
        moveCoin3RectTransform.DOLocalMoveY(850,1);
        Invoke("doMoveCoin4",0.2f);
    }
    public void doMoveCoin4()
    {
        RectTransform moveCoin4RectTransform=newGameObject4.GetComponent<RectTransform>();
        moveCoin4RectTransform.DOLocalMoveY(850,1);
        Invoke("doMoveCoin5",0.2f);
    }
    public void doMoveCoin5()
    {
        RectTransform moveCoin5RectTransform=newGameObject5.GetComponent<RectTransform>();
        Tweener tweener = moveCoin5RectTransform.DOLocalMoveY(850,1);
        tweener.OnComplete(destoryCoinPerfabs);
        coinCount=0;
        Invoke("addCoinSum",0.5f);
    }

    //动画播放完隐藏生成的金币预置件
    public void destoryCoinPerfabs()
    {
        newGameObject1.SetActive(false);
        newGameObject2.SetActive(false);
        newGameObject3.SetActive(false);
        newGameObject4.SetActive(false);
        newGameObject5.SetActive(false);
    }
    //更改显示金币数目
    public void addCoinSum()
    {
        if(coinCount>=5)return;
        coinCount++;
        coinSum++;
        coinSumText.text=coinSum.ToString();
        Invoke("addCoinSum",0.2f);
    }

    //点击Open按钮后显示宝箱视图
    public void openOnCLick()
    {
        openButton.gameObject.SetActive(false);
        boxImage.gameObject.SetActive(true);
        boxOpen.gameObject.SetActive(false);
    }
}
