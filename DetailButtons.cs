using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailButtons : MonoBehaviour
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
    public void OnQuestionDetailPanelCloseButtonClicked()
    {
        QuestionDetailPanel.SetActive(false);
    }

    public void OnAnswerDetailPanelCloseButtonClicked()
    {
        AnswerDetailPanel.SetActive(false);
    }

}
