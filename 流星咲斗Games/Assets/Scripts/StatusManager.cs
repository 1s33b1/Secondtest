using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public GameObject Main; //敵のオブジェクトを入れる場所
    [SerializeField] int HP;
    [SerializeField] int MaxHP;
    [SerializeField] int Score;
    public float ReSetTime = 0;
    public Image HPGage;//HPゲージのUIを入れるところ
    [SerializeField] GameObject Effect;
    public AudioSource audiosource;//音を入れるところ
    public AudioClip HitSE;//敵に当たった時に鳴らすaudioを入れるところ(今回の場合打撃音)
    Collider collider;//←の前はpublic Collider colliderで割り振ることができた
    public string TagName;//エディター上で設定できる文字列

    private void Start()
    {
        collider = GetComponent<Collider>(); //自動的にこのオブジェクトについているColliderを付けてくれる(※GetComponent自体処理としては重いからエディター上でいじる方がいい)
    }

    private void Update()
    {
        if(HP <= 0)
        {
            HP = 0;
            var effect = Instantiate(Effect);//effectにEffectを代入しておく
            effect.transform.position = transform.position;//敵の死んだ場所をeffectに知らせる
            GameObject.Find("GameSystem").GetComponent<GameSystemManager>().Score += Score;//エディターのヒエラルキーから"GameSystem"っていうオブジェクトを探してねっていう意味
            //↑ヒエラルキーから指定したオブジェクトを探す→コンポーネントとしてそのオブジェクトに入っているものを取得する→GameSystemの方に入っているScoreに加算をしていく
            Destroy(effect, 5);//５秒後にエフェクトをDestroyする
            Destroy(Main);//Mainに入っているオブジェクトを破壊する
        }

        float percent = (float)HP / MaxHP; //(float)はもともとint型のものをfloat型にキャスト(置き換えする)するというもの
        HPGage.fillAmount = percent;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagName)//当たったオブジェクトのタグネームに指定されたものだったら
        {
            Damage();//void Damgeのスクリプトを実行する
            collider.enabled = false;//colliderのアクティブ状態をfalseにする(ボックスコライダーがオフになる)当たり判定は無敵状態(ダメージをもらってすぐの時だから)
            Invoke("ColliderReSet", ReSetTime);//ダメージをもらう→Damege()が実行される→colliderがfalseになる→引数にあるReSetTime(秒)後にColliderReSetが実行される
            //Invokeを使うことで実行するタイミングをすぐにするのではなく設定することができる
        }
    }

    void Damage()
    {
        audiosource.PlayOneShot(HitSE);//PlayOneShot:敵を倒して一回だけaudiosourceのHitSEを鳴らす
        HP--;//HPを一ずつ減らしていく
    }

    void ColliderReSet()
    {
        collider.enabled = true;//colliderのアクティブ状態をtrueにする(ボックスコライダーがオンになる)当たり判定がある状態

    }

}
