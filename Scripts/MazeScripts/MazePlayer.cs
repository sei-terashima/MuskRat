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

            // OnGoalイベントをトリガー
            MazeManager.OnGoal.Invoke();
        }
    }
}
