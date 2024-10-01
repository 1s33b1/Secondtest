using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public GameObject Main; //�G�̃I�u�W�F�N�g������ꏊ
    [SerializeField] int HP;
    [SerializeField] int MaxHP;
    [SerializeField] int Score;
    public float ReSetTime = 0;
    public Image HPGage;//HP�Q�[�W��UI������Ƃ���
    [SerializeField] GameObject Effect;
    public AudioSource audiosource;//��������Ƃ���
    public AudioClip HitSE;//�G�ɓ����������ɖ炷audio������Ƃ���(����̏ꍇ�Ō���)
    Collider collider;//���̑O��public Collider collider�Ŋ���U�邱�Ƃ��ł���
    public string TagName;//�G�f�B�^�[��Őݒ�ł��镶����

    private void Start()
    {
        collider = GetComponent<Collider>(); //�����I�ɂ��̃I�u�W�F�N�g�ɂ��Ă���Collider��t���Ă����(��GetComponent���̏����Ƃ��Ă͏d������G�f�B�^�[��ł������������)
    }

    private void Update()
    {
        if(HP <= 0)
        {
            HP = 0;
            var effect = Instantiate(Effect);//effect��Effect�������Ă���
            effect.transform.position = transform.position;//�G�̎��񂾏ꏊ��effect�ɒm�点��
            GameObject.Find("GameSystem").GetComponent<GameSystemManager>().Score += Score;//�G�f�B�^�[�̃q�G�����L�[����"GameSystem"���Ă����I�u�W�F�N�g��T���Ă˂��Ă����Ӗ�
            //���q�G�����L�[����w�肵���I�u�W�F�N�g��T�����R���|�[�l���g�Ƃ��Ă��̃I�u�W�F�N�g�ɓ����Ă�����̂��擾���遨GameSystem�̕��ɓ����Ă���Score�ɉ��Z�����Ă���
            Destroy(effect, 5);//�T�b��ɃG�t�F�N�g��Destroy����
            Destroy(Main);//Main�ɓ����Ă���I�u�W�F�N�g��j�󂷂�
        }

        float percent = (float)HP / MaxHP; //(float)�͂��Ƃ���int�^�̂��̂�float�^�ɃL���X�g(�u����������)����Ƃ�������
        HPGage.fillAmount = percent;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagName)//���������I�u�W�F�N�g�̃^�O�l�[���Ɏw�肳�ꂽ���̂�������
        {
            Damage();//void Damge�̃X�N���v�g�����s����
            collider.enabled = false;//collider�̃A�N�e�B�u��Ԃ�false�ɂ���(�{�b�N�X�R���C�_�[���I�t�ɂȂ�)�����蔻��͖��G���(�_���[�W��������Ă����̎�������)
            Invoke("ColliderReSet", ReSetTime);//�_���[�W�����炤��Damege()�����s����遨collider��false�ɂȂ遨�����ɂ���ReSetTime(�b)���ColliderReSet�����s�����
            //Invoke���g�����ƂŎ��s����^�C�~���O�������ɂ���̂ł͂Ȃ��ݒ肷�邱�Ƃ��ł���
        }
    }

    void Damage()
    {
        audiosource.PlayOneShot(HitSE);//PlayOneShot:�G��|���Ĉ�񂾂�audiosource��HitSE��炷
        HP--;//HP���ꂸ���炵�Ă���
    }

    void ColliderReSet()
    {
        collider.enabled = true;//collider�̃A�N�e�B�u��Ԃ�true�ɂ���(�{�b�N�X�R���C�_�[���I���ɂȂ�)�����蔻�肪������

    }

}
