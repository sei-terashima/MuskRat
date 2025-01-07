using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class MazeManager : MonoBehaviour
{
    [SerializeField] private GameObject ClearPanel;
    [SerializeField] private GameObject StartPanel;
    public float displayDuration = 3f; // 表示時間（秒）
    public static UnityEvent OnGoal = new UnityEvent();

    public GameObject timeBar;
    public GameObject timeText;
    TimeController timeCnt;


    private void Start()
    {
        // コルーチンを開始してテキストを表示
        StartCoroutine(DisplayMessage());
    }

    private void Awake()
    {
        ClearPanel.SetActive(false);
        OnGoal.RemoveAllListeners();
        OnGoal.AddListener(() =>
        {
            ClearPanel.SetActive(true);
        });
    }

    IEnumerator DisplayMessage()
    {
        // テキストを表示する
        StartPanel.gameObject.SetActive(true);

        // 指定した時間待つ
        yield return new WaitForSeconds(displayDuration);

        // テキストを非表示にする
        StartPanel.gameObject.SetActive(false);
    }
}
