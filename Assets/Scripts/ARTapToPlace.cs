using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace : MonoBehaviour
{
    public GameObject spawnablePrefab;

    [SerializeField]
    ARRaycastManager m_arRaycastManager;
    Camera arCam;
    public GameObject spawnedObject = null;

    //public Text text;

    public bool isPlacingObject = false;

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    void Start()
    {
        DestroyImmediate(spawnedObject);
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    public void changeToNull()
    {
        Debug.Log("changeToNull");
        DestroyImmediate(spawnedObject, true);
        isPlacingObject = false;
        spawnedObject = null;
        spawnablePrefab = null;

        var xrManagerSettings = UnityEngine.XR.Management.XRGeneralSettings.Instance.Manager;
        xrManagerSettings.DeinitializeLoader();
        SceneManager.LoadScene("Main UI"); // reload current scene
        xrManagerSettings.InitializeLoaderSync();

        //close script
        //Destroy(this);
    }

    private void SpawnPrefab(Vector3 spawnPosition)
    {
        if (isPlacingObject)
            return;

        isPlacingObject = true;
        if (spawnedObject != null)
            Destroy(spawnedObject);
        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
        //text.text = "hit";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);
        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(touch.position);

        if (m_arRaycastManager.Raycast(touch.position, m_Hits))
        {
            if (touch.phase == TouchPhase.Began && spawnedObject == null)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Spawnable")
                    {
                        spawnedObject = hit.collider.gameObject;
                    }
                    else
                    {
                        SpawnPrefab(m_Hits[0].pose.position);
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = m_Hits[0].pose.position;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                spawnedObject = null;
            }
        }
    }
}