using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

    public float Speed = 300;
    public float age = 0;
    private float lifeSpan = 5;
    public bool laserActive = false;
    public bool isTorpedo = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(laserActive)
        {
            transform.Translate(new Vector3(0, Speed * Time.deltaTime, 0));
            age += Time.deltaTime;

            if (age > lifeSpan)
            {
                Destroy(gameObject);
            }
        }
        else if(isTorpedo)
        {
            transform.Translate(new Vector3(0, Speed * Time.deltaTime, Speed/15 * Time.deltaTime));
        }
    }
}
