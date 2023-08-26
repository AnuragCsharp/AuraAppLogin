using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

// this script checks if a button is pressed and changes the active gamobject canvas accordingly
public class sceneChanger : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    public GameObject mainCamera;
    public GameObject arCamera;

    public GameObject ARSessionOrigin;
    public GameObject ARSession;

    public TMP_Text aniName;

    public prefabManager pre;

    [SerializeField]
    private ARPlaneManager _arPlaneManager;

    public ARTapToPlace tap;

    public void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        mainCamera.SetActive(true);
        arCamera.SetActive(false);
        ARSession.SetActive(false);
        ARSessionOrigin.SetActive(false);
    }

    /*public void changeScene1()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
        Debug.Log("changeScene1");
    }*/

    public void startAR()
    {
        // var xrManagerSettings = UnityEngine.XR.Management.XRGeneralSettings.Instance.Manager;
        // xrManagerSettings.InitializeLoader();
        // xrManagerSettings.StartSubsystems();

        canvas1.SetActive(false);
        canvas2.SetActive(true);
        mainCamera.SetActive(false);
        arCamera.SetActive(true);
        ARSession.SetActive(true);
        ARSessionOrigin.SetActive(true);
        _arPlaneManager.enabled = true;
        tap.enabled = true;
        // SceneManager.LoadScene("ARScene");
    }

    public void back()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        mainCamera.SetActive(true);
        arCamera.SetActive(false);
        tap.changeToNull();
        tap.enabled = false;
        // pre.changeToNull();
        ARSession.SetActive(false);
        ARSessionOrigin.SetActive(false);
        _arPlaneManager.enabled = false;
    }

    public void ani1()
    {
        pre.changePrefab1();
        aniName.text = "Anaconda";
        startAR();
    }

    public void ani2()
    {
        pre.changePrefab2();
        aniName.text = "Rhino";
        startAR();
    }

    public void ani3()
    {
        pre.changePrefab3();
        aniName.text = "Elephant";
        startAR();
    }

    public void ani4()
    {
        pre.changePrefab4();
        aniName.text = "Bear";
        startAR();
    }

    public void ani5()
    {
        pre.changePrefab5();
        aniName.text = "Hippo";
        startAR();
    }

    public void ani6()
    {
        pre.changePrefab6();
        aniName.text = "Jaguar";
        startAR();
    }

    public void ani7()
    {
        pre.changePrefab7();
        aniName.text = "Rat";
        startAR();
    }

    public void ani8()
    {
        pre.changePrefab8();
        aniName.text = "Horn Lizard";
        startAR();
    }
}
