using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Vector3 mousePos;
    public string targetTag = "Target";  // ここでタグを設定（例: "Target"）
    private int totalTargetObjects;  // 初期数
    private int remainingTargetObjects;  // 残りのターゲットオブジェクト数
                                         // 勝利メッセージ用のUI
    public GameObject victoryMessage;
    void Start()
    {
        // ゲーム開始時に指定したタグのオブジェクト数を数える
        totalTargetObjects = GameObject.FindGameObjectsWithTag(targetTag).Length;
        remainingTargetObjects = totalTargetObjects;

        // 勝利メッセージを非表示にしておく
        victoryMessage.SetActive(false);
    }
    // 特定のタグを持つオブジェクトが消えたときに呼ばれる関数
    public void TargetObjectDestroyed()
    {
        remainingTargetObjects--;  // 残りターゲットオブジェクト数を減らす

        // 残りオブジェクト数がゼロになったら勝利
        if (remainingTargetObjects <= 0)
        {
            WinGame();
        }
    }

    // 勝利処理
    void WinGame()
    {
        // 勝利メッセージを表示
        victoryMessage.SetActive(true);

        // 他の勝利処理（スコアの表示、再試行ボタンなど）をここで追加できます
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
