using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoutButton : MonoBehaviour
{

    public void OnLogoutButtonclicked()
    {
        SceneManager.LoadScene("home");
        ClickSound.instance.ClickSoundPlay(1);
    }
}

