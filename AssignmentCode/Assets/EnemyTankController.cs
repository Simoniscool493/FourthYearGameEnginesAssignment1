using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController : MonoBehaviour {

    // *********************************************************************************************
    // *********************************************************************************************
    // ** Original enemy tank controller from the labs - some of this logic will be useful later ***
    // *********************************************************************************************
    // *********************************************************************************************

    /*
    // Use this for initialization
    void Start () {
        //this.gameObject.tag = "EnemyTank";
	}

	
	// Update is called once per frame
	void Update ()
    {
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(2.0f);

        Destroy(this.gameObject);
    }*/
}
