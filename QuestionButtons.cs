using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionButtons : MonoBehaviour
{
    [SerializeField] GameObject QuestionDetailPanel;
    [SerializeField] GameObject AnswerDetailPanel;

    public void OnQuestionDetailButtonClicked()
    {
        QuestionDetailPanel.SetActive(true);
    }

    public void OnAnswerDetailButtonClicked()
    {
        AnswerDetailPanel.SetActive(true);
    }
}
