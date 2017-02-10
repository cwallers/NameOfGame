using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour {


    //public GameObject helpImage;

    private void Start()
    {
        play();
    }

    void play()
    {
        Game game = Game.getInstance;

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
