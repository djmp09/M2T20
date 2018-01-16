using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour {

	private void OnCollisionEnter (Collision col) {
		Renderer rend = GetComponent<Renderer>();
		Color color = Color.green;
		if(col.gameObject.name == "Rocket Ship")
        {
        	rend.material.color = color;
        }
        
    }


}
