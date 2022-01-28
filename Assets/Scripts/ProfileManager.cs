using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    [SerializeField] private Text _id;
    [SerializeField] private Text _customIdInfo;
    [SerializeField] private Text _firstLogin;
    [SerializeField] private Text _hours;
    //[SerializeField] private Text _inf;
    [SerializeField] private GameObject WindowLoad;
    private const string AuthKey = "player-unique-id";
    // Start is called before the first frame update
    void Start()
    {
        WindowLoad.SetActive(true);
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), success =>
        {
            WindowLoad.SetActive(false);
            _id.text = $"{success.AccountInfo.PlayFabId}";
            _customIdInfo.text = $"{success.AccountInfo.CustomIdInfo.CustomId}";
            _firstLogin.text = $"{success.AccountInfo.TitleInfo.FirstLogin}";
            _hours.text = $"{success.AccountInfo.Created.Hour}";
            //_inf.text = $"PsnInfo: {success.AccountInfo.Created.Date.TimeOfDay}";
        }, errorCallback =>
        {
            Debug.Log("Error");
            WindowLoad.SetActive(false);
        });
    }
    public void DeleteProfile()
    {
        PlayerPrefs.DeleteKey(AuthKey);
        Debug.Log($"Профиль удален");
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}