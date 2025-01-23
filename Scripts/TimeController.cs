using System;
using UnityEngine;
using TMPro; // TextMeshPro を使用

public class TimeController : MonoBehaviour
{
    public TMP_Text timeText; // 経過時間を表示するためのTextMeshProコンポーネント
    private static float elapsedTime = 0; // 経過時間を保持する静的変数
    private static bool isTimerRunning = false; // タイマーが動いているかどうかを管理

    void Start()
    {
        ResetTimer(); // ゲーム開始時にタイマーをリセット
        StartTimer(); // タイマーを開始
    }

    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime; // 毎フレーム経過時間を加算
            UpdateTimeDisplay(); // 時間を画面に表示
        }
    }

    /// <summary>
    /// タイマーをリセットする
    /// </summary>
    public static void ResetTimer()
    {
        elapsedTime = 0; // 経過時間をゼロにリセット
    }

    // TimeController.cs 内に追加するメソッド
    public static void ResetTimerForResult()
    {
        ResetTimer(); // タイマーリセット処理を呼び出す
    }

    /// <summary>
    /// タイマーを開始する
    /// </summary>
    public static void StartTimer()
    {
        isTimerRunning = true; // タイマーを開始
    }

    /// <summary>
    /// タイマーを停止する
    /// </summary>
    public static void StopTimer()
    {
        isTimerRunning = false; // タイマーを停止
    }

    /// <summary>
    /// 現在の経過時間を取得する
    /// </summary>
    public static float GetClearTime()
    {
        return elapsedTime;
    }

    /// <summary>
    /// 経過時間を「分:秒」形式で取得する
    /// </summary>
    public static string GetFormattedTime()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
        return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }

    /// <summary>
    /// 時間を画面に表示する
    /// </summary>
    private void UpdateTimeDisplay()
    {
        if (timeText != null)
        {
            timeText.text = GetFormattedTime(); // フォーマットされた時間を表示
        }
    }

    // TimeController.cs の中に追加するメソッド
    public void ShowStageClearMessage()
    {
        // ステージクリアメッセージを表示する処理
        Debug.Log("Stage Cleared!");  // 例えば、デバッグ用のメッセージとして表示

        // 実際には、TextMeshPro の Text を使ってメッセージを表示するなどが考えられます
        if (timeText != null)
        {
            timeText.text = "Stage Cleared!";
        }
    }

}
