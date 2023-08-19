using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        mainCamera.SetActive(false);
        arCamera.SetActive(true);
        ARSession.SetActive(true);
        ARSessionOrigin.SetActive(true);
    }

    public void changeScene3()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(true);
        mainCamera.SetActive(false);
        arCamera.SetActive(true);
        ARSession.SetActive(true);
        ARSessionOrigin.SetActive(true);

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
        arCamera.SetActive(false);
        ARSession.SetActive(false);
        ARSessionOrigin.SetActive(false);
    }

    public void ani1()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(true);
        mainCamera.SetActive(false);
        arCamera.SetActive(true);
        ARSession.SetActive(true);
        ARSessionOrigin.SetActive(true);
        pre.changePrefab1();
        aniName.text = "Anaconda";
    }

    public void ani2()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(true);
        mainCamera.SetActive(false);
        arCamera.SetActive(true);
        ARSession.SetActive(true);
        ARSessionOrigin.SetActive(true);
        pre.changePrefab2();
        aniName.text = "Rhino";
    }

    public void ani3()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(true);
        mainCamera.SetActive(false);
        arCamera.SetActive(true);
        ARSession.SetActive(true);
        ARSessionOrigin.SetActive(true);
        pre.changePrefab3();
        aniName.text = "Elephant";
    }

    public void ani4()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(true);
        mainCamera.SetActive(false);
        arCamera.SetActive(true);
        ARSession.SetActive(true);
        ARSessionOrigin.SetActive(true);
        pre.changePrefab4();
        aniName.text = "Bear";
    }

    public void ani5()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(true);
        mainCamera.SetActive(false);
        arCamera.SetActive(true);
        ARSession.SetActive(true);
        ARSessionOrigin.SetActive(true);
        pre.changePrefab5();
        aniName.text = "Hippo";
    }

    public void ani6()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(true);
        mainCamera.SetActive(false);
        arCamera.SetActive(true);
        ARSession.SetActive(true);
        ARSessionOrigin.SetActive(true);
        pre.changePrefab6();
        aniName.text = "Jaguar";
    }

    public void ani7()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(true);
        mainCamera.SetActive(false);
        arCamera.SetActive(true);
        ARSession.SetActive(true);
        ARSessionOrigin.SetActive(true);
        pre.changePrefab7();
        aniName.text = "Rat";
    }

    public void ani8()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(true);
        mainCamera.SetActive(false);
        arCamera.SetActive(true);
        ARSession.SetActive(true);
        ARSessionOrigin.SetActive(true);
        pre.changePrefab7();
        aniName.text = "Horn Lizard";
    }
}
