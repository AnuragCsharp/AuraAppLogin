using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour
{
    sceneChanger scene;
    public void back()
    {
        //this is giving instance error
        //tap.spawnablePrefab = null;

        SceneManager.LoadScene("Main UI");
        scene.changeScene2();
    }
}
