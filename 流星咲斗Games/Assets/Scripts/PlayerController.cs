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
    Vector3 rot = Vector3.zero;//�J�����Ƃ��̊p�x�����Ă�������
    public Animator PlayerAnimator;
    bool isRun;
    bool canMove = true;//�ŏ��͓�����悤�ɂ��Ă���
    public Collider WeaponCollider;
    public AudioSource source;
    public AudioClip Attacksound;
    public EnemyListManager enemylistmanager;
    public Transform Target;//�G�����Ă������b�N�I������G������
    int  TargetCount;//���X�g�̒��̂ǂ̓G�̕������������߂̔ԍ�

    // Update is called once per frame
    void Update()
    {
        Move();//void Move��Update�Ŏg����悤�ɂ���
        Rotation();//void Rotation��Update�Ŏg����悤�ɂ���
        Attack();
        TargetLook();
        Camera.transform.position = transform.position; //�J�����̍��W�ɒǏ]���Ă����������Ă�������
    }
    private void Move()
    {
        if(!canMove)//canMove��false��������
        {
            return;//�����ŏ������~�܂�
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
        PlayerAnimator.SetBool("Run", isRun); //PlayerAnimator�ɃZ�b�g����Ă�A�j���[�^�[�̃t���O�������Ă邩�ǂ����̊m�F
    }
    private void Moveset()
    {
        speed.z = playspeed;
        transform.eulerAngles = Camera.eulerAngles + rot;//�����̌����Ă�����̓J�����̌����Ă��������rot�̑����ꂽ�l�𑫂�������
        isRun = true;
    }
    void Rotation()
    {
        var speed = Vector3.zero;//�^����R���p�C���[�����������Ă���遦���������鎞�����g���Ȃ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed.y = -Rotationspeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed.y = Rotationspeed;
        }
        Camera.transform.eulerAngles += speed; //�J�����̊p�x��eulerangle��speed�𑫂�������
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAnimator.SetBool("Attack", true);//�X�y�[�X�L�[�������ꂽ�Ƃ��ɃA�j���[�^�[�ɂ���"Attack"�̃t���O���I���ɂ���
            canMove = false;//Attack�����s���ꂽ�Ƃ��Ƀv���C���[�𓮂����Ȃ�����
            source.PlayOneShot(Attacksound);//attack�����s�����Ƃ��Ɉ��U���T�E���h�����s����
        }
    }
    void WeaponON()
    {
        WeaponCollider.enabled = true;//WeaponCollier���g����悤(enabled)�ɂ���X�N���v�g
    }

    void WeaponOFF()
    {
        WeaponCollider.enabled = false;//WeaponON��true�ɂȂ������̂�false�ɂ���X�N���v�g
        PlayerAnimator.SetBool("Attack", false);//void Attack�ɂ���A�j���[�^�[��������true�̂܂�܂Ń��[�v���邩�炱����false�ɕύX������
    }

    void CanMove()
    {
        canMove = true;//�����̏����ɂ������瓮�����Ƃ��ł���
    }

    void TargetLook()
    {
        //�^�[�Q�b�g���Z�b�g����
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //���X�g���[���Ȃ�~�߂�
            if (enemylistmanager.EnemyList.Count == 0)
            {
                return;//�G���߂��ɂ��Ȃ������珈�����~�߂�
            }

            //���X�g�̐����J�E���g���z�����烊�Z�b�g
            if (enemylistmanager.EnemyList.Count <= TargetCount)
                //��Ԗځ���Ԗڂ��Ă��������ɈႤ�^�[�Q�b�g���������Ɏg��
            {
                TargetCount = 0;
            }
            //�^�[�Q�b�g�����X�g���烊�Z�b�g����B�^�[�Q�b�g�ϐ���EnemyList�̃I�u�W�F�N�g������
            Target = enemylistmanager.EnemyList[TargetCount];
            //�J�E���g��i�߂�
            TargetCount++;
        }

        //���b�N����������
        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            Target = null;//�E�R���g���[�����������Ƃ��ɓG�̕��������Ȃ��悤�ɂ���
        }

        if(Target)
        {
            //�^�[�Q�b�g�̍��W��ۊǂ���
            var pos = Vector3.zero;
            pos = Target.position;
            //�J�������㉺���Ȃ��悤�ɍ����̓J��������ɂ���B���፷���������肷��ƃJ���������������Ȃ邩������Ȃ�
            pos.y = Camera.transform.position.y;

            //�^�[�Q�b�g������
            Camera.transform.LookAt(pos);
        }
    }
}
