using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public GameObject laser;

    public AudioSource explosionSound;
    public AudioSource battleMusic;
    public AudioSource useTheforce;
    public AudioSource endCredits;

    TankController me;
    string currentCamera = "BehindCamera";
    Vector3 shipOrigin = new Vector3(-21.5f, 14.8f, -73.3f);


    void Start()
    {
        StartCoroutine(ManageScenes());
        me = GetComponent<TankController>();
        GameObject.Find("Explosion").GetComponent<ParticleSystem>().Pause();
    }

    IEnumerator ManageScenes()
    {
        battleMusic.Play();
        yield return new WaitForSeconds(1);
        Setup();

        SetupDescentScene();
        SwitchCamera("BehindCamera");
        yield return new WaitForSeconds(4);
        SwitchCamera("LookingFromFrontSideCamera");
        yield return new WaitForSeconds(4);
        SetupHoverScene();
        SwitchCamera("TopDownCameraHigher");
        yield return new WaitForSeconds(4);
        SetupHoverScene();
        SwitchCamera("LookingFromFrontSideCamera");
        ForEachShip(s => s.GetComponent<TankController>().maxMovementSpeed = 20);
        me.target = GameObject.Find("Death Star");
        yield return new WaitForSeconds(8);
        SetupTrenchDescentScene();
        SwitchCamera("NoseCamera");
        yield return new WaitForSeconds(7);
        SetupTrenchScene();
        SwitchCamera("TopDownCameraHigher");
        yield return new WaitForSeconds(2);
        SwitchCamera("LookingFromFrontSideCamera");
        yield return new WaitForSeconds(2);
        SwitchCamera("LookingFromFrontSideCamera");
        yield return new WaitForSeconds(2);
        SetupEnemyDescentScene();
        GameObject.Find("TIEInterceptorVader").transform.Find("LookingFromFrontSideCamera").gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        GameObject.Find("TIEInterceptorVader").transform.Find("LookingFromFrontSideCamera").gameObject.SetActive(false);
        SetupTrenchFightScene();
        GameObject.Find("TIEInterceptorVader").transform.Find("NoseCamera").gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        GameObject.Find("TIEInterceptorVader").transform.Find("NoseCamera").gameObject.SetActive(false);
        SetupTargetingScene();
        SwitchCamera("NoseCamera");
        yield return new WaitForSeconds(8);
        GridOverlayController.Active = false;
        SetupTrenchFightScene();
        GameObject.Find("TIEInterceptorVader").transform.Find("LookingFromFrontSideCamera").gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        GridOverlayController.Active = true;
        SetupTargetingScene();
        SwitchCamera("NoseCamera");
        yield return new WaitForSeconds(4);
        SetupTurnOffTargetingComputerScene();
        yield return new WaitForSeconds(5);
        SetupTorpedoScene();
        yield return new WaitForSeconds(4);
        SetupExplosionScene();
        yield return new WaitForSeconds(3);

        SwitchCamera("EndCreditsCamera");
        battleMusic.Stop();
        endCredits.Play();
    }


    public void Setup()
    {
        me = GetComponent<TankController>();

        if (me == null)
        {
            throw new System.Exception("TankController was not found");
        }
    }

    public void SetupDescentScene()
    {
        GameObject.Find("TrenchRunFull").transform.position = new Vector3(0, -1000, 0);
        GameObject.Find("Death Star").transform.position = new Vector3(-50, 50, 1000);
        GameObject.Find("Death Star").transform.rotation = Quaternion.Euler(0, 180, 0);
        GameObject.Find("Directional Light").transform.rotation = Quaternion.Euler(121.884f, -153.079f, -149.279f);

        ResetXWingTransforms();
        ForEachShip(s => s.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation);
        ForEachShip(s => s.GetComponent<BoxCollider>().enabled = false);
        ForEachShip(s => s.GetComponent<TankController>().maxMovementSpeed = 100);
        ForEachShip(s => s.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 100));

        me.target = GameObject.Find("Death Star");
        GetComponent<JumpToNextSectionScript>().Active = false;
    }

    public void SetupHoverScene()
    {
        SetupDescentScene();

        SetXWingFormationPosition(new Vector3(-60, 300, 913));
        ForEachShip(s => s.GetComponent<Rigidbody>().transform.rotation = Quaternion.Euler(-11.483f, 0, 0));
        ForEachShip(s => s.GetComponent<TankController>().maxMovementSpeed = 0);
        ForEachShip(s => s.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10));
    }

    public void SetupTrenchDescentScene()
    {
        GameObject.Find("Directional Light").transform.position = new Vector3(-27, 52, 222);
        GameObject.Find("Directional Light").transform.rotation = Quaternion.Euler(132.958f, -17.36899f, -23.32599f);

        GameObject.Find("Death Star").transform.position = new Vector3(0, -10000, 0);
        GameObject.Find("TrenchRunFull").transform.position = new Vector3(-12.83984f, -49.125f, -15.02393f);

        ResetXWingTransforms();
        SetXWingFormationPosition(shipOrigin + new Vector3(0, 50, 0));

        ForEachShip(s => s.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation);
        ForEachShip(s => s.GetComponent<BoxCollider>().enabled = true);
        ForEachShip(s => s.GetComponent<TankController>().maxMovementSpeed = 100);
        ForEachShip(s => s.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 100));

        me.target = GameObject.Find("StayOnTarget");
        GetComponent<JumpToNextSectionScript>().Active = true;
    }

    public void SetupTrenchScene()
    {
        SetupTrenchDescentScene();

        ResetXWingTransforms();
        ForEachXWing(s => s.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY);
    }

    public void SetupEnemyDescentScene()
    {
        SetupTrenchScene();

        ResetTieFighterTransforms();
        SetTieFighterFormationPosition(shipOrigin + new Vector3(0, 50, 0));
        SetXWingFormationPosition(new Vector3(0,-100,0));

        ForEachTieFighter(s => s.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation);
        ForEachTieFighter(s => s.GetComponent<BoxCollider>().enabled = true);
        ForEachTieFighter(s => s.GetComponent<TankController>().maxMovementSpeed = 100);
        ForEachTieFighter(s => s.GetComponent<TankController>().shooting = true);
        ForEachTieFighter(s => s.GetComponent<Rigidbody>().velocity = new Vector3(0, -10, 100));

        GameObject.Find("TIEInterceptorVader").GetComponent<TankController>().target = GameObject.Find("StayOnTarget");
        GetComponent<JumpToNextSectionScript>().Active = true;
    }

    public void SetupTrenchFightScene()
    {
        SetupEnemyDescentScene();
        SetTieFighterFormationPosition(shipOrigin + new Vector3(0, 0, -50));
        ForEachTieFighter(s => s.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 100));
    }

    public void SetupTargetingScene()
    {
        SetupTrenchScene();
        GridOverlayController.Active = true;
    }

    public void SetupTurnOffTargetingComputerScene()
    {
        SetupTrenchScene();
        GridOverlayController.Active = false;
        battleMusic.Pause();
        useTheforce.Play();
        ForEachTieFighter(s => s.GetComponent<TankController>().shooting = false);

    }

    public void SetupTorpedoScene()
    {
        SetupTrenchScene();


        var newLaser = Instantiate(laser, GameObject.Find("XWingHero").transform.position + new Vector3(0, 0, 3), Quaternion.Euler(90, 0, 0));
        newLaser.GetComponent<LaserController>().Speed = 110;
        newLaser.GetComponent<LaserController>().isTorpedo = true;
        newLaser.transform.Find("LookingFromFrontSideCamera").gameObject.SetActive(true);
    }

    public void SetupExplosionScene()
    {
        SetupDescentScene();
        ForEachTieFighter(s => s.GetComponent<TankController>().shooting = false);

        useTheforce.Pause();
        battleMusic.Play();

        GameObject.Find("Death Star").transform.Find("ExplosionCamera").gameObject.SetActive(true);
        var exp = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
        exp.Play();
        explosionSound.Play();
        //GameObject.Find("Death Star").transform.Find("ExplosionCamera").gameObject.SetActive(false);
        //Destroy(GameObject.Find("Death Star"), exp.main.duration);
    }

    public void SwitchCamera(string newCamera)
    {
        transform.Find(currentCamera).gameObject.SetActive(false);
        transform.Find(newCamera).gameObject.SetActive(true);
        currentCamera = newCamera;
    }

    public void ResetXWingTransforms()
    {
        ForEachXWing(s => s.GetComponent<Rigidbody>().transform.rotation = Quaternion.Euler(0,0,0));
        SetXWingFormationPosition(shipOrigin);
    }

    public void ResetTieFighterTransforms()
    {
        ForEachTieFighter(s => s.GetComponent<Rigidbody>().transform.rotation = Quaternion.Euler(0, 0, 0));
        SetTieFighterFormationPosition(shipOrigin + new Vector3(0,20,-30));
    }


    public void SetXWingFormationPosition(Vector3 point)
    {
        GameObject.Find("XWingHero").transform.position = point;
        GameObject.Find("XWingFollower1").transform.position = point + new Vector3(11, 0, -20);
        GameObject.Find("XWingFollower2").transform.position = point + new Vector3(-11, 0, -20);
        GameObject.Find("XWingFollower3").transform.position = point + new Vector3(8, 0, -40);
        GameObject.Find("XWingFollower4").transform.position = point + new Vector3(-8, 0, -40);
    }

    public void SetTieFighterFormationPosition(Vector3 point)
    {
        GameObject.Find("TIEInterceptorVader").transform.position = point;
        GameObject.Find("TIEInterceptorFollower1").transform.position = point + new Vector3(11, 0, -20);
        GameObject.Find("TIEInterceptorFollower2").transform.position = point + new Vector3(-11, 0, -20);
    }


    public void ForEachShip(Action<GameObject> operation)
    {
        ForEachXWing(operation);
        ForEachTieFighter(operation);
    }

    public void ForEachXWing(Action<GameObject> operation)
    {
        operation(GameObject.Find("XWingHero"));
        operation(GameObject.Find("XWingFollower1"));
        operation(GameObject.Find("XWingFollower2"));
        operation(GameObject.Find("XWingFollower3"));
        operation(GameObject.Find("XWingFollower4"));
    }

    public void ForEachTieFighter(Action<GameObject> operation)
    {
        operation(GameObject.Find("TIEInterceptorVader"));
        operation(GameObject.Find("TIEInterceptorFollower1"));
        operation(GameObject.Find("TIEInterceptorFollower2"));
    }
}
