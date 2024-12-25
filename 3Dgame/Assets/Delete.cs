using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトのタグが「Target」かどうかを確認
        if (collision.gameObject.CompareTag("ground"))
        {
            // 自分自身（弾）を消す
            Destroy(gameObject);
        }
    }
}


