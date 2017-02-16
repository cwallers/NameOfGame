using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlayerMenu : MonoBehaviour {

    public GameObject current;
    private GameObject moveAi, moveUser, difficultyNormal, difficultyHard, menu;

    public void OnMouseEnter()
    {
        LeanTween.scale(current, new Vector3(0.5f, .5f, .5f), .075f);
    }

    private void Awake()
    {
        moveUser = GameObject.Find("userSelected");
        moveAi = GameObject.Find("aiSelected");
        difficultyNormal = GameObject.Find("normalSelected");
        difficultyHard = GameObject.Find("hardSelected");
        menu = GameObject.Find("Popup");


        difficultyNormal.GetComponent<Renderer>().enabled = true;
        difficultyHard.GetComponent<Renderer>().enabled = false;
        moveAi.GetComponent<Renderer>().enabled = true;
        moveUser.GetComponent<Renderer>().enabled = false;

    }

    public void OnMouseExit()
    {
        LeanTween.scale(current, new Vector3(0.4268945f, 0.4268945f, 0.4268945f), .05f);

    }


    public void OnMouseUp()
    {
        string name = current.name;
        switch (name)
        {
            case "startButton" :
                SceneManager.LoadScene("GameBoard");
                break;
            case "aiButton":
                moveAi.GetComponent<Renderer>().enabled = true;
                moveUser.GetComponent<Renderer>().enabled = false;
                break;
            case "userButton":
                moveAi.GetComponent<Renderer>().enabled = false;
                moveUser.GetComponent<Renderer>().enabled = true;
                break;
            case "normalButton":
                difficultyNormal.GetComponent<Renderer>().enabled = true;
                difficultyHard.GetComponent<Renderer>().enabled = false;
                break;
            case "hardButton":
                difficultyNormal.GetComponent<Renderer>().enabled = false;
                difficultyHard.GetComponent<Renderer>().enabled = true;
                break;
            case "menuButton":
                menu.SetActive(false);
                break;
            default:
                break;
            

        }

  
    }
}
