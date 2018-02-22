using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldTankController : MonoBehaviour
{
    // *********************************************************************************************
    // *********************************************************************************************
    // ***** Original tank controller from the labs - some of this logic will be useful later ******
    // *********************************************************************************************
    // *********************************************************************************************






    /*GameObject prefabEnemyTank;

    // Use this for initialization
    void Start()
    {
        //StartCoroutine(SpawnNewTanksIfNotEnough());
    }

    public float movementSpeed = 20;
    public float rotationSpeed = 20;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed, 0);
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = GameObject.Find("Bullet");
            var controller = bullet.GetComponent<BulletController>();

            var newbullet = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
            var newController = newbullet.GetComponent<BulletController>();
            newController.active = true;

            newController.Fire(10);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            var cube = GameObject.Find("TowerPiece");

            float heightOfTower = 20;
            float heightOfBox = cube.transform.localScale.y;
            float numPointsInCircle = 42;
            var centerPosition = this.transform.position + (transform.rotation * Vector3.forward * 10);
            float thetaInc = (Mathf.PI * 2) / numPointsInCircle;
            float rad = 8;
            bool OffsetIncrementByHalf = false;

            for (int z = 0; z < heightOfTower; z++)
            {
                for (int i = 0; i < numPointsInCircle; i++)
                {
                    var angleOffset = thetaInc * i;

                    if (OffsetIncrementByHalf)
                    {
                        angleOffset += thetaInc / 2;
                    }

                    var zOffs = rad * Mathf.Sin(angleOffset);
                    var xOffs = rad * Mathf.Cos(angleOffset);

                    var offs = new Vector3(xOffs, z * heightOfBox, zOffs);

                    var newCube = Instantiate(cube, centerPosition + offs, new Quaternion());
                    newCube.transform.LookAt(centerPosition + new Vector3(0, z * heightOfBox, 0));
                }

                OffsetIncrementByHalf = !OffsetIncrementByHalf;
            }
        }


        if (Input.GetKey(KeyCode.Y))
        {
            var cubes = GameObject.FindGameObjectsWithTag("TowerPiece");

            foreach (var cube in cubes)
            {
                //cube.transform.Rotate(0, 1, 0);

                cube.transform.LookAt(this.transform);

            }
        }

    }

    IEnumerator SpawnNewTanksIfNotEnough()
    {
        yield return new WaitForSeconds(3.0f);

        while (true)
        {
            var enemies = GameObject.FindGameObjectsWithTag("EnemyTank");
            if (enemies.Length < 5)
            {
                var prefabEnemy = (EnemyTankController)Resources.FindObjectsOfTypeAll(typeof(EnemyTankController))[0];
                var randomX = Random.Range(-10, 10);
                var randomZ = Random.Range(-10, 10);

                Instantiate(prefabEnemy, new Vector3(randomX, 1.5f, randomZ), new Quaternion());
            }

            yield return new WaitForSeconds(3.0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CollideCheckingCube")
        {
            movementSpeed = 0;
        }
    }*/
}
