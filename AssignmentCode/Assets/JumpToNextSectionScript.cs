using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToNextSectionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.z > 170)
        {
            foreach(var go in GameObject.FindGameObjectsWithTag("XWing"))
            {
                go.transform.position += new Vector3(0, 0, -245);
            }
        }
        else if (transform.position.z < -78)
        {
            foreach (var go in GameObject.FindGameObjectsWithTag("XWing"))
            {
                transform.position += new Vector3(0, 0, 245);
            }
        }
    }
}
