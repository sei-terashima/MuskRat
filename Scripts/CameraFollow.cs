using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // キャラクターのTransformを指定
    public Transform target;
    // カメラの位置オフセットを設定
    public Vector3 offset;
    // カメラの追従速度を設定
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // 目標位置を計算します（キャラクターの位置＋オフセット）
        Vector3 desiredPosition = target.position + offset;
        // カメラの現在位置と目標位置の間を補間してスムーズに移動
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // カメラの位置を更新します
        transform.position = smoothedPosition;

        // カメラを特定の方向に固定
        transform.LookAt(target.position + Vector3.up * 2f);
    }
}
