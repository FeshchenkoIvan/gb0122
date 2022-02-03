using System.Globalization;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    [SerializeField] private Text nickname;
    [SerializeField] private Text id;
    [SerializeField] private Text created;
    
    private string _inputText;

    private void Start()
    {
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest {}, success =>
        {
            nickname.text = $"Player Name: {success.AccountInfo.Username}";
            id.text = $"Player ID: {success.AccountInfo.PlayFabId}";
            created.text = $"Creation time: {success.AccountInfo.Created.ToString(CultureInfo.CurrentCulture)}";
        }, error =>
        {
            // errorLabel.text = error.GenerateErrorReport();
        });
    }

    public void UpdateInputFiled(string text)
    {
        _inputText = text;
    }

    public void SaveNicknameOnPlayFab()
    {
    }
    
    public void ClearCredentials()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Bootstrap");
    }
}
<<<<<<< Updated upstream
=======


>>>>>>> Stashed changes
