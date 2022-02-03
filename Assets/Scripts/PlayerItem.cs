using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour
{
    [SerializeField] Text _userInfo;

    public void Initialize(string UserID, string NickName)
    {
        _userInfo.text = $"Player:{NickName}, id:{UserID}";
        //_userInfo.text = $"Player id:{UserID}";
    }

}
