using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    //开始按钮
    [SerializeField] private Button openButton;
    //宝箱界面
    [SerializeField] private Image boxImage;
    /// <summary>
    /// openButton的点击事件，激活宝箱界面
    /// </summary>
    public void OpenViewOnCLick()
    {
        openButton.gameObject.SetActive(false);
        boxImage.gameObject.SetActive(true);
    }
    /// <summary>
    /// 初始化激活状态
    /// </summary>
    void Start()
    {
        boxImage.gameObject.SetActive(false);
    }
}
