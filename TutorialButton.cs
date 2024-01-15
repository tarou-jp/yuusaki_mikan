using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    [SerializeField] GameObject[] TutorialPanels;
    [SerializeField] GameObject TutorialCloseButton;
    [SerializeField] ModeChanger ModeChanger;

    public void OnTutorialButtonClicked()
    {
        TutorialPanels[ModeChanger.mode].SetActive(true);
        TutorialCloseButton.SetActive(true);
        ClickSound.instance.ClickSoundPlay(1);
    }

    public void OnTutorialCloseButtonClicked()
    {
        TutorialPanels[ModeChanger.mode].SetActive(false);
        TutorialCloseButton.SetActive(false);
        ClickSound.instance.ClickSoundPlay(1);
    }
}
