using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    // *********************************************************************************************
    // *********************************************************************************************
    // ***** Original bullet controller from the labs - some of this logic will be useful later ****
    // *********************************************************************************************
    // *********************************************************************************************




    /*public bool active = false;
    float movementSpeed = 1;

    // Use this for initialization
    void Start ()
    {
        if(!active)
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }

    float totalTime = 0;

    // Update is called once per frame
    void Update ()
    {
        if(active)
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;

            totalTime += Time.deltaTime;

            if(totalTime>3)
            {
                Destroy(this.gameObject);
            }
        }

    }

    public void Fire(float speed)
    {
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
        this.movementSpeed = speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        var name =collision.gameObject;
    }*/

}
