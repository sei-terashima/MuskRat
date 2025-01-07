using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    void Awake()
    {
        // Singleton パターンで GameManager のインスタンスを保持
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ゲームをリセットするメソッド
    public static void ResetGame()
    {
        // ここでゲームの状態をリセットする処理を追加します
        TimeController.ResetTimerForResult();
        // その他、必要なリセット処理を追加
    }

    // 新しいゲームを開始するメソッド
    public static void StartNewGame()
    {
        // ゲームの初期設定を行います
        ResetGame();
        // 初期のシーンに移動します（例：Stage1）
        SceneManager.LoadScene("Title");
    }

    // タイトル画面に戻るメソッド
    public static void ReturnToTitle()
    {
        // タイトルシーンに移動します
        SceneManager.LoadScene("Title");
    }


}
