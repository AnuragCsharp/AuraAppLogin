using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logIn : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    // Start is called before the first frame update
    void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }

    public void signUp()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }

    public void logInAgain()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }

    public void changeScene()
    {
        SceneManager.LoadScene("Main UI");
    }
}
