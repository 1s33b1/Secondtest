using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Camera;
    public float playspeed;
    public float Rotationspeed;
    Vector3  speed = Vector3.zero;
    Vector3 rot = Vector3.zero;//カメラとかの角度を入れておくもの
    public Animator PlayerAnimator;
    bool isRun;
    bool canMove = true;//最初は動けるようにしておく
    public Collider WeaponCollider;
    public AudioSource source;
    public AudioClip Attacksound;
    public EnemyListManager enemylistmanager;
    public Transform Target;//敵を入れておくロックオンする敵を入れる
    int  TargetCount;//リストの中のどの敵の方向を向くための番号

    // Update is called once per frame
    void Update()
    {
        Move();//void MoveをUpdateで使えるようにする
        Rotation();//void RotationをUpdateで使えるようにする
        Attack();
        TargetLook();
        Camera.transform.position = transform.position; //カメラの座標に追従してくださいっていう処理
    }
    private void Move()
    {
        if(!canMove)//canMoveがfalseだったら
        {
            return;//ここで処理が止まる
        }
        speed = Vector3.zero;
        rot = Vector3.zero;
        isRun = false;


        if (Input.GetKey(KeyCode.W))
        {
            rot.y = 0;
            Moveset();

        }
        if (Input.GetKey(KeyCode.S))
        {
            rot.y = 180;
            Moveset();

        }
        if (Input.GetKey(KeyCode.A))
        {
            rot.y = -90;
            Moveset();

        }
        if (Input.GetKey(KeyCode.D))
        {
            rot.y = 90;
            Moveset();

        }
        transform.Translate(speed);
        PlayerAnimator.SetBool("Run", isRun); //PlayerAnimatorにセットされてるアニメーターのフラグが立ってるかどうかの確認
    }
    private void Moveset()
    {
        speed.z = playspeed;
        transform.eulerAngles = Camera.eulerAngles + rot;//自分の向いてる方向はカメラの向いている方向にrotの足された値を足したもの
        isRun = true;
    }
    void Rotation()
    {
        var speed = Vector3.zero;//型からコンパイラーが推測をしてくれる※初期化する時しか使えない
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed.y = -Rotationspeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed.y = Rotationspeed;
        }
        Camera.transform.eulerAngles += speed; //カメラの角度はeulerangleにspeedを足したもの
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAnimator.SetBool("Attack", true);//スペースキーが押されたときにアニメーターにある"Attack"のフラグをオンにする
            canMove = false;//Attackが実行されたときにプレイヤーを動かせなくする
            source.PlayOneShot(Attacksound);//attackを実行したときに一回攻撃サウンドを実行する
        }
    }
    void WeaponON()
    {
        WeaponCollider.enabled = true;//WeaponCollierを使えるよう(enabled)にするスクリプト
    }

    void WeaponOFF()
    {
        WeaponCollider.enabled = false;//WeaponONのtrueになったものをfalseにするスクリプト
        PlayerAnimator.SetBool("Attack", false);//void Attackにあるアニメーターがずっとtrueのまんまでループするからここでfalseに変更をする
    }

    void CanMove()
    {
        canMove = true;//ここの処理にいったら動くことができる
    }

    void TargetLook()
    {
        //ターゲットをセットする
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //リストがゼロなら止める
            if (enemylistmanager.EnemyList.Count == 0)
            {
                return;//敵が近くにいなかったら処理を止める
            }

            //リストの数をカウントが越えたらリセット
            if (enemylistmanager.EnemyList.Count <= TargetCount)
                //一番目→二番目っていう感じに違うターゲットを向く時に使う
            {
                TargetCount = 0;
            }
            //ターゲットをリストからリセットする。ターゲット変数にEnemyListのオブジェクトを入れる
            Target = enemylistmanager.EnemyList[TargetCount];
            //カウントを進める
            TargetCount++;
        }

        //ロックを解除する
        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            Target = null;//右コントロールを押したときに敵の方を向かないようにする
        }

        if(Target)
        {
            //ターゲットの座標を保管する
            var pos = Vector3.zero;
            pos = Target.position;
            //カメラが上下しないように高さはカメラを基準にする。高低差があったりするとカメラがおかしくなるかもしれない
            pos.y = Camera.transform.position.y;

            //ターゲットを見る
            Camera.transform.LookAt(pos);
        }
    }
}
