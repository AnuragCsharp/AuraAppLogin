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
    public GameObject canvas3;
    public GameObject canvas4;

    public GameObject mainCamera;
    public GameObject arCamera;

    public GameObject ARSessionOrigin;
    public GameObject ARSession;

    public TMP_Text aniName;

    public prefabManager pre;

    [SerializeField]
    private ARSession _arSession;

    [SerializeField]
    private ARSessionOrigin _arSessionOrigin;

    [SerializeField]
    private ARPlaneManager _arPlaneManager;

    void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
        mainCamera.SetActive(true);
        arCamera.SetActive(false);
        ARSession.SetActive(false);
        ARSessionOrigin.SetActive(false);
    }

    public void changeScene1()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
    }

    public void changeScene2()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(true);
        canvas4.SetActive(false);
    }

    public void startAR()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(true);
        mainCamera.SetActive(false);
        arCamera.SetActive(true);
        ARSession.SetActive(true);
        ARSessionOrigin.SetActive(true);
        _arSession.enabled = true;
        _arSessionOrigin.enabled = true;
        _arPlaneManager.enabled = true;
        //SceneManager.LoadScene("ARScene");
    }

    public void changeScene4()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
    }

    public void back()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(true);
        canvas4.SetActive(false);
        mainCamera.SetActive(true);
        pre.changeToNull();
        arCamera.SetActive(false);
        ARSession.SetActive(false);
        ARSessionOrigin.SetActive(false);
        _arSession.enabled = false;
        _arSessionOrigin.enabled = false;
        _arPlaneManager.enabled = false;
        _arSession.Reset();
        //reset AR Plane Manager
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
