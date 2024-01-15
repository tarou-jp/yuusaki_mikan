using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiftStuation : MonoBehaviour
{
    [SerializeField] GameObject situation;
    [SerializeField] GameObject LoginButton;
    [SerializeField] GameObject SigninButton;
    [SerializeField] Text SituationLabel;
    [SerializeField] Text SubmitButtonLabel;
    [SerializeField] Text errorMessages;

    public void OnShitfSituationButtonClicked()
    {
        if (log_sigh.log_sign == 0)
        {
            log_sigh.log_sign = 1;
            situation.GetComponent<Text>().text = "アカウントをお持ちの方";
            //SigninButton.SetActive(true);
            //LoginButton.SetActive(false);
            SituationLabel.text = "新規作成";
            SubmitButtonLabel.text = "新規作成";
            errorMessages.text = "";
        } else
        {
            log_sigh.log_sign = 0;
            situation.GetComponent<Text>().text = "アカウントをお持ちでない方";
            //SigninButton.SetActive(false);
            //LoginButton.SetActive(true);
            SituationLabel.text = "ログイン";
            SubmitButtonLabel.text = "ログイン";
            errorMessages.text = "";
        }
    }
}
