using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuestLoginButton : MonoBehaviour
{
    WWWForm form;
    [SerializeField] string LoginUrl;
    
    public void OnGuestLoginButtonClicked()
    {
        StartCoroutine(Login("guest", "password"));
        ClickSound.instance.ClickSoundPlay(0);
    }

    public IEnumerator Login(string username, string password)
    {
        form = new WWWForm();

        form.AddField("username", username);
        form.AddField("password", password);

        WWW w = new WWW(LoginUrl, form);
        yield return w;

        if (w.error != null)
        {
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("error"))
                {
                    //errorMessages.text = "invalid username or password!";
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    //ここにシーン移動
                    Debug.Log("ログインしました");
                    Debug.Log("<color=green>" + w.text + "</color>");//user exist
                    SceneManager.LoadScene("main");

                }
            }
        }

        w.Dispose();
    }
}
