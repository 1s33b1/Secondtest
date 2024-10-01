using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float Enemyspeed;
    GameObject Target; //�Q�[���I�u�W�F�N�g��Target�̐錾
    float Timer;
    public float Changetime;

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.zero;
        speed.z = Enemyspeed;
        var rot = transform.eulerAngles;//�G�̉�]�������ɕۑ�����

        if (Target)
        {
            transform.LookAt(Target.transform);//����Target�̒��Ƀv���C���[�������Ă�����(LookAt:����̏ꍇTarget.transform�̍��W�̕��Ɍ���)
            rot = transform.eulerAngles;//�v���C���[�̕�����rot�̏㏑��������
        }
        else
        {
            Timer += Time.deltaTime;
            if (Changetime <= Timer)//������rot�̏㏑��������
            {
                float rand = Random.Range(0, 360);//0�`360�̐��l�������ɓ���
                rot.y = rand;//Target���R���C�_�[�̒��ɂ��Ȃ�������rot�ɂ̓����_���Ȓl����������
                Timer = 0;
            }
        }
        rot.x = 0;//x�̉�]���[���ɂ���
        rot.z = 0;//z�̉�]���[���ɂ���
        transform.eulerAngles = rot;//��]�ɂ�����ۑ�����x��z��0�ɂ��邩��c�Ɉړ����邱�Ƃ͂Ȃ�
        this.transform.Translate(speed); //Enemyspeed�̐��l�̕������ړ�����
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") //�������Ă����I�u�W�F�N�g��Player��������Target��Player������
        {
            Target = other.gameObject;

        }
    }

    private void OnTriggerExit(Collider other)//OnTriggerExit�͔͈͊O�ɏo�čs�����Ƃ��̃��\�b�h
    {
        if (other.tag == "Player")
        {
            Target = null; //����͈̔͊O��Target���s�����Ƃ�Target�̒�������(��������Ȃ��Ƃ����ƒǂ��������邩��)
        }
    }
}
