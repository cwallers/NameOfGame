using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static bool PlayerGoFirst = true;
    public static bool firstPlayer = true;
    public static int aILevel;
    public static int characterSelectionPlayer; //enum list of characters


    private int moveTo;
    private int moveFrom;
    private int pieceCount;

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
