using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class login_button : MonoBehaviour
{
    public void OnLoginButtonClicked()
    {
        log_sigh.log_sign = 0;
        SceneManager.LoadScene("login-signin");
        ClickSound.instance.ClickSoundPlay(0);
    }
}
