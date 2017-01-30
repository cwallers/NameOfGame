using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Board : MonoBehaviour
{

    private BitArray playerOne;
    private BitArray playerTwo;
    private static Board boardInstance = null;

    public Board()
    {}

    public void changePlayer()
    {
        if (Game.isLocalPlayer)
        {
            Game.isLocalPlayer = false;
        }
        else
        {
            Game.isLocalPlayer = true;
        }
    }

    private Board(BitArray first, BitArray second)
    {
        playerOne = first;
        playerTwo = second;
    }

    public void initializeBoard()
    {
        playerOne.SetAll(false);
        playerTwo.SetAll(false);
    }

    public BitArray findEmptySpots()
    {
        return playerOne.Xor(playerTwo);
    }

    public bool isEmptySpotAt(short index)
    {
        BitArray ans = new BitArray(playerOne.Xor(playerTwo));
        return ans[index - 1];
    }

    public Board getInstance
    {
        get
        {
            if (boardInstance == null)
            {
                boardInstance = new Board();

            }
            return boardInstance;
        }
    }

    //if the local player controls the place on the board at index
    public bool isLocalPlayerPieceAt(short index)
    {
        if (Game.isLocalPlayer)
        {
            return playerOne[index - 1];
        }
        else
        {
            return playerTwo[index - 1];
        }
    }

    public BitArray getPlayerBoard()
    { 
        if(Game.isLocalPlayer)
        {
            return playerOne;
        }
        return playerTwo;
    }

    public short getPlayerPieceCount()
    {
        if(Game.isLocalPlayer)
        {
            return (short)playerOne.Count;
        }
        else
        {
            return (short)playerTwo.Count;
        }
    }

    public void movePiece(short from, short to)
    {
        if (Game.isLocalPlayer)
        {
            playerOne[from - 1] = false;
            playerOne[to - 1] = true;
        }
        else
        {
            playerTwo[from - 1] = false;
            playerTwo[to - 1] = true;
        }
    }

    public void removePiece(bool isLocalPlayer, short index)
    {
        if (isLocalPlayer)
        {
            playerOne[index - 1] = false;
        }
        else
        {
            playerTwo[index - 1] = false;
        }
    }

    public void placePiece(short index)
    {
        if (Game.isLocalPlayer)
        {
            playerOne[index - 1] = true;
        }
        else
        {
            playerTwo[index - 1] = true;
        }
    }

    void Start ()
    {

    }

    void Update()
    {

    }

}





