using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlayerMenu : MonoBehaviour {

    public GameObject current, character;
    private GameObject moveAi, moveUser, difficultyNormal, difficultyHard, menu, multiplayer, tutorial, options;

    public void OnMouseEnter()
    {
        LeanTween.scale(current, new Vector3(0.5f, .5f, .5f), .075f);
		LeanTween.scale(character, new Vector3(0.3f, .3f, .3f), .03f);
	}
    

	public void OnMouseExit()
	{
		LeanTween.scale(current, new Vector3(0.4268945f, 0.4268945f, 0.4268945f), .05f);
	LeanTween.scale(character, new Vector3(0.222469f, 0.222469f, 0.222469f), .01f);


	}

    private void Awake()
    {
        moveUser = GameObject.Find("userSelected");
        moveAi = GameObject.Find("aiSelected");
        difficultyNormal = GameObject.Find("normalSelected");
        difficultyHard = GameObject.Find("hardSelected");
        menu = GameObject.Find("Popup");


		multiplayer = GameObject.Find("multiplayer");
		tutorial = GameObject.Find("tutorial");
		options = GameObject.Find("options");
		multiplayer.GetComponent<Renderer>().enabled = false;
		tutorial.GetComponent<Renderer>().enabled = false;
		options.GetComponent<Renderer>().enabled = false;


        difficultyNormal.GetComponent<Renderer>().enabled = true;
        difficultyHard.GetComponent<Renderer>().enabled = false;
        moveAi.GetComponent<Renderer>().enabled = true;
        moveUser.GetComponent<Renderer>().enabled = false;

    }



    public void OnMouseUp()
    {
		if (current != null) {
			switch (current.name) {
			case "startButton":
				SceneManager.LoadScene ("GameBoard");
				break;
			case "aiButton":
				moveAi.GetComponent<Renderer> ().enabled = true;
				moveUser.GetComponent<Renderer> ().enabled = false;
				break;
			case "userButton":
				moveAi.GetComponent<Renderer> ().enabled = false;
				moveUser.GetComponent<Renderer> ().enabled = true;
				break;
			case "normalButton":
				difficultyNormal.GetComponent<Renderer> ().enabled = true;
				difficultyHard.GetComponent<Renderer> ().enabled = false;
				break;
			case "hardButton":
				difficultyNormal.GetComponent<Renderer> ().enabled = false;
				difficultyHard.GetComponent<Renderer> ().enabled = true;
				break;
			case "menuButton":
				menu.SetActive (false);
				multiplayer.GetComponent<Renderer>().enabled = true;
				tutorial.GetComponent<Renderer>().enabled = true;
				options.GetComponent<Renderer>().enabled = true;
				break;
			default:
				break;
            

			}

		}
  
    }
}
