using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float Timercount = 60;
    [SerializeField] Text Timertext;
    [SerializeField] GameObject Clearwindow;

    // Update is called once per frame
    void Update()
    {
        Timercount -= Time.deltaTime;//�J�E���g�_�E������
        Timertext.text = ((int)Timercount).ToString();//Timercount���X�g�����O�^�ŕ\��������(float�^��Timercount��int�^�ɕϊ������Ă���)

        if(Timercount <= 0)
        {
            Clearwindow.SetActive(true);
            Time.timeScale = 0;//Timercount���[���ɂȂ�����^�C�}�[�𓮂����Ȃ�(�_���[�W�������Ȃ�����������ɂȂ���ԂɂȂ�)
            enabled = false;//���̃X�N���v�g��false�ɂ���

        }
    }
}
