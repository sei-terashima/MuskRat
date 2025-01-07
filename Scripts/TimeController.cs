using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    public TMP_Text timeText; // TextMeshProコンポーネント参照
    public TMP_Text stageClearText; // ステージクリアテキストを参照するための変数
    private static float times = 0; // 経過時間を保持する静的変数
    private static bool isStageCleared = false; // ステージクリアフラグ

    // ステージクリアメッセージを設定する変数
    [TextArea(3, 10)]
    public string stageClearMessageTemplate = "{0} CLEAR!";

    void Awake()
    {
        // シーンのロード完了イベントにハンドラーを登録
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if (!isStageCleared)
        {
            times += Time.deltaTime;
            UpdateTimeText();
        }
    }

    // タイマーをリセットするメソッド
    private static void ResetTimer()
    {
        times = 0;
    }

    // タイマーを停止するメソッド
    public static void StopTimer()
    {
        isStageCleared = true;
    }

    // 次のステージでタイマーを再開するメソッド
    public static void RestartTimer()
    {
        isStageCleared = false;
    }

    // シーンロード後に呼び出されるメソッド
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Stage1")
        {
            ResetTimer(); // STAGE1開始時にリセット
        }
        else if (scene.name != "Result")
        {
            RestartTimer(); // ステージ2以降の開始時にカウントアップ再開
        }

        UpdateTimeText();
    }

    // Resultシーンで呼び出すためのタイマーリセットメソッド
    public static void ResetTimerForResult()
    {
        ResetTimer(); // タイマーリセット
    }

    // カウントされた時間を取得するメソッド
    public static float GetClearTime()
    {
        return times;
    }

    // カウントされた時間をフォーマットするメソッド
    public static string GetFormattedTime()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(times);
        return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }

    // ステージクリア時にメッセージを表示するメソッド
    public void ShowStageClearMessage()
    {
        if (stageClearText != null)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            stageClearText.text = string.Format(stageClearMessageTemplate, sceneName);
            stageClearText.gameObject.SetActive(true);
        }
    }

    // 時間を更新するメソッド
    private void UpdateTimeText()
    {
        if (timeText != null)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(times);
            timeText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }
    }
}
