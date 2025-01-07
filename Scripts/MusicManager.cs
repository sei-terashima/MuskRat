using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null; // Singleton インスタンス
    private AudioSource musicSource; // AudioSource コンポーネントの参照

    void Awake()
    {
        // Singleton パターンで MusicManager のインスタンスを保持
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーンが変更されてもオブジェクトを破棄しない
            musicSource = GetComponent<AudioSource>(); // AudioSource コンポーネントの取得
        }
        else
        {
            Destroy(gameObject); // 既にインスタンスが存在する場合、重複するオブジェクトを破棄
        }
    }

    // 音楽を再生するメソッド
    public void PlayMusic()
    {
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play(); // AudioSource で音楽を再生
        }
    }

}
