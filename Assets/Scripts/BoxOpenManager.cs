using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading;
public class BoxOpenManager : MonoBehaviour
{
    //紫色宝箱打开闪耀特效
    [SerializeField] private GameObject Shop_TreasureChest_Purple;
    //开始按钮
    [SerializeField] private Button openButton;
    //宝箱界面
    [SerializeField] private Image boxImage;
    //宝箱打开和关闭
    [SerializeField] private Image boxOpen;
    [SerializeField] private Image boxClose;
    //金币动画预制件
    [SerializeField] private GameObject moveCoinPerfab;
    //计数
    private int createMoveCoinCount = 0;
    private int createMoveCoinSum = 1;
    //点击次数
     private int count = 0;
     //金币个数
     private int coinCount = 5;
     //金币总数
     private int coinSum=100;
     //编辑金币数的Text
     public Text coinSumText;
     private bool isOn=true;
     private GameObject newGameObject;
     //初始化金币text
    void Start()
    {
        //初始化金币信息
        coinSumText.text=coinSum.ToString();
        boxImage.gameObject.SetActive(false);
    }
    
    /// <summary>
    /// 打开宝箱方法，控制包厢打开
    /// 激活特效
    /// 如果已经播放三次，就只是增加金币
    /// 调用实例化金币的帧动画方法
    /// </summary>
    public void OpenBox()
    {
        if (isOn)
        {
            isOn = false;
            Instantiate(Shop_TreasureChest_Purple, boxOpen.gameObject.transform);
        } 
        boxClose.gameObject.SetActive(false);
        boxOpen.gameObject.SetActive(true);
        if (count >= 3)
        {
            for (int i = 0; i < coinCount*(count+1); i++)
            {
                AddCoinSum();
            }
            count++;
            return;
        }
        count++;
        CreateMoveCoin();
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
        newGameObject = Instantiate(moveCoinPerfab, transform) as GameObject;
        Invoke("MoveCoin",0.2f);
        Invoke("CreateMoveCoin",0.2f);
    }
    //移动金币至顶部
    public void MoveCoin()
    {
        newGameObject.transform.DOLocalMoveY(850,1);
        Invoke("AddCoinSum",1);
    }
    //增减金币数，每次增加一个
    public void AddCoinSum()
    {
        coinSum++;
        coinSumText.text = coinSum.ToString();
    }
    //openButton的点击事件，激活宝箱界面
    public void openOnCLick()
    {
        openButton.gameObject.SetActive(false);
        boxImage.gameObject.SetActive(true);
        boxOpen.gameObject.SetActive(false);
    }
}
