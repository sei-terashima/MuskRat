using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public float playerTime; // プレイヤーのタイム

    void Start()
    {
        // プレイヤーのタイムを仮設定（本来はゲームから受け取る）
        // ここではテスト用の値を設定しています
        playerTime = TimeController.GetClearTime(); // 例: TimeController から取得

        // ベストタイムをPlayerPrefsから取得（デフォルトは無限大）
        float bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);

        // プレイヤータイムがベストタイムより良ければ更新
        if (playerTime < bestTime)
        {
            PlayerPrefs.SetFloat("BestTime", playerTime); // ベストタイムを保存
            PlayerPrefs.Save();
            Debug.Log("新しいベストタイムを保存しました: " + playerTime);
        }
        else
        {
            Debug.Log("ベストタイム更新なし。プレイヤータイム: " + playerTime);
        }
    }
}
