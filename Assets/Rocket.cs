using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

	Rigidbody _rigidBody;

	// Use this for initialization
	void Start () {
		_rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		ProcessInput();
	}

	private void ProcessInput(){
		if(Input.GetKey(KeyCode.Space)){
			_rigidBody.AddRelativeForce(Vector3.up *45 * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Rotate(Vector3.forward*100* Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate(-Vector3.forward*100 * Time.deltaTime);
		}
	}

	private void OnCollisionEnter (Collision col) {
		if(col.gameObject.name != "Target Pad" && col.gameObject.name != "Launchpad")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
