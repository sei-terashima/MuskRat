using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // 移動速度を設定します
    public float moveSpeed = 5f;

    // アニメーターを設定
    public Animator MuskratAnimator;

    // キャラクターの移動方向を保存する変数
    private Vector3 moveDirection;

    // 歩き判定
    bool isRun;

    // 操作を無効にするためのフラグ
    private bool canMove = true;

    void Update()
    {
        // 毎フレームMove関数を呼び出しますが、canMoveがtrueの場合のみ
        if (canMove)
        {
            Move();
        }
        // アニメーターの状態を更新します
        MuskratAnimator.SetBool("Run", isRun);
    }

    void Move()
    {
        // 水平方向の入力（AとDキー）を取得します
        float horizontal = Input.GetAxis("Horizontal");
        // 垂直方向の入力（WとSキー）を取得します
        float vertical = Input.GetAxis("Vertical");

        // 入力に基づいて移動方向を設定し、正規化します
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // 待機状態
        isRun = false;

        // 移動方向がゼロでない場合に実行します
        if (moveDirection != Vector3.zero)
        {
            // キャラクターが移動方向を向くようにします
            transform.forward = moveDirection;
            // キャラクターを移動させます
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

            // 移動状態
            isRun = true;
        }
    }

    // 操作を無効にするメソッド
    public void DisableMovement()
    {
        canMove = false;
    }
}
