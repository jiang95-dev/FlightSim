using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class plane_controller : MonoBehaviour {
	public float speed = 30.0f;
	float max_speed = 120.0f;
	float min_speed = 10.0f;
	public float acc = 0.0f;
    public Text gameover;
    // Use this for initialization
    void Start () {
        gameover.text = "";
	}

	// Update is called once per frame
	void Update () {
		acc = Input.GetAxis ("accelerate");
		if (acc <= 0.1 && acc >= -0.1)
			acc = 0;
		speed += acc * 0.5f;
		if (speed >= max_speed)
			speed = max_speed;
		if (speed <= min_speed)
			speed = min_speed;
		transform.position += transform.right * Time.deltaTime * speed;
		transform.Rotate (-Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		float terrain = Terrain.activeTerrain.SampleHeight (transform.position);
		if(terrain > transform.position.y)
        {
            transform.position = new Vector3 (transform.position.x, terrain, transform.position.z);
            speed = 0;
            gameover.text = "Game Over";
            Invoke("ret", 3);
            return;
        }    
	}

    public void ret()
    {
        Application.LoadLevel(0);
    }

}
