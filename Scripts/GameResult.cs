using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class GameResult : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI clearTimeText;
    public Button titleButton;

    void Start()
    {
        // リザルトシーン開始時に結果を表示
        float clearTime = TimeController.GetClearTime();
        ShowResult(clearTime);

        // タイトルボタンのクリックイベントを登録
        titleButton.onClick.AddListener(OnTitleButtonClicked);
    }

    // ゲームクリア時に呼び出されるメソッド
    public void ShowResult(float time)
    {
        resultText.text = "GAMECLEAR";

        // 時間を分・秒のフォーマットで表示
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        clearTimeText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);

        // リザルト画面をアクティブにする
        gameObject.SetActive(true);
    }

    // タイトルボタンがクリックされた時の処理
    void OnTitleButtonClicked()
    {
        // タイマーリセットメソッドを呼び出す
        TimeController.ResetTimerForResult();


        // 新しいゲームを開始する
        GameManager.StartNewGame();
    }
}
