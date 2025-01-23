using UnityEngine;

public class MazePlayer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // GoalPointオブジェクトに接触したかを確認
        if (other.gameObject.name == "Goal")
        {
            // ステージクリア時にタイマーを停止
            TimeController.StopTimer();

            // ステージクリアメッセージを表示
            TimeController timeController = FindObjectOfType<TimeController>();
            if (timeController != null)
            {
                timeController.ShowStageClearMessage();
            }
            else
            {
                Debug.LogError("TimeController が見つかりません。");
            }

            // OnGoalイベントをトリガー
            MazeManager.OnGoal.Invoke();
        }
    }
}
