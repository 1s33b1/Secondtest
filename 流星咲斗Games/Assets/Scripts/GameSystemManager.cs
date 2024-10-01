using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystemManager : MonoBehaviour
{
    public int Score;
    [SerializeField] Text Scoretext;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;//リトライしたときにタイマーをtrueにする
        
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = Score.ToString();//Scoretextをストリング型で表示する
        
    }
}
