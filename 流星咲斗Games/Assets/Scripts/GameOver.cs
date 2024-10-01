using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public GameObject GameOverCanvas;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(!Player)//プレイヤーが死んで存在していなかったら
        {
            GameOverCanvas.SetActive(true);//プレイヤーが存在していなかったらゲームオーバーキャンバスを表示させる
        }
        
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//今ロードしているシーンをもう一回読み込む
        //SceneManager.LoadScene("シーン名")でもかまわないけどゲームオーバーのシーンに遷移するわけでもなかったら上のやつでいい

    }
}
