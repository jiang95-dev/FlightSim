using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class tutorial : MonoBehaviour {
    public Button ret;
    public RawImage image;
    public Text instruction;

	// Use this for initialization
	void Start () {
        ret = ret.GetComponent<Button>();
        image = image.GetComponent<RawImage>();
        instruction = instruction.GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ReturnLevel();
        }

    }

    public void NoPress()
    {
        ret.enabled = true;
        image.enabled = true;
        instruction.enabled = true;
    }
    
    public void ReturnLevel()
    {
        Application.LoadLevel(0);
    }

}
