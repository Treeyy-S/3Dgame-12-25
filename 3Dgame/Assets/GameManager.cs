using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Vector3 mousePos;
    public string targetTag = "Target";  // �����Ń^�O��ݒ�i��: "Target"�j
    private int totalTargetObjects;  // ������
    private int remainingTargetObjects;  // �c��̃^�[�Q�b�g�I�u�W�F�N�g��
                                         // �������b�Z�[�W�p��UI
    public GameObject victoryMessage;
    void Start()
    {
        // �Q�[���J�n���Ɏw�肵���^�O�̃I�u�W�F�N�g���𐔂���
        totalTargetObjects = GameObject.FindGameObjectsWithTag(targetTag).Length;
        remainingTargetObjects = totalTargetObjects;

        // �������b�Z�[�W���\���ɂ��Ă���
        victoryMessage.SetActive(false);
    }
    // ����̃^�O�����I�u�W�F�N�g���������Ƃ��ɌĂ΂��֐�
    public void TargetObjectDestroyed()
    {
        remainingTargetObjects--;  // �c��^�[�Q�b�g�I�u�W�F�N�g�������炷

        // �c��I�u�W�F�N�g�����[���ɂȂ����珟��
        if (remainingTargetObjects <= 0)
        {
            WinGame();
        }
    }

    // ��������
    void WinGame()
    {
        // �������b�Z�[�W��\��
        victoryMessage.SetActive(true);

        // ���̏��������i�X�R�A�̕\���A�Ď��s�{�^���Ȃǁj�������Œǉ��ł��܂�
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            remainingTargetObjects++;
            mousePos = Input.mousePosition;
            mousePos.z = 5f;
            Instantiate(bulletPrefab,Camera.main.ScreenToWorldPoint(mousePos),Quaternion.identity);
        }

    }
}
