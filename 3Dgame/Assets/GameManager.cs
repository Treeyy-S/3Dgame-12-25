using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Vector3 mousePos;
    public string targetTag = "ground";  // �����Ń^�O��ݒ�

    private int totalTargetObjects;  // ������
    private int remainingTargetObjects;  // �c��̃^�[�Q�b�g�I�u�W�F�N�g��

    public GameObject victoryMessage; // �N���A���ɕ\�����郁�b�Z�[�W��UI�Ȃǂ��w��
    void Start()
    {
        // �Q�[���J�n���Ɏw�肵���^�O�̃I�u�W�F�N�g���𐔂���
        totalTargetObjects = GameObject.FindGameObjectsWithTag(targetTag).Length;
        remainingTargetObjects = totalTargetObjects;
   
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5f;
            Instantiate(bulletPrefab, Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
        }
        // ���t���[���^�O "Destroyable" �����I�u�W�F�N�g���c���Ă��邩�`�F�b�N
        CheckDestroyableObjects();
    }

    void CheckDestroyableObjects()
    {
        // "Destroyable" �^�O�����I�u�W�F�N�g�����ׂĎ擾
        GameObject[] destroyableObjects = GameObject.FindGameObjectsWithTag(targetTag);

        // ���ׂẴI�u�W�F�N�g���폜���ꂽ�ꍇ�A�Q�[���N���A��\��
        if (destroyableObjects.Length == 0)
        {
            OnGameClear();
        }
    }

    void OnGameClear()
    {
        SceneManager.LoadScene("GameClear");

    }
}
