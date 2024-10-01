using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy1;//敵のオブジェクトを入れるところ
    public GameObject Enemy2;//敵のオブジェクトを入れるところ

    public Transform EnemyPlace1;//敵が湧いてくる所
    public Transform EnemyPlace2;
    float timer;
    public int Maxcount;
    public int Count;
    void Update()
    {
        if (Maxcount <= Count)
        {
            return;//処理を終わらせる(これ以上処理は進まない)
        }

        timer += Time.deltaTime;//タイマーをプラスしていって
        if(timer > 3)//タイマーが4になったら下の生成プログラムを実行する
        { 
            Instantiate(Enemy1, EnemyPlace1.position, Quaternion.identity);//Quaternion.identity:回転はゼロにするという意味。EnemyPlaceの設定した場所(position)にEnemy1を生成する
            Count++;

            Instantiate(Enemy2, EnemyPlace2.position, Quaternion.identity);//Quaternion.identity:回転はゼロにするという意味。EnemyPlaceの設定した場所(position)にEnemy1を生成する
            Count++;//一ずつ足していく

            timer = 0;//値を0に戻す
        }

    }
}
