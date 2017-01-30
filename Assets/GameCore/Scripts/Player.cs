using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int moveTo;
    private int moveFrom;
    private int pieceCount;

    public Player()
    {
        pieceCount = 9;
    }

    public int getMoveFrom()
    {
        //set moveFrom from the GUI, the network, or the AI
        return moveFrom;
    }
    public int getMoveTo()
    {
        //set moveTo from the GUI, the network, or the AI
        return moveTo;
    }

    public int getPieceToRemove()
    {
        int pieceToRemove = 0;
        //set pieceToRemove from the GUI, the network, or the AI
        return pieceToRemove;
    }

    public int getPieceCount()
    {
        return pieceCount;
    }
}
