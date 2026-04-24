using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() 
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        var millsec = Mathf.FloorToInt(PlayerScript.clearTime * 1000);
        var timeScore = new System.TimeSpan(0, 0, 0, 0, millsec);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore);
    }

    public void Retry() {
        FadeManager.Instance.fadeColor = Color.black;
        FadeManager.Instance.LoadScene("Main", 1f);
    }

    public void Ranking() {
        var millsec = Mathf.FloorToInt(PlayerScript.clearTime * 1000);
        var timeScore = new System.TimeSpan(0, 0, 0, 0, millsec);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore);
    }
}
