using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O���uTarget�v���ǂ������m�F
        if (collision.gameObject.CompareTag("ground"))
        {
            // �������g�i�e�j������
            Destroy(gameObject);
        }
    }
}


