using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour {


    //public GameObject helpImage;


    void play()
    {
        Game game = Game.getInstance;



        //game.initialize();

        for (short i = 0; i < 9; ++i)
        {
            //game.placePiece();
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
        //game.finalize();
    }
}
