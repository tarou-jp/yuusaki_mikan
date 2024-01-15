using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerDetailPanelCloseButton : MonoBehaviour
{
    [SerializeField] GameObject Panel;

    public void OnAnswerDetailPanelCloseButtonClicked()
    {
        Panel.SetActive(false);
    }
}
