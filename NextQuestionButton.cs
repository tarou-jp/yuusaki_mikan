using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextQuestionButton : MonoBehaviour
{
    [SerializeField] DBManager DBManager;
    [SerializeField] InputField content;
    [SerializeField] GameObject QuestionCanvas;
    [SerializeField] GameObject EvaluationPanel;
    [SerializeField] QuestionTextCanvas questionInfo_;
    [SerializeField] ModeChanger ModeChanger;
    [SerializeField] UserScoreManager ScoreManager;
    [SerializeField] Text Score;

    public void OnNextQuestionButtonClicked()
    {
        if (content.text != "")
        {
            StartCoroutine(NextQuestionCoroutine());
            ClickSound.instance.ClickSoundPlay(0);
        }
        else
        {
            Debug.Log("<color=red>error, âÒìöï∂Çì¸óÕÇµÇƒÇ≠ÇæÇ≥Ç¢ÅB</color>");
            ClickSound.instance.ClickSoundPlay(0);
        }
    }

    IEnumerator NextQuestionCoroutine()
    {
        if (ModeChanger.IsQuestionModeHidden)
        {
            yield return StartCoroutine(ScoreManager.GetEvaluationScoreCoroutine(questionInfo_.questionInfo.content, content.text));
            yield return StartCoroutine(DBManager.AddAnswerToDB(content.text, ScoreManager.score, questionInfo_.questionInfo.questionID));
            EvaluationPanel.SetActive(true);
            Score.text = ScoreManager.score.ToString() + "pt";
            ModeChanger.IsQuestionModeHidden = false;
            content.text = "";
            QuestionCanvas.SetActive(false);
            yield return new WaitForSeconds(2.0f);
            QuestionCanvas.SetActive(true);
            EvaluationPanel.SetActive(false);
            ModeChanger.ClearActivePanel();
            ModeChanger.ChangToQuestion();
            ClickSound.instance.ClickSoundPlay(0);
        }
        else
        {
            yield return StartCoroutine(ScoreManager.GetEvaluationScoreCoroutine(questionInfo_.questionInfo.content, content.text));
            yield return StartCoroutine(DBManager.AddAnswerToDB( content.text, ScoreManager.score, questionInfo_.questionInfo.questionID));
            EvaluationPanel.SetActive(true);
            Score.text = ScoreManager.score.ToString() + "pt";
            content.text = "";
            QuestionCanvas.SetActive(false);
            yield return new WaitForSeconds(2.0f);
            QuestionCanvas.SetActive(true);
            EvaluationPanel.SetActive(false);
            ClickSound.instance.ClickSoundPlay(0);
        }

    }
}
