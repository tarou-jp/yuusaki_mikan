using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailManager : MonoBehaviour
{
    [SerializeField] GameObject QuestionDetailPanel;
    [SerializeField] GameObject AnswerDetailPanel;

    public void OnQuestionDetailButtonClicked()
    {
        QuestionDetailPanel.SetActive(true);
        ClickSound.instance.ClickSoundPlay(2);
    }

    public void OnAnswerDetailButtonClicked()
    {
        AnswerDetailPanel.SetActive(true);
        ClickSound.instance.ClickSoundPlay(2);
    }
    public void OnQuestionDetailPanelCloseButtonClicked()
    {
        QuestionDetailPanel.SetActive(false);
        ClickSound.instance.ClickSoundPlay(2);
    }

    public void OnAnswerDetailPanelCloseButtonClicked()
    {
        AnswerDetailPanel.SetActive(false);
        ClickSound.instance.ClickSoundPlay(2);
    }
}
