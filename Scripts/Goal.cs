using UnityEngine;

public class Goal : MonoBehaviour
{
    public float rotationSpeed = 100f; // 回転速度

    void Start()
    {
        // 初期設定があればここに書く
    }

    void Update()
    {
        // オブジェクトを横方向に回転させる
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
