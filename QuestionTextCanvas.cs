using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class QuestionTextCanvas : MonoBehaviour
{
    public string GetQuestionUrl;
    public string GetMyQuestionUrl;
    public string downloadHandler;
    [SerializeField] Text QuestionTextOnPanel;
    public QuestionInfo questionInfo;

    public void SetQuestionOnQuestionPanel(string text)
    {
        QuestionTextOnPanel.text = text;
    }

    public void ChangeQuestionRandom()
    {
        StartCoroutine(ChangeQuestionRandomCoroutine());
    }

    public void ChangeQuestionSelfish(string question_content)
    {
        Debug.Log(question_content);
        StartCoroutine(ChangeQuestionSelfishCoroutine(question_content));
    }

    IEnumerator ChangeQuestionSelfishCoroutine(string question_content)
    {
        Debug.Log(question_content);
        yield return StartCoroutine(GetMyQuestion(question_content));
        SetQuestionOnQuestionPanel(questionInfo.content);
    }

    IEnumerator ChangeQuestionRandomCoroutine()
    {
        yield return StartCoroutine(GetRandomQuestion());
        SetQuestionOnQuestionPanel(questionInfo.content);
    }


    IEnumerator GetRandomQuestion()
    {
        UnityWebRequest www = UnityWebRequest.Get(GetQuestionUrl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("<color=red>" + www.error + "</color>"); // エラーメッセージを表示
        }
        else
        {
            if (www.isDone)
            {
                if (www.downloadHandler.text.Contains("error"))
                {
                    Debug.LogError("<color=red>" + www.downloadHandler.text + "</color>"); // エラーメッセージを表示
                }
                else
                {
                    downloadHandler = www.downloadHandler.text;
                    questionInfo = JsonUtility.FromJson<QuestionInfo>(downloadHandler);
                }
            }
        }

        www.Dispose();
    }

    IEnumerator GetMyQuestion(string question_content)
    {
        WWWForm form = new WWWForm();

        form.AddField("question_content", question_content);
        UnityWebRequest www = UnityWebRequest.Post(GetMyQuestionUrl, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("<color=red>" + www.error + "</color>"); // エラーメッセージを表示
        }
        else
        {
            if (www.isDone)
            {
                if (www.downloadHandler.text.Contains("error"))
                {
                    Debug.LogError("<color=red>" + www.downloadHandler.text + "</color>"); // エラーメッセージを表示
                }
                else
                {
                    downloadHandler = www.downloadHandler.text;
                    questionInfo = JsonUtility.FromJson<QuestionInfo>(downloadHandler);
                }
            }
        }

        www.Dispose();
    }
}


[System.Serializable]
public class QuestionInfo
{
    public string content;
    public int questionID;
}
