using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour {


    //public GameObject helpImage;
    private GameObject gameObj;
    private Board boardInstance;
    private void Start()
    {
        play();
    }


    public void setUpBoard()
    {
        gameObj = GameObject.FindWithTag("Game");
        boardInstance.initializeBoard();
        
        if ( (Player.characterLocalPlayer) == Player.characterSelection.name1)
        {
            //call piece set up function for local player passing the prefab name
            // localPlayerPieceSetUp(prefabName)
        }
        else if (Player.characterLocalPlayer == Player.characterSelection.name2)
        {
            //call piece set up function for local player passing the prefab name
            // localPlayerPieceSetUp(prefabName)
        }
        else if (Player.characterLocalPlayer == Player.characterSelection.name3)
        {
            //call piece set up function for local player passing the prefab name
            // localPlayerPieceSetUp(prefabName)
        }
        else
        //Add more if else statements once we know how many characters we'll have

        if (Player.isSinglePlayer)
        {
            int character = Random.Range(1, 4);
            Player.characterOpponentPlayer = (Player.characterSelection)character;
        }

        while (Player.characterOpponentPlayer == Player.characterLocalPlayer)
        {
            int character = Random.Range(1, 4);
            Player.characterOpponentPlayer = (Player.characterSelection)character;

        }



    

    }


    void play()
    {
        Game game = Game.gameInstance;

        for (short i = 0; i < 9; ++i)
        {
            game.placePiece();
        }

        while (!game.gameOver())
        {
            if (game.phaseThree())
            {
                game.flyPiece();
            }
            else
            {
                game.movePiece();
            }
        }
    }
}
