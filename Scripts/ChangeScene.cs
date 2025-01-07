using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName; // Inspectorで正しいシーン名を設定してください

    public void Load()
    {
        Debug.Log($"Attempting to load scene: {sceneName}");
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scene loaded successfully");
    }
}
