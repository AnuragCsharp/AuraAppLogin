using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class prefabManager : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public GameObject prefab8;

    //public GameObject spawnablePrefab;
    public ARTapToPlace tap;

    public void changePrefab1()
    {
        Debug.Log("changePrefab1");
        tap.spawnablePrefab = prefab1;
    }

    public void changePrefab2()
    {
        Debug.Log("changePrefab2");
        tap.spawnablePrefab = prefab2;
    }

    public void changePrefab3()
    {
        Debug.Log("changePrefab3");
        tap.spawnablePrefab = prefab3;
    }

    public void changePrefab4()
    {
        Debug.Log("changePrefab4");
        tap.spawnablePrefab = prefab4;
    }

    public void changePrefab5()
    {
        Debug.Log("changePrefab5");
        tap.spawnablePrefab = prefab5;
    }

    public void changePrefab6()
    {
        Debug.Log("changePrefab6");
        tap.spawnablePrefab = prefab6;
    }

    public void changePrefab7()
    {
        Debug.Log("changePrefab7");
        tap.spawnablePrefab = prefab7;
    }

    public void changePrefab8()
    {
        Debug.Log("changePrefab8");
        tap.spawnablePrefab = prefab8;
    }

    /*public void changeToNull()
    {
        Debug.Log("changeToNull");
        DestroyImmediate(tap.spawnedObject, true);
        tap.isPlacingObject = false;
        tap.spawnedObject = null;
        //tap.spawnablePrefab = null;
    }*/

    /*void Start()
    {
        tap = GameObject.Find("AR Session Origin").GetComponent<ARTapToPlace>();
    }*/
}
