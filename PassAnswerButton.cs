using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassAnswerButton : MonoBehaviour
{
    [SerializeField] DBManager DBManager;
    [SerializeField] InputField content;
    //[SerializeField] UserInfoAPI user_;

    public void OnPassAnswerButtonClicked()
    {
        if (content.text != "")
        {
            StartCoroutine(DBManager.AddQuestionToDB(content.text));
            ClickSound.instance.ClickSoundPlay(0);
            content.text = "";
        }
        else
        {
            Debug.Log("<color=red>error, 質問文を入力してください。</color>");
            ClickSound.instance.ClickSoundPlay(0);
        }

    }
}
