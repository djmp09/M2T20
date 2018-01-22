using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket2 : MonoBehaviour {
	public GameObject rocket3;
	Rigidbody _rigidBody;
	AudioSource _audioSource;
	bool _isSoundPlaying = false;
	//float speed = 5f;
	public float mainThrust = 45f;
	public float rcsThrust = 100f;
	// Use this for initialization
	void Start () {
		_rigidBody = GetComponent<Rigidbody>();
		_audioSource = GetComponent<AudioSource>();
		rocket3 = GameObject.Find("Rocket Ship 2");
	}
	
	// Update is called once per frame
	void Update () {
		ProcessInput();
	}

	private void ProcessInput(){
		if(Input.GetKey(KeyCode.UpArrow)){
			_rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
			if(!_isSoundPlaying){
				_audioSource.Play();
				_isSoundPlaying = true;
			}
		} else {
				_audioSource.Stop();
				_isSoundPlaying = false;
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate(Vector3.forward * rcsThrust * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Rotate(-Vector3.forward * rcsThrust * Time.deltaTime);
		}
	}

	private void OnCollisionEnter (Collision col) {
		if(col.gameObject.name != "Target Pad" && col.gameObject.name != "Launchpad 2")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
