using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour
{

    public Transform target;  // 目的地のTransform
    public float speed = 5.0f;
    private NavMeshAgent naveMeshAgent;

    void Start()
    {
        naveMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        naveMeshAgent.SetDestination(target.position);
    }

 
}
