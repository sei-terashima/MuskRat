using UnityEngine;
using UnityEngine.AI;

// ナビメッシュエージェントを使用して目的地に移動するクラス
public class MoveToTarget : MonoBehaviour
{
    // 目的地のTransform（対象オブジェクトの位置）
    public Transform target;

    // 移動速度（未使用だが、将来的に速度調整用として定義）
    public float speed = 5.0f;

    // NavMeshAgent コンポーネントへの参照
    private NavMeshAgent naveMeshAgent;

    // 初期化処理
    void Start()
    {

        // NavMeshAgent コンポーネントを取得
        naveMeshAgent = GetComponent<NavMeshAgent>();
    }

    // フレームごとに呼び出される処理
    void Update()
    {
        // NavMeshAgentに目的地を設定し、移動を開始
        naveMeshAgent.SetDestination(target.position);
    }
}
