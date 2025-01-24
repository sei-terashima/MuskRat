using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentTime; // 現在のタイム
    public TextMeshProUGUI currentTimeText; // 現在のタイム表示用UI
    //public TextMeshProUGUI bestTimeText; // ベストタイム表示用UI
    public TextMeshProUGUI statusText; // UI表示
    public static string gameState; // ゲームの状態
    public GameObject NextButton; //ネクストボタンの表示

    // Start is called before the first frame update
    void Start()
    {

        gameState = "playing"; // ゲーム中にする

        Invoke("HideStatusText", 1.0f); // 1秒後にテキストを非表示にする


    }

    void HideStatusText()
    {
        statusText.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        //タイマーの更新
        if (gameState == "playing")
        {
            NextButton.gameObject.SetActive(false);
            currentTime += Time.deltaTime;
            currentTimeText.text = "Time: " + currentTime.ToString("F2");
        }

        else if (gameState == "gameStop")
        {
            NextButton.gameObject.SetActive(true);
            statusText.GetComponent<TextMeshProUGUI>().text = "STAGE CLEAR!";
        }
    }

}
