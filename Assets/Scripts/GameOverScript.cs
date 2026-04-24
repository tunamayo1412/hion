using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    private void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Retry() {
        FadeManager.Instance.fadeColor = Color.black;
        FadeManager.Instance.LoadScene("Main", 1f);
    }
}
