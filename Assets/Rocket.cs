﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {
	public GameObject rocket1;
	Rigidbody _rigidBody;
	AudioSource _audioSource;
	bool _isSoundPlaying = false;
	//float speed = 5f;
	public float mainThrust = 45f;
	public float rcsThrust = 100f;
	bool isCollision = true;
	// Use this for initialization
	void Start () {
		_rigidBody = GetComponent<Rigidbody>();
		_audioSource = GetComponent<AudioSource>();
		rocket1 = GameObject.Find("Rocket Ship");
	}
	
	// Update is called once per frame
	void Update () {
		ProcessInput();
	}

	private void ProcessInput(){
		if(Input.GetKey(KeyCode.Space)){
			_rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
			if(!_isSoundPlaying){
				_audioSource.Play();
				_isSoundPlaying = true;
			}
		} else {
				_audioSource.Stop();
				_isSoundPlaying = false;
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Rotate(Vector3.forward * rcsThrust * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate(-Vector3.forward * rcsThrust * Time.deltaTime);
		}
		if(Input.GetKeyDown(KeyCode.O)){
			if(isCollision){
				isCollision = false;
			} else {
				isCollision = true;
			}
		}
	}

	private void OnCollisionEnter (Collision col) {
		if(isCollision){
			if(col.gameObject.name != "Target Pad" && col.gameObject.name != "Launchpad")
	        {
	            SceneManager.LoadScene("Level1");
	        }
    	}
    }
}
