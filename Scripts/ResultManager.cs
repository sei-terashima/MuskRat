using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public float playerTime;  // プレイヤーのタイム

    void Start()
    {
        // 仮のタイムを設定（実際のゲームではこれを取得する）
        playerTime = 120.5f;

        // プレイヤーのタイムをPlayerPrefsに保存
        PlayerPrefs.SetFloat("PlayerTime", playerTime);
        PlayerPrefs.Save();

        // デバッグログで保存されたタイムを確認
        Debug.Log("PlayerTime saved: " + playerTime);
    }

    public void LoadRankingScene()
    {
        SceneManager.LoadScene("RankingScene"); // ランキングシーンに遷移
    }
}
