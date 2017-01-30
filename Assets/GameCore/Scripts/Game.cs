using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public static bool isLocalPlayer = true;

    private static Game gameInstance = null;

    private Board gameBoard = new Board();
    private MoveLookup gameBoardMoves = new MoveLookup();
    private Player localPlayer;
    private Player opponent;
    private Dictionary<short, short> moves = new Dictionary<short, short>(gameInstance.gameBoardMoves.Moves);
    private Dictionary<short, Pair> mills = new Dictionary<short, Pair>(gameInstance.gameBoardMoves.Mills);

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
        //getLocation()
        //if spot is empty
            //board.placePiece()
        //else invalid place
    }

    public bool gameOver()
    {
        if (localPlayer.getPieceCount() <= 2 || !canMove()) // check for draw 
            return true;
        else
            return false;
    }

    public bool phaseThree()
    {
        if (localPlayer.getPieceCount() == 3)
            return true;
        else 
            return false;
    }

    public void movePiece()
    {
        short from = localPlayer.getMoveFrom();
        short to = localPlayer.getMoveTo();
        if(validMove(from, to))
        {
            gameBoard.movePiece(from, to);
        }
        else
        {
            Debug.Log("Invalid Move");
            movePiece();
        }
    }

    public void flyPiece()
    {
        short from = localPlayer.getMoveFrom();
        short to = localPlayer.getMoveTo();
        if (validFly(from, to))
        {
            gameBoard.movePiece(from, to);
        }
        else
        {
            Debug.Log("Invalid Fly");
            flyPiece();
        }

    }

    public bool canMove()
    {

        BitArray boardConfig = gameBoard.findEmptySpots();

        BitArray playerConfig = gameBoard.getPlayerBoard();

        for (short i = 0; i < 24; i++)
        {
            // enter if player has piece at this spot
            if (playerConfig[i] == true)
            {
                for (short j = 0; i < 24; ++i)
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

    private bool validMove(short from, short to)
    {
        if (gameBoard.isLocalPlayerPieceAt(from) == true)
        {
            short value = 0;
            foreach (KeyValuePair<short, short> entry in gameBoardMoves.Moves)
            {
                gameBoardMoves.Moves.TryGetValue(from, out value);
                if (value == to)
                {
                    return true;
                }
            }
        }
        return false;
    }

    //   //are you allowed to fly there?
    private bool validFly(short from, short to)
    {
        if ((gameBoard.isLocalPlayerPieceAt(from) == true) &&
             gameBoard.isEmptySpotAt(to) == true)
        {
            return true;
        }
        return false;
    }

    private bool createdMill(bool isLocalPlayer, short to)
    {
        foreach (KeyValuePair<short, Pair> entry in gameBoardMoves.Mills)
        {
            if (entry.Key == to &&
              (gameBoard.isLocalPlayerPieceAt(entry.Value.first) &&
               gameBoard.isLocalPlayerPieceAt(entry.Value.second)))
            {
                return true;
            }
        }
        return false;
    }



    public void finalize()
    {

    }

    private Game()
    { }

    //   //gets instance of the Board
    //   public Game()
    //   {
    //        gameBoard = gameBoard.getInstance;
    //   }

    //   //removes a piece
    //   public bool removePiece(bool isLocalPlayer, short pieceToRemove)
    //   {
    //       if (gameBoard.getPlayerPieceAt(!isLocalPlayer, pieceToRemove) == true
    //           && (!piecePartOfMill(!isLocalPlayer, pieceToRemove) || allPiecesPartOfMill(!isLocalPlayer)))
    //       {
    //           gameBoard.removePiece(!isLocalPlayer, pieceToRemove);
    //           return true;
    //       }
    //       return false;
    //   }

    //   //places a piece in phase 1
    //   public bool placePiece(bool isLocalPlayer, short index)
    //   {
    //       if (gameBoard.findEmptySpotAt(index) == false)
    //       {
    //           gameBoard.placePiece(isLocalPlayer, index);
    //           return true;
    //       }
    //       return false;
    //   }

    //   //checks to see if the piece is part of a mill
    //   private bool piecePartOfMill(bool isLocalPlayer, short index)
    //   {
    //       foreach (KeyValuePair<short, Pair> entry in gameBoardMoves.Mills)
    //       {
    //           if(entry.Key == index && 
    //             (gameBoard.getPlayerPieceAt(isLocalPlayer, entry.Value.first) && 
    //              gameBoard.getPlayerPieceAt(isLocalPlayer, entry.Value.second)))
    //           {
    //               return true;
    //           }
    //       }
    //       return false;
    //   }

    //   //i don't know
    //   private bool allPiecesPartOfMill(bool isLocalPlayer)
    //   {
    //       int pieceCount = 0;
    //       for (short i = 1; i <= 24; i++)
    //       {
    //           if (gameBoard.getPlayerPieceAt(isLocalPlayer, i) && piecePartOfMill(isLocalPlayer, i))
    //           {
    //               pieceCount++;
    //           }
    //       }
    //       return (pieceCount == gameBoard.getPlayerPieceCount(isLocalPlayer));
    //   }

    // 

    //   //are you allowed to move there?
   

    //   //
    //   private short playerPieceCount(bool isLocalPlayer)
    //   {
    //       return (short)gameBoard.getPlayerPieceCount(isLocalPlayer);
    //   }

    //   //is the player able to move?
    //   private bool playerCanMove(bool isLocalPlayer)
    //   {
    //       BitArray boardConfig = gameBoard.findEmptySpots();
    //       BitArray playerConfig = gameBoard.getPlayerBoard(isLocalPlayer);

    //       for (short i = 0; i < 24; i++)
    //       {
    //           // enter if player has piece at this spot
    //           if (playerConfig[i] == true)
    //           {
    //               for(short j = 0; i < 24; ++i)
    //               {
    //                   if(boardConfig[i] == true)
    //                   {
    //                       if(validMove(isLocalPlayer, i, j))
    //                       {
    //                           return true;
    //                       }
    //                   }
    //               }
    //           }
    //       }
    //       return false;
    //   }

    //   // Use this for initialization
    //   void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
}
