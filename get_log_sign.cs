using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class get_log_sign : MonoBehaviour
{
    [SerializeField] ShiftStuation sift;
    [SerializeField] GameObject situation;
    [SerializeField] GameObject LoginButton;
    [SerializeField] GameObject SigninButton;
    [SerializeField] Text SituationLabel;

    // Start is called before the first frame update
    void Start()
    {
        if (log_sigh.log_sign == 0)
        {
            Debug.Log("login");
        } else{
            Debug.Log("signin");
            situation.GetComponent<Text>().text = "アカウントをお持ちでない方";
            SigninButton.SetActive(false);
            LoginButton.SetActive(true);
            SituationLabel.text = "新規作成";
        }
    }

}