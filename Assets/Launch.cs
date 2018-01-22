using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launch : MonoBehaviour {

	float dist1;
	public float launch_dist = 10f;
	GameObject rocket1;
	Renderer rend;
	Color color;
	Color color1;
	Color color2;
	Scene scene;
	string scene_name;

    void Start()
    {	
    	rend = GetComponent<Renderer>();
		color = Color.green;
		color1 = Color.blue;
		color2 = Color.red;
    	rocket1 = GameObject.Find("Rocket Ship");
    	dist1 = 0f;
    	scene = SceneManager.GetActiveScene();
    	scene_name = scene.name;
    }

    void Update () {
    	dist1 = Vector3.Distance(rocket1.transform.position, transform.position);

    	if(dist1 < launch_dist){
    		rend.material.color = color1;
    	} else {
    		rend.material.color = color2;
    	}

    	if(dist1 < 1.7){
    		if(scene_name == "Level1"){
    			//SceneManager.UnloadScene("Level1");
    			SceneManager.LoadScene("Level2");		
    		} else if(scene_name == "Level2"){
    			//SceneManager.UnloadScene("Level2");
    			SceneManager.LoadScene("Level3");		
    		} else {
    			rend.material.color = color;		
    		}
    		
    	}

    }
}
