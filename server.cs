using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class server : MonoBehaviour
{
	[Space]
	[SerializeField] InputField username;
	[SerializeField] InputField password;

	[SerializeField] Text errorMessages;


	[SerializeField] Button loginButton;
	[SerializeField] Button signinButton;


	[SerializeField] string LoginUrl;
	[SerializeField] string SigninUrl;


	WWWForm form;

	//public void OnLoginButtonClicked()
	//{
	//	loginButton.interactable = false;
	//	StartCoroutine(Login(username.text,password.text));
	//}

	public void OnSubmitButtonClicked()
    {
		loginButton.interactable = false;
		if (log_sigh.log_sign == 0)
        {
			StartCoroutine(Login(username.text, password.text));
		}
		else
        {
			StartCoroutine(Signin());
		}
    }

	public IEnumerator Login(string username,string password)
	{
		form = new WWWForm();

		form.AddField("username", username);
		form.AddField("password", password);

		WWW w = new WWW(LoginUrl, form);
		yield return w;

		if (w.error != null)
		{
			errorMessages.text = "404 not found!";
			Debug.Log("<color=red>" + w.text + "</color>");//error
		}
		else
		{
			if (w.isDone)
			{
				if (w.text.Contains("error"))
				{
					//errorMessages.text = "invalid username or password!";
					errorMessages.text = w.text;
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

		loginButton.interactable = true;

		w.Dispose();
	}

	//public void OnSigninButtonClicked()
	//{
	//	loginButton.interactable = false;
	//	StartCoroutine(Signin());
	//}

	IEnumerator Signin()
	{
		form = new WWWForm();

		form.AddField("username", username.text);
		form.AddField("password", password.text);

		WWW w = new WWW(SigninUrl, form);
		yield return w;

		if (w.error != null)
		{
			errorMessages.text = "404 not found!";
			Debug.Log("<color=red>" + w.text + "</color>");//error
		}
		else
		{
			if (w.isDone)
			{
				if (w.text.Contains("error"))
				{
					//errorMessages.text = "invalid username or password!";
					errorMessages.text = w.text;
					Debug.Log("<color=red>" + w.text + "</color>");//error
				}
				else
				{
					//ここにシーン移動
					Debug.Log("<color=green>" + w.text + "</color>");//user exist
					Debug.Log("サインイン");
					yield return StartCoroutine(Login(username.text, password.text));
				}
			}
		}

		loginButton.interactable = true;

		w.Dispose();
	}
}