using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // 移動速度を設定
    public float moveSpeed = 5f;

    // アニメーターを設定
    public Animator MuskratAnimator;

    // キャラクターの移動方向を保存する変数
    private Vector3 moveDirection;

    // 歩き判定
    bool isRun;

    // 操作を無効にするためのフラグ
    private bool canMove = true;

    // 効果音の管理用
    public AudioSource walkAudioSource; // 足音のAudioSourceをインスペクタで設定

    void Start()
    {
        // AudioSourceが設定されていない場合、エラーを表示
        if (walkAudioSource == null)
        {
            Debug.LogError("AudioSourceが設定されていません！");
        }
    }

    void Update()
    {
        // 毎フレームMove関数を呼び出しますが、canMoveがtrueの場合のみ
        if (canMove)
        {
            Move();
        }

        // アニメーターの状態を更新
        MuskratAnimator.SetBool("Run", isRun);

        // 効果音の再生・停止を管理
        HandleFootstepSound();
    }

    void Move()
    {
        // 水平方向の入力（AとDキー）を取得
        float horizontal = Input.GetAxis("Horizontal");
        // 垂直方向の入力（WとSキー）を取得
        float vertical = Input.GetAxis("Vertical");

        // 入力に基づいて移動方向を設定し、正規化
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // 待機状態
        isRun = false;

        // 移動方向がゼロでない場合に実行
        if (moveDirection != Vector3.zero)
        {
            // キャラクターが移動方向を向くように設定
            transform.forward = moveDirection;
            // キャラクターを移動
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

            // 移動状態
            isRun = true;
        }
    }

    void HandleFootstepSound()
    {
        // キャラクターが移動中（isRunがtrue）の場合、効果音を再生
        if (isRun)
        {
            if (!walkAudioSource.isPlaying)
            {
                walkAudioSource.Play();
            }
        }
        else
        {
            // 停止中（isRunがfalse）の場合、効果音を停止
            if (walkAudioSource.isPlaying)
            {
                walkAudioSource.Stop();
            }
        }
    }

    // 操作を無効にするメソッド
    public void DisableMovement()
    {
        canMove = false;
        // 操作を無効にした場合、効果音を停止
        if (walkAudioSource.isPlaying)
        {
            walkAudioSource.Stop();
        }
    }
}
