using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private Text title_Txt;
    [SerializeField] private Button btn_Next;
    [SerializeField] private Button btn_Retry;
    [SerializeField] private Button btn_Prev;

    public void Show(bool result, string title)
    {
        // ���� / ����
        ButtonSet(result);
        title_Txt.text = title;

        this.gameObject.SetActive(true);
    }

    private void ButtonSet(bool result)
    {
        if(result)
        {
            // 이 부분 아직 오류 있으니 일단 예외처리
            if (StageManager.Instance.Stage_List != null)
            {
                if (StageManager.Instance.currentStage == StageManager.Instance.Stage_List.Count)
                {
                    btn_Next.gameObject.SetActive(false);
                    btn_Retry.gameObject.SetActive(true);
                    btn_Prev.gameObject.SetActive(true);
                }
                else
                {
                    btn_Next.gameObject.SetActive(true);
                    btn_Retry.gameObject.SetActive(false);
                    btn_Prev.gameObject.SetActive(true);
                }
            }
            else
            {
                btn_Next.gameObject.SetActive(false);
                btn_Retry.gameObject.SetActive(true);
                btn_Prev.gameObject.SetActive(true);
            }
        }
        else
        {
            btn_Next.gameObject.SetActive(false);
            btn_Retry.gameObject.SetActive(true);
            btn_Prev.gameObject.SetActive(true);
        }
    }

    public void OnClickRetry()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnClickNext()
    {
        StageManager.Instance.IncreaseStageLevel();
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickLobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
