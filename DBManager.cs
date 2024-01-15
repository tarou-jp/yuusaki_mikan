using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{
    [SerializeField] string QuestionUrl;
    [SerializeField] string AnswerUrl;
    [SerializeField] Text errorMessages;

    UnityWebRequest www;

    public IEnumerator AddQuestionToDB(string content)
    {
        WWWForm form = new WWWForm();
        //form.AddField("userID", userID);
        form.AddField("content", content);

        www = UnityWebRequest.Post(QuestionUrl, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            errorMessages.text = "404 not found!";
            Debug.Log("<color=red>" + www.error + "</color>");//error
        }
        else
        {
            if (www.isDone)
            {
                if (www.downloadHandler.text.Contains("error"))
                {
                    errorMessages.text = "éøñ‚ï∂ÇÃìoò^Ç…é∏îsÇµÇ‹ÇµÇΩÅB";
                    Debug.Log("<color=red>" + www.downloadHandler.text + "</color>");//error
                }
                else
                {
                    Debug.Log("<color=green>" + www.downloadHandler.text + "</color>");//user exist
                }
            }
        }

        www.Dispose();
    }

    public IEnumerator AddAnswerToDB(string content, int score, int questionID)
    {
        WWWForm form = new WWWForm();

        //form.AddField("userID", userID);
        form.AddField("content", content);
        form.AddField("score", score);
        form.AddField("questionID", questionID);

        www = UnityWebRequest.Post(AnswerUrl, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            errorMessages.text = "404 not found!";
            Debug.Log("<color=red>" + www.error + "</color>");//error
        }
        else
        {
            if (www.isDone)
            {
                if (www.downloadHandler.text.Contains("error"))
                {
                    errorMessages.text = "âÒìöï∂ÇÃìoò^Ç…é∏îsÇµÇ‹ÇµÇΩÅB";
                    Debug.Log("<color=red>" + www.downloadHandler.text + "</color>");//error
                }
                else
                {
                    Debug.Log("<color=green>" + www.downloadHandler.text + "</color>");//user exist
                }
            }
        }

        www.Dispose();
    }
}
