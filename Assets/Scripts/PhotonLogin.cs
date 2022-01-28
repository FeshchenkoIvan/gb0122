using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class PhotonLogin : MonoBehaviourPunCallbacks
{
    public Button button;
    private void Awake()
    {
        //как только MasterClient вызывает загрузку следующей сцены методом
        //PhotonNetwork.LoadLevel(), все подключенные к нему игроки
        //автоматически делают то же самое
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        //Connect();
    }

    
    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            //PhotonNetwork.JoinRandomRoom();
            PhotonNetwork.Disconnect();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        if (cause== DisconnectCause.DisconnectByClientLogic)
        {
            button.transform.GetChild(0).GetComponent<Text>().text = "Log In";
            button.GetComponent<Image>().color = Color.white;
            Debug.Log(cause);
            Debug.Log("Photon Disconnect");
        }
        else
        {
            Debug.Log("Error: "+cause);
            button.GetComponent<Image>().color = Color.red;
        }

    }

    public override void OnConnectedToMaster()
    {
        button.transform.GetChild(0).GetComponent<Text>().text = "Disconnect";
        button.GetComponent<Image>().color = Color.green;
        base.OnConnectedToMaster();
        Debug.Log("Photon Success");
    }

}