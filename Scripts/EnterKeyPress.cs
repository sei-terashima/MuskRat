using UnityEngine;
using UnityEngine.UI;

public class EnterKeyPress : MonoBehaviour
{
    public Button targetButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            targetButton.onClick.Invoke();
        }
    }
}
