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
        if(!Player)//�v���C���[������ő��݂��Ă��Ȃ�������
        {
            GameOverCanvas.SetActive(true);//�v���C���[�����݂��Ă��Ȃ�������Q�[���I�[�o�[�L�����o�X��\��������
        }
        
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//�����[�h���Ă���V�[�����������ǂݍ���
        //SceneManager.LoadScene("�V�[����")�ł����܂�Ȃ����ǃQ�[���I�[�o�[�̃V�[���ɑJ�ڂ���킯�ł��Ȃ��������̂�ł���

    }
}
