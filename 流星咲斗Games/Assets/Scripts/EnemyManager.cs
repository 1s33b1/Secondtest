using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy1;//�G�̃I�u�W�F�N�g������Ƃ���
    public GameObject Enemy2;//�G�̃I�u�W�F�N�g������Ƃ���

    public Transform EnemyPlace1;//�G���N���Ă��鏊
    public Transform EnemyPlace2;
    float timer;
    public int Maxcount;
    public int Count;
    void Update()
    {
        if (Maxcount <= Count)
        {
            return;//�������I��点��(����ȏ㏈���͐i�܂Ȃ�)
        }

        timer += Time.deltaTime;//�^�C�}�[���v���X���Ă�����
        if(timer > 3)//�^�C�}�[��4�ɂȂ����牺�̐����v���O���������s����
        { 
            Instantiate(Enemy1, EnemyPlace1.position, Quaternion.identity);//Quaternion.identity:��]�̓[���ɂ���Ƃ����Ӗ��BEnemyPlace�̐ݒ肵���ꏊ(position)��Enemy1�𐶐�����
            Count++;

            Instantiate(Enemy2, EnemyPlace2.position, Quaternion.identity);//Quaternion.identity:��]�̓[���ɂ���Ƃ����Ӗ��BEnemyPlace�̐ݒ肵���ꏊ(position)��Enemy1�𐶐�����
            Count++;//�ꂸ�����Ă���

            timer = 0;//�l��0�ɖ߂�
        }

    }
}
