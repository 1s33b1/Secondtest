using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListManager : MonoBehaviour
{

    public List<Transform> EnemyList = new List<Transform>();//近くにいる敵を保存していくList。今回はTransformだけどintやGameObjectも入れることができる
    // Update is called once per frame
    void Update()//常に重複をしていないかチェックをする
    {
        //リスト内で重複をしないようにする
        for(int i = 0; i < EnemyList.Count; i++)
        {
            //次のやつから比較する
            for(int k = i + 1;k < EnemyList.Count; k++)
            {
                //重複していたら削除する
                if (EnemyList[i] == EnemyList[k])
                {
                    EnemyList.RemoveAt(i);
                }
            }
            //敵が削除済みならリストから削除する
            if (!EnemyList[i])
            {
                EnemyList.RemoveAt (i);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")//当たってきたタグがEnemyだったらEnemyListに加える
        {
            EnemyList.Add(other.gameObject.transform);
        }
    }
    //OnTriggerEnterだけだと一回追加されたListが消えないまま追加されっぱなしになるからOnTriggerExitを使う
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //0番目から順にチェックしていく
            for(int i = 0; i < EnemyList.Count;i++)
            {
                //リストから同じ敵を見つけて削除する

                if (EnemyList[i] == other.gameObject.transform)
                {
                    EnemyList.RemoveAt(i);
                }
            }
        }
    }
}
