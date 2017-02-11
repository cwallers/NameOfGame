using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static bool isSinglePlayer = true;
    public static bool PlayerGoFirst = true;
    public static bool firstPlayer = true;
    public enum aILevel { easy, difficult};
    public enum characterSelection {name1, name2, name3, name4} //change for names of characters later
    public static characterSelection characterLocalPlayer; //enum list of characters
    public static characterSelection characterOpponentPlayer;


    private int moveTo;
    private int moveFrom;
    private int pieceCount;

    public static aILevel level = 0; //by default

    public static Player instance;
   

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        if (level == aILevel.easy)
        {
            //aIScript = gameObject.AddComponent<AIScript>();

        }
        else if  (level == aILevel.difficult)
        {
            //aIScript = gameObject.AddComponent<AIScript>();
        }

    }


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

    public int[] getAIMove()
    {
        print("Calling AI");
        int[] move = null;

        if (level == aILevel.easy)
        {
            //call A1
        }
        else if (level == aILevel.difficult)
        {
            //call A1
        }
        
       
        return move;
    }

    //private void Start()
    //{
    //    GameObject gameOb = new GameObject();
    //    InputField input = gameObject.GetComponent<InputField>();
    //    Debug.Log(input);
    //    var se = new InputField.SubmitEvent();
    //    //se.AddListener(SubmitInput);
    //    //input.onEndEdit = se;
    //}
    ////private void SubmitInput(string arg0)
    //{
    //    Debug.Log(arg0);
    //}
}
