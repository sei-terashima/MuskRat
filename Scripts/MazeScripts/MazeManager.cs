using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

// 迷路ゲームの管理を行うクラス
public class MazeManager : MonoBehaviour
{
    // 迷路クリア時に表示するパネル
    [SerializeField] private GameObject ClearPanel;

    // ゲーム開始時に表示するパネル
    [SerializeField] private GameObject StartPanel;

    // メッセージの表示時間（秒単位）
    public float displayDuration = 3f;

    // ゴール到達時のイベント
    public static UnityEvent OnGoal = new UnityEvent();

    // タイムバーとタイムテキストの参照
    public GameObject timeBar;
    public GameObject timeText;

    // タイムコントローラー（タイマー管理用）
    TimeController timeCnt;

    // ゲーム開始時に実行される処理
    private void Start()
    {
        // コルーチンを開始し、開始時のメッセージを表示
        StartCoroutine(DisplayMessage());
    }

    // ゲームオブジェクトが初期化される際に実行される処理
    private void Awake()
    {
        // クリアパネルを非表示に設定
        ClearPanel.SetActive(false);

        // ゴールイベントのリスナーをリセット
        OnGoal.RemoveAllListeners();

        // ゴール時の挙動をリスナーとして追加
        OnGoal.AddListener(() =>
        {
            // クリアパネルを表示
            ClearPanel.SetActive(true);
        });
    }

    // 指定時間だけ開始メッセージを表示するコルーチン
    IEnumerator DisplayMessage()
    {
        // 開始パネルを表示
        StartPanel.gameObject.SetActive(true);

        // 指定された秒数だけ待機
        yield return new WaitForSeconds(displayDuration);

        // 開始パネルを非表示にする
        StartPanel.gameObject.SetActive(false);
    }
}
