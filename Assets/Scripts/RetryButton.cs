using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void StageStart(int index)
    {
        StageManager.Instance.currentStage = index;
        Retry();
    }
}
