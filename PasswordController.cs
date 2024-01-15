using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordController : MonoBehaviour
{
    public InputField passField;            // パスワードのInputField
    public GameObject maskingOffButton;     // マスキングをオフにするButton
    public GameObject maskingOnButton;      // マスキングをオンにするButton

    public void Start()
    {
        OnClickMaskingOnButton();
    }

    public void OnClickMaskingOffButton()   // maskingOffButtonを押すと実行される関数
    {
        maskingOffButton.SetActive(false);
        maskingOnButton.SetActive(true);
        passField.contentType = InputField.ContentType.Standard;
        StartCoroutine(ReloadInputField());
    }

    public void OnClickMaskingOnButton()    // maskingOnButtonを押すと実行される関数
    {
        maskingOffButton.SetActive(true);
        maskingOnButton.SetActive(false);
        passField.contentType = InputField.ContentType.Password;
        StartCoroutine(ReloadInputField());
    }

    private IEnumerator ReloadInputField()
    {
        passField.ActivateInputField();
        yield return null;
        passField.MoveTextEnd(true);
    }
}