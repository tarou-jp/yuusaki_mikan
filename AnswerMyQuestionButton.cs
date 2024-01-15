using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerMyQuestionButton : MonoBehaviour
{
    [SerializeField] ModeChanger ModeChanger;
    [SerializeField] DBManager DBManager;
    [SerializeField] QuestionTextCanvas QuestionTextCanvas;
    [SerializeField] InputField content;
    //[SerializeField] UserInfoAPI user_;

    public void OnAnswerMyQuestionButtonClicked()
    {
        if (content.text != "")
        {
            StartCoroutine(AnswerMyQuestionButtonCoroutine());
            ClickSound.instance.ClickSoundPlay(0);
        }
        else
        {
            Debug.Log("<color=red>error, éøñ‚ï∂Çì¸óÕÇµÇƒÇ≠ÇæÇ≥Ç¢ÅB</color>");
            ClickSound.instance.ClickSoundPlay(0);
        }
    }

    IEnumerator AnswerMyQuestionButtonCoroutine()
    {
        ModeChanger.IsQuestionModeHidden = true;

        yield return StartCoroutine(DBManager.AddQuestionToDB(content.text));
        ModeChanger.ClearActivePanel();
        ModeChanger.ChangToAnswer();
        QuestionTextCanvas.ChangeQuestionSelfish(content.text);
        content.text = "";

    }
}