using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridOverlayController : MonoBehaviour {

    public static bool Active = false;
    private Color color = Color.cyan;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Active)
        {
            CastRay(-120, -7, -18, 50, 0, 0);
            CastRay(-120, -7, 44, 50, 0, 0);
            CastRay(-120, -7, 106, 50, 0, 0);
            CastRay(-120, -7, 168, 50, 0, 0);
            CastRay(-120, -7, 230, 50, 0, 0);

            CastRay(-120, -7, -18, 0, 35, 0);
            CastRay(-120, -7, 44, 0, 35, 0);
            CastRay(-120, -7, 106, 0, 35, 0);
            CastRay(-120, -7, 168, 0, 35, 0);
            CastRay(-120, -7, 230, 0, 35, 0);

            CastRay(-70, -7, -18, 0, 35, 0);
            CastRay(-70, -7, 44, 0, 35, 0);
            CastRay(-70, -7, 106, 0, 35, 0);
            CastRay(-70, -7, 168, 0, 35, 0);
            CastRay(-70, -7, 230, 0, 35, 0);

            CastRay(-120, -7, -18, 0, 0, 248);
            CastRay(-70, -7, -18, 0, 0, 248);
            CastRay(-120, 28, -18, 0, 0, 248);
            CastRay(-70, 28, -18, 0, 0, 248);
        }
    }

    void CastRay(float x1,float y1,float z1,float x2,float y2,float z2)
    {
        var point1 = new Vector3(x1, y1, z1);
        var point2 = new Vector3(x2, y2, z2);
        Debug.DrawRay(transform.position + point1, point2, color);
    }
}
