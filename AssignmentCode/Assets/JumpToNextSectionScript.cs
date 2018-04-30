using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToNextSectionScript : MonoBehaviour {

    public bool Active = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Active)
        {
            if (transform.position.z > 170)
            {
                foreach (var go in GameObject.FindGameObjectsWithTag("Ship"))
                {
                    go.transform.position += new Vector3(0, 0, -245);
                }

                foreach (var go in GameObject.FindGameObjectsWithTag("Laser"))
                {
                    go.transform.position += new Vector3(0, 0, -245);
                }

            }
            else if (transform.position.z < -78)
            {
                foreach (var go in GameObject.FindGameObjectsWithTag("Ship"))
                {
                    transform.position += new Vector3(0, 0, 245);
                }

                foreach (var go in GameObject.FindGameObjectsWithTag("Laser"))
                {
                    transform.position += new Vector3(0, 0, 245);
                }
            }
        }
    }
}
