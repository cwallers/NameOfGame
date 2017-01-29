using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private short moveTo;
    private short moveFrom;
    private short pieceCount = 9;

    public short getMoveFrom()
    {
        return moveFrom;
    }
    public short getMoveTo()
    {
        return moveTo;
    }

    public short getPieceCount()
    {
        return pieceCount;
    }
}
