using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class signin_button : MonoBehaviour
{
    public void OnSigninButtonClicked()
    {
        log_sigh.log_sign = 1;
        SceneManager.LoadScene("login-signin");
        ClickSound.instance.ClickSoundPlay(0);
    }
}
