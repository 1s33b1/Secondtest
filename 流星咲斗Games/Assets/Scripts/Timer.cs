using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float Timercount = 60;
    [SerializeField] Text Timertext;
    [SerializeField] GameObject Clearwindow;

    // Update is called once per frame
    void Update()
    {
        Timercount -= Time.deltaTime;//カウントダウン方式
        Timertext.text = ((int)Timercount).ToString();//Timercountをストリング型で表示をする(float型のTimercountをint型に変換をしている)

        if(Timercount <= 0)
        {
            Clearwindow.SetActive(true);
            Time.timeScale = 0;//Timercountがゼロになったらタイマーを動かさない(ダメージをもらわないし判定も特にない状態になる)
            enabled = false;//このスクリプトをfalseにする

        }
    }
}
