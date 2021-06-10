using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading;
public class BoxOpenManager : MonoBehaviour
{
    //编辑金币数的Text
    [SerializeField] private Text coinSumText;
    //紫色宝箱打开闪耀特效
    [SerializeField] private GameObject Shop_TreasureChest_Purple;
    //宝箱打开和关闭
    [SerializeField] private Image boxOpen;
    [SerializeField] private Image boxClose;
    //金币总数
    private int coinSum=100;
    //金币动画预制件
    [SerializeField] private GameObject moveCoinPerfab;
    //计数
    private int createMoveCoinCount = 0;
    private int createMoveCoinSum = 1;
    //点击次数
     private int count = 0;
     //金币个数
     private int coinCount = 5;
     //是否已经打开宝箱
     private bool alreadyOpenBox = false;
     //是否已经生成特效
     private bool alreadyCreateTreasureChest=false;
     //保存特效的对象
     private GameObject shopTreasureChestPurple;
     //金币帧动画的对象
     private GameObject newGameObject;
     //金币增加次数
     private int addCount = 0;
     
     /// <summary>
    /// 打开宝箱方法，控制包厢打开
    /// 激活特效
    /// 如果已经播放三次，不再增加转动的金币数
    /// 调用实例化金币的帧动画方法
    /// </summary>
    public void OpenBox()
    {
        if (alreadyOpenBox)
        {
            alreadyOpenBox = false;
            shopTreasureChestPurple.SetActive(false);
            closeBox();
            Invoke("CreateTreasureChest",0.3f);
            Invoke("OpenBox",0.3f);
            return;
        }
        CreateTreasureChest();
        shopTreasureChestPurple.SetActive(true);
        boxClose.gameObject.SetActive(false);
        boxOpen.gameObject.SetActive(true);
        count++;
        if (count == 4)
        {
            count--;
        }
        CreateMoveCoin();
        alreadyOpenBox = true;
    }
     
     /// <summary>
     /// 生成特效
     /// </summary>
     public void CreateTreasureChest()
    {
        if (alreadyCreateTreasureChest) return;
        shopTreasureChestPurple=Instantiate(Shop_TreasureChest_Purple, boxOpen.gameObject.transform);
        alreadyCreateTreasureChest = true;
    }


    /// <summary>
    /// 实例化金币的帧动画
    /// 循环调用自己
    /// 调用移动金币的函数
    /// </summary>
    public void CreateMoveCoin()
    {
        if (createMoveCoinCount == coinCount * count)
        {
            createMoveCoinCount = 0;
            return;
        }
        createMoveCoinCount++;
        newGameObject = Instantiate(moveCoinPerfab, transform);
        Destroy(newGameObject,1.4f);
        Invoke("MoveCoin",0.3f);
        Invoke("CreateMoveCoin",0.2f);
    }
    /// <summary>
    /// 移动金币至顶部
    /// </summary>
    public void MoveCoin()
    {
        newGameObject.transform.DOLocalMoveY(850,1);
        Invoke("AddCoinSum",1);
    }
    /// <summary>
    /// 增减金币数，每次增加一个
    /// </summary>
    public void AddCoinSum()
    {
        coinSum++;
        coinSumText.text = coinSum.ToString();
    }
    /// <summary>
    /// 关闭宝箱方法
    /// </summary>
    public void closeBox()
    {
        boxClose.gameObject.SetActive(true);
        boxOpen.gameObject.SetActive(false);
    }
    /// <summary>
    /// 初始化状态
    /// </summary>
    private void Start()
    {
        boxOpen.gameObject.SetActive(false);
    }
}
