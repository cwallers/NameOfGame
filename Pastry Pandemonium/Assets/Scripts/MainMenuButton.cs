using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour {

    public GameObject current;


    public void OnMouseEnter()
    {
        LeanTween.scale(current, new Vector3(.45f, .45f, .45f), .075f);
    }

    public void OnMouseUp()
    {
        if (current.name == "singlePlayer")
        {
            SceneManager.LoadScene("GameBoard");
        }
        if (current.name == "multiplayer")
        {
            SceneManager.LoadScene("Multiplayer");
        }
    }
    public void OnMouseExit()
    {
        LeanTween.scale(current, new Vector3(0.3615471f, 0.3615471f, 0.3615471f), .05f);

    }

}
