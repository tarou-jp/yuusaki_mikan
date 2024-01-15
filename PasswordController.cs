using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordController : MonoBehaviour
{
    public InputField passField;            // �p�X���[�h��InputField
    public GameObject maskingOffButton;     // �}�X�L���O���I�t�ɂ���Button
    public GameObject maskingOnButton;      // �}�X�L���O���I���ɂ���Button

    public void Start()
    {
        OnClickMaskingOnButton();
    }

    public void OnClickMaskingOffButton()   // maskingOffButton�������Ǝ��s�����֐�
    {
        maskingOffButton.SetActive(false);
        maskingOnButton.SetActive(true);
        passField.contentType = InputField.ContentType.Standard;
        StartCoroutine(ReloadInputField());
    }

    public void OnClickMaskingOnButton()    // maskingOnButton�������Ǝ��s�����֐�
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