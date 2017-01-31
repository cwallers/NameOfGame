using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class MessageManager : NetworkBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CmdPlacePiece(0);
    }

    [Command]
    void CmdPlacePiece(int index)
    {
        RpcPlacePiece(index);
    }

    [ClientRpc]
    void RpcPlacePiece(int index)
    {
        //Game core function place piece
    }
}
