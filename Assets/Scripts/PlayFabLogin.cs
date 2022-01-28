using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayFabLogin : MonoBehaviour
{
    [SerializeField]
    private GameObject WindowLoad;
    private string _username;
    private string _mail;
    private string _pass;

    private const string AuthKey = "player-unique-id";
    public void UpdateUsername(string username)
    {
        _username = username;
    }

    public void UpdateEmail(string mail)
    {
        _mail = mail;
    }

    public void UpdatePass(string pass)
    {
        _pass = pass;
    }

    public void CreateAccount()
    {
        WindowLoad.SetActive(true);
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
        {
            Username = _username,
            Email = _mail,
            Password = _pass,
            RequireBothUsernameAndEmail = true
        }, result =>
        {
            WindowLoad.SetActive(false);
            Debug.Log("Success");
        }, errorCallback => {
            WindowLoad.SetActive(false);
            Debug.LogError($"Error: {errorCallback}");
        });
    }

    public void Login()
    {
        WindowLoad.SetActive(true);
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = _username,
            Password = _pass
        }, result =>
        {
            WindowLoad.SetActive(false);
            Debug.Log($"Success: {_username}");
            SceneManager.LoadScene("Lobby");
        }, errorCallback => {
            WindowLoad.SetActive(false);
            Debug.LogError($"Error: {errorCallback}");
        });
    }

    public void Anonimlogin()
    {
        var needCreation = !PlayerPrefs.HasKey(AuthKey);
        Debug.Log($"needCreation = {needCreation}");
        var id = PlayerPrefs.GetString(AuthKey, Guid.NewGuid().ToString());
        Debug.Log($"id = {id}");
        var request = new LoginWithCustomIDRequest { CustomId = id, CreateAccount = needCreation };
        PlayFabClientAPI.LoginWithCustomID(request, reuslt =>
        {
            PlayerPrefs.SetString(AuthKey, id);
            SceneManager.LoadScene("Lobby");
        }, OnLoginFailure);
    }
    private void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = "FD7E4";
            Debug.Log("Title ID was installed");
        }
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError($"Fail: {error}");
    }
}