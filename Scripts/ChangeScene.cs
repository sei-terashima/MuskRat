using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName; // Inspectorでシーン名を設定

    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}
