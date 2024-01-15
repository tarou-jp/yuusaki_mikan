using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UserScoreManager : MonoBehaviour
{
    public string EvaluationUrl;
    UnityWebRequest www;
    public int score = 80;



    public IEnumerator GetEvaluationScoreCoroutine(string QuestionContent, string AnswerContent)
    {
        WWWForm form = new WWWForm();
        form.AddField("prompt", "user:" + QuestionContent + ",ó[çÁÇ›Ç©ÇÒ:" + AnswerContent);
        form.AddField("answer", AnswerContent);
        Debug.Log(QuestionContent);
        Debug.Log(AnswerContent);

        www = UnityWebRequest.Post(EvaluationUrl, form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("<color=red>" + www.error + "</color>");//error
        }
        else
        {
            if (www.isDone)
            {
                if (www.downloadHandler.text.Contains("error"))
                {
                    Debug.Log("<color=red>" + www.downloadHandler.text + "</color>");//error
                }
                else
                {
                    Debug.Log("<color=green>" + www.downloadHandler.text + "</color>");//user exist
                    int number;
                    if (int.TryParse(www.downloadHandler.text, out number))
                    {
                        score = number;
                    }
                }
            }
        }

        www.Dispose();
    }
}
