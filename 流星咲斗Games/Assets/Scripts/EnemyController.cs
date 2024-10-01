using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float Enemyspeed;
    GameObject Target; //ゲームオブジェクトのTargetの宣言
    float Timer;
    public float Changetime;

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.zero;
        speed.z = Enemyspeed;
        var rot = transform.eulerAngles;//敵の回転をここに保存する

        if (Target)
        {
            transform.LookAt(Target.transform);//もしTargetの中にプレイヤーが入っていたら(LookAt:今回の場合Target.transformの座標の方に向く)
            rot = transform.eulerAngles;//プレイヤーの方向でrotの上書きをする
        }
        else
        {
            Timer += Time.deltaTime;
            if (Changetime <= Timer)//乱数でrotの上書きをする
            {
                float rand = Random.Range(0, 360);//0～360の数値がここに入る
                rot.y = rand;//Targetがコライダーの中にいなかったらrotにはランダムな値が代入される
                Timer = 0;
            }
        }
        rot.x = 0;//xの回転をゼロにする
        rot.z = 0;//zの回転をゼロにする
        transform.eulerAngles = rot;//回転にここを保存してxとzを0にするから縦に移動することはない
        this.transform.Translate(speed); //Enemyspeedの数値の分だけ移動する
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") //当たってきたオブジェクトがPlayerだったらTargetにPlayerを入れる
        {
            Target = other.gameObject;

        }
    }

    private void OnTriggerExit(Collider other)//OnTriggerExitは範囲外に出て行ったときのメソッド
    {
        if (other.tag == "Player")
        {
            Target = null; //判定の範囲外にTargetが行ったときTargetの中を消す(そうじゃないとずっと追いかけられるから)
        }
    }
}
