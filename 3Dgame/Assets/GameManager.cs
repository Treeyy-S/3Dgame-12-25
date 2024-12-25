using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Vector3 mousePos;
    public string targetTag = "ground";  // ここでタグを設定

    private int totalTargetObjects;  // 初期数
    private int remainingTargetObjects;  // 残りのターゲットオブジェクト数

    public GameObject victoryMessage; // クリア時に表示するメッセージのUIなどを指定
    void Start()
    {
        // ゲーム開始時に指定したタグのオブジェクト数を数える
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
        // 毎フレームタグ "Destroyable" を持つオブジェクトが残っているかチェック
        CheckDestroyableObjects();
    }

    void CheckDestroyableObjects()
    {
        // "Destroyable" タグを持つオブジェクトをすべて取得
        GameObject[] destroyableObjects = GameObject.FindGameObjectsWithTag(targetTag);

        // すべてのオブジェクトが削除された場合、ゲームクリアを表示
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
