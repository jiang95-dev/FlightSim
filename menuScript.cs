
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {
    public Button startGame;
    public Button tutorial;

	// Use this for initialization
	void Start () {
        startGame = startGame.GetComponent<Button>();
        tutorial = tutorial.GetComponent<Button>();
    }
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartLevel();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            TutorialLevel();
        }
    }

	public void NoPress()
    {
        startGame.enabled = true;
        tutorial.enabled = true;
    }

    public void StartLevel()
    {
        Application.LoadLevel(1);
    }
    public void TutorialLevel()
    {
        Application.LoadLevel(2);
    }
}
