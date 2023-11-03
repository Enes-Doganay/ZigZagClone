using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject ball;
    private Vector3 offset; // make camera stay certain distance from ball when following
    public float lerpRate; // rate camera will change position to follow ball
    public bool gameOver;

	// Use this for initialization
	void Start () {
        offset = ball.transform.position - transform.position;
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameOver)
            Follow();
	}

    void Follow()
    {
        Vector3 pos = transform.position; // current camera position
        Vector3 targetPos = ball.transform.position - offset; // keep it certain distance from ball
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime); // lerp moves on from one value to another value at a certain rate
        transform.position = pos;
    }
}
