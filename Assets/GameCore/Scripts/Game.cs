using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Eppy;

public class Game : MonoBehaviour {

    public static bool isLocalPlayer = true;

    private static Game gameInstance = null;

    private Board gameBoard = new Board();
    private MoveLookup gameBoardMoves = new MoveLookup();
    private Player localPlayer = new Player();
    private List<Tuple<int, int>> moves = new List<Tuple<int, int>>(gameInstance.gameBoardMoves.Moves);
    private List<Tuple<int, int, int>> mills = new List<Tuple<int, int, int>>(gameInstance.gameBoardMoves.Mills);

    public static Game getInstance
    {
        get
        {
            if (gameInstance == null)
            {
                gameInstance = new Game();
            }
            return gameInstance;
        }
    }


    public void initialize()
    {

    }

    public void placePiece()
    {
        int index = localPlayer.getMoveTo();

        if(gameBoard.isEmptySpotAt(index))
        {
            gameBoard.placePiece(index);

            if(createdMill(index))
            {
                removePiece();
            }
        }
    }

    public bool gameOver()
    {
        if (localPlayer.getPieceCount() <= 2 || !localPlayerCanMove())
            return true;
        else
        {
            return false;
        }
    }

    public bool phaseThree()
    {
        if (localPlayer.getPieceCount() == 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void movePiece()
    {
        int from = localPlayer.getMoveFrom();
        int to = localPlayer.getMoveTo();

        if(validMove(from, to))
        {
            gameBoard.movePiece(from, to);

            if (createdMill(to))
            {
                removePiece();
            }
        }
        else
        {
            Debug.Log("Invalid Move");
        }
    }

    public void flyPiece()
    {
        int from = localPlayer.getMoveFrom();
        int to = localPlayer.getMoveTo();

        if (validFly(from, to))
        {
            gameBoard.movePiece(from, to);

            if (createdMill(to))
            {
                removePiece();
            }
        }
        else
        {
            Debug.Log("Invalid Fly");
            flyPiece();
        }

    }

    public bool localPlayerCanMove()
    {
        BitArray boardConfig = gameBoard.findEmptySpots();

        BitArray playerConfig = gameBoard.getPlayerBoard();

        for (int i = 0; i < 24; i++)
        {
            // enter if player has piece at this spot
            if (playerConfig[i] == true)
            {
                for (int j = 0; i < 24; ++i)
                {
                    if (boardConfig[i] == true)
                    {
                        if (validMove(i, j))
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    public void finalize()
    {

    }

    private bool removePiece()
    {
        //unfinished
        int pieceToRemove = localPlayer.getPieceToRemove();

        if (gameBoard.isLocalPlayerPieceAt(pieceToRemove) == true
            && (!piecePartOfMill(pieceToRemove) || allPiecesPartOfMill()))
        {
            gameBoard.removePiece(!isLocalPlayer, pieceToRemove);
            return true;
        }
        return false;
    }

    private bool createdMill(int to)
    {
        foreach (Tuple<int, int, int> entry in gameBoardMoves.Mills)
        {
            if (entry.Item1 == to &&
              (gameBoard.isLocalPlayerPieceAt(entry.Item2) &&
               gameBoard.isLocalPlayerPieceAt(entry.Item3)))
            {
                return true;
            }
        }
        return false;
    }

    private bool validMove(int from, int to)
    {
        if (gameBoard.isLocalPlayerPieceAt(from) == true)
        {
            foreach (Tuple<int, int> entry in gameBoardMoves.Moves)
            {
                if (from == entry.Item1 && gameBoard.isEmptySpotAt(to))
                {
                    return true;
                }
            }
        }
        return false;
    }

    //   //are you allowed to fly there?
    private bool validFly(int from, int to)
    {
        if ((gameBoard.isLocalPlayerPieceAt(from) == true) &&
             gameBoard.isEmptySpotAt(to) == true)
        {
            return true;
        }
        return false;
    }

    private bool piecePartOfMill(int index)
    {
        foreach (Tuple<int, int, int> entry in gameBoardMoves.Mills)
        {
            if (entry.Item1 == index &&
              (gameBoard.isLocalPlayerPieceAt(entry.Item2) &&
               gameBoard.isLocalPlayerPieceAt(entry.Item3)))
            {
                return true;
            }
        }
        return false;
    }

    private bool allPiecesPartOfMill()
    {
        int pieceCount = 0;
        for (int i = 1; i <= 24; i++)
        {
            if (gameBoard.isLocalPlayerPieceAt(i) && piecePartOfMill(i))
            {
                pieceCount++;
            }
        }
        return (pieceCount == localPlayer.getPieceCount());
    }

    private Game()
    { }
}
