using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class UserInfoAPI : MonoBehaviour
{
    [SerializeField] string apiUrl; // API��URL��ݒ�
    public UserInfo user;

    public void FetchUserInfo()
    {
        StartCoroutine(GetUserInfo());
    }

    IEnumerator GetUserInfo()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("���[�U�[���̎擾�Ɏ��s���܂���: " + request.error);
            yield break;
        }

        string jsonResponse = request.downloadHandler.text;
        user = JsonUtility.FromJson<UserInfo>(jsonResponse);
        Debug.Log("SS");
    }
}

[System.Serializable]
public class UserInfo_
{
    public int userID;
    public string username;
}