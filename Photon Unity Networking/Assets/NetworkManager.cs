using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon;
using UnityEngine;
using UnityEngine.UI;
using ExitGames = ExitGames.Client.Photon.Hashtable;

public class NetworkManager : PunBehaviour {

    private PunTurnManager turnManager;
    public InputField InputField;
    public string UserId;
    public string previousRoom;
    const string NickNamePlayerPrefsKey = "NickName";

    // Use this for initialization
    void Start()
    {
        connect();
        if (PlayerPrefs.HasKey(NickNamePlayerPrefsKey))
        {
            InputField.text = PlayerPrefs.GetString(NickNamePlayerPrefsKey);
        }
        else
        {
            InputField.text = "";
        }
    }

    public void ApplyUserIdAndConnect()
    {
        string nickName = "DemoNick";

        if (InputField != null && !string.IsNullOrEmpty(InputField.text))
        {
            nickName = this.InputField.text;
            PlayerPrefs.SetString(NickNamePlayerPrefsKey, nickName);
        }

        if (string.IsNullOrEmpty(UserId))
        {
            UserId = nickName + "ID";
        }

        if (PhotonNetwork.AuthValues == null)
        {
            PhotonNetwork.AuthValues = new AuthenticationValues();
        }

        PhotonNetwork.playerName = nickName;
        PhotonNetwork.ConnectUsingSettings("v1.0");
    }

    public override void OnConnectedToMaster()
    {
        // after connect 
        UserId = PhotonNetwork.player.UserId;

        // after timeout: re-join "old" room (if one is known)
        if (!string.IsNullOrEmpty(this.previousRoom))
        {
            Debug.Log("ReJoining previous room");
            PhotonNetwork.ReJoinRoom(previousRoom);
            previousRoom = null;       // we only will try to re-join once. if this fails, we will get into a random/new room
        }
    }

    public override void OnJoinedLobby()
    {
        OnConnectedToMaster(); // this way, it does not matter if we join a lobby or not
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room: " + PhotonNetwork.room.Name);
        previousRoom = PhotonNetwork.room.Name;

    }

    public override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
    {
        this.previousRoom = null;
    }

    public override void OnConnectionFail(DisconnectCause cause)
    {
        Debug.Log("Disconnected due to: " + cause + ". this.previousRoom: " + this.previousRoom);
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(300, 300, 100, 50), "Host"))
        {
            host();
        }

        for(int i = 0; i < PhotonNetwork.GetRoomList().Length; ++i)
        {
            if(GUI.Button(new Rect(600, 300 + 110 * i, 100, 50), "Join " + PhotonNetwork.GetRoomList()[i].Name))
            {
                join(PhotonNetwork.GetRoomList()[i].Name);
            }
        }
    }

    private bool connect()
    {
        if (PhotonNetwork.connected)
        {
            Debug.Log("Already Connected");
            return true;
        }
        else
        {
            return PhotonNetwork.ConnectUsingSettings("v1.0");
        }
    }

    private bool host()
    {
        //need to decide room naming convention
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 2;
        string roomName = "my room";

        if (PhotonNetwork.CreateRoom(roomName, roomOptions, TypedLobby.Default))
        {
            Debug.Log("room created");
            return true;
        }
        return false;
    }

    private bool join(string roomName)
    {
        if (PhotonNetwork.JoinRoom(roomName))
        {
            Debug.Log("room joined");
            return true;
        }
        return false;
    }

    void Awake()
    {
        PhotonNetwork.autoJoinLobby = true;
    }
	
	// Update is called once per frame
	void Update () {
    }
}
