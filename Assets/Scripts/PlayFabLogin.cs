using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabLogin : MonoBehaviour
{
    [SerializeField]
    private Text ConnectInfo;
    private void Start()
    {

    }

    public void Connected()
    {
        //�������� �� TitleId
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = "FD7E4";
            Debug.Log("Title ID was installed");
        }

        //�������� �������
        var request = new LoginWithCustomIDRequest { CustomId = "lesson3", CreateAccount = true };
        //�������� �������
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("PlayFab Success");
        ConnectInfo.text = "����������!";
        ConnectInfo.color = Color.green;
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError($"Fail: {error}");
        ConnectInfo.text = "������ �����������!";
        ConnectInfo.color = Color.red;
    }
}