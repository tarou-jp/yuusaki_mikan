using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBookButton : MonoBehaviour
{
    [SerializeField] GameObject CharacterBookPanel;
    [SerializeField] GameObject CharacterCloseButton;

    public void OnCharacterBookButtonClicked()
    {
        CharacterBookPanel.SetActive(true);
        CharacterCloseButton.SetActive(true);
        ClickSound.instance.ClickSoundPlay(1);
    }

    public void OnCharacterBookCloseButtonClicked()
    {
        CharacterBookPanel.SetActive(false);
        CharacterCloseButton.SetActive(false);
        ClickSound.instance.ClickSoundPlay(1);
    }
}
