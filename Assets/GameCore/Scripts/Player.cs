using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private short moveTo;
    private short moveFrom;
    private short pieceCount;

    public Player()
    {
        pieceCount = 9;
    }

    public short getMoveFrom()
    {
        //set moveFrom from the GUI, the network, or the AI
        return moveFrom;
    }
    public short getMoveTo()
    {
        //set moveTo from the GUI, the network, or the AI
        return moveTo;
    }

    public short getPieceToRemove()
    {
        short pieceToRemove = 0;
        //set pieceToRemove from the GUI, the network, or the AI
        return pieceToRemove;
    }

    public short getPieceCount()
    {
        return pieceCount;
    }
}
