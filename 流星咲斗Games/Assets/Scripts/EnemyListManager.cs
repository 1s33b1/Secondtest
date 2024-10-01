using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListManager : MonoBehaviour
{

    public List<Transform> EnemyList = new List<Transform>();//�߂��ɂ���G��ۑ����Ă���List�B�����Transform������int��GameObject������邱�Ƃ��ł���
    // Update is called once per frame
    void Update()//��ɏd�������Ă��Ȃ����`�F�b�N������
    {
        //���X�g���ŏd�������Ȃ��悤�ɂ���
        for(int i = 0; i < EnemyList.Count; i++)
        {
            //���̂�����r����
            for(int k = i + 1;k < EnemyList.Count; k++)
            {
                //�d�����Ă�����폜����
                if (EnemyList[i] == EnemyList[k])
                {
                    EnemyList.RemoveAt(i);
                }
            }
            //�G���폜�ς݂Ȃ烊�X�g����폜����
            if (!EnemyList[i])
            {
                EnemyList.RemoveAt (i);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")//�������Ă����^�O��Enemy��������EnemyList�ɉ�����
        {
            EnemyList.Add(other.gameObject.transform);
        }
    }
    //OnTriggerEnter�������ƈ��ǉ����ꂽList�������Ȃ��܂ܒǉ�������ςȂ��ɂȂ邩��OnTriggerExit���g��
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //0�Ԗڂ��珇�Ƀ`�F�b�N���Ă���
            for(int i = 0; i < EnemyList.Count;i++)
            {
                //���X�g���瓯���G�������č폜����

                if (EnemyList[i] == other.gameObject.transform)
                {
                    EnemyList.RemoveAt(i);
                }
            }
        }
    }
}
