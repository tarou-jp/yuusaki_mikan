using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionDetailPanelCloseButton : MonoBehaviour
{
    [SerializeField] GameObject Panel;

    public void OnQuestionDetailPanelCloseButtonClicked()
    {
        Panel.SetActive(false);
    }
}
