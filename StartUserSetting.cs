using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class StartUserSetting : MonoBehaviour
{
    [SerializeField] string apiUrl; // APIのURLを設定
    public UserInfo user;
    [SerializeField] Text score;
    [SerializeField] Text username;
    WWWForm form;
    [SerializeField] string LoginUrl;

    public void Start()
    {
        StartCoroutine(SetUpUserInfo());
    }

    IEnumerator SetUpUserInfo()
    {
        yield return StartCoroutine(GetUserInfo());
        score.text = user.score.ToString();
        username.text = user.username;
        Debug.Log(user.username);
    }

    IEnumerator GetUserInfo()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("<color=red>" + request.error + "</color>");//error
        }
        else
        {
            if (request.isDone)
            {
                if (request.downloadHandler.text.Contains("error"))
                {
                    Debug.Log("<color=red>" + request.downloadHandler.text + "</color>");//error
                    yield return StartCoroutine(Login("guest", "password"));
                    StartCoroutine(GetUserInfo());
                }
                else
                {
                    Debug.Log("<color=green>" + request.downloadHandler.text + "</color>");//user exist
                    string jsonResponse = request.downloadHandler.text;
                    //Debug.Log(jsonResponse);
                    user = JsonUtility.FromJson<UserInfo>(jsonResponse);

                }
            }
        }

        request.Dispose();
    }

    //これそのうち別のファイルに移そうね
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
                }
            }
        }

        w.Dispose();
    }

}

[System.Serializable]
public class UserInfo
{
    public int score;
    public string username;
}