using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {


    public int indexClicked;

    private bool wait = true;

    Button[] buttons = new Button[24];

    // Use this for initialization
    void Start () {

        
    }

    private void OnGUI()
    {
        buttons = GetComponentsInChildren<Button>(true);

        for (int i = 0; i < buttons.Length; ++i)
        {
            int buttonIndex = i;
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => setIndexClicked(buttonIndex));
        }
    }

    // Update is called once per frame
    void Update () {

	}

    public ButtonHandler()
    { }

    private void setIndexClicked(int index)
    {
        indexClicked = index;
        Debug.Log(index);
        wait = false;
    }

    public int getIndexClicked()
    {
        StartCoroutine("waitInput");

        return indexClicked;
    }

    private IEnumerator waitInput()
    {
        while (wait)
        {
            Debug.Log("waiting");
        }

        wait = true;

        yield return 0;
    }
}
