using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListRooms : MonoBehaviour
{
    [SerializeField] private Text RoomNameText;
    [SerializeField] private Text RoomPlayersText;
    private string _roomName;
    void Start()
    {
        
    }
    public void SetItemRoom(RoomInfo info)
    {
        RoomNameText.text = info.Name;
        _roomName = info.Name;
        RoomPlayersText.text = info.PlayerCount.ToString()+"/"+ info.MaxPlayers.ToString();
    }
    public void ButtonJoinRoom()
    {
        PhotonNetwork.JoinRoom(_roomName);
    }
}
