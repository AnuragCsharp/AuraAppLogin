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
    private float initialDistance;
    private Vector3 initialScale;

    public Text text;

    Vector3 poseOriginal;
    Vector3 scaleOriginal;
    Vector3 rotationOriginal;

    bool isPlacingObject = false;

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    public sceneChanger sceneChanger;

    void Start()
    {
        DestroyImmediate(spawnedObject);
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }
    public void changeToNull()
    {
        Debug.Log("changeToNull");
        // DestroyImmediate(spawnedObject, true);
        isPlacingObject = false;
        // spawnedObject = null;
        // spawnablePrefab = null;

        // var xrManagerSettings = UnityEngine.XR.Management.XRGeneralSettings.Instance.Manager;
        // xrManagerSettings.DeinitializeLoader();
        // xrManagerSettings.StopSubsystems();
        SceneManager.LoadScene("Main UI"); // reload current scene
        // sceneChanger.changeScene2();
        // xrManagerSettings.StartSubsystems();

        //close script
        //Destroy(this);
    }

    private void SpawnPrefab(Vector3 spawnPosition)
    {
        if (isPlacingObject)
            return;

        poseOriginal = spawnPosition;
        scaleOriginal = spawnablePrefab.transform.localScale;
        rotationOriginal = spawnablePrefab.transform.rotation.eulerAngles;
        isPlacingObject = true;
        if (spawnedObject != null)
            Destroy(spawnedObject);
        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
        //text.text = "hit";
    }

    // function to reset the position of the spawned object to the original position
    public void resetPrefab()
    {
        if (spawnedObject != null)
        {
            DestroyImmediate(spawnedObject);
            spawnedObject = Instantiate(spawnablePrefab, poseOriginal, Quaternion.Euler(rotationOriginal));

            text.text = "Prefab reset";
            Debug.Log("Prefab reset");
        }
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
                        // Hide plane detection visualization here (specific to ARCore).
                        ARPlaneManager planeManager = FindObjectOfType<ARPlaneManager>();
                        if (planeManager != null)
                        {
                            planeManager.SetTrackablesActive(false);
                        }
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved && spawnedObject != null)
            {
                Vector3 posi = m_Hits[0].pose.position;
                posi.y = poseOriginal.y;
                spawnedObject.transform.position = posi;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                spawnedObject = null;
            }
        }

        // pinch to scale using two touch counts and scaling wrt the distance between the two touches
        if(Input.touchCount == 2)
        {
            var touchZero = Input.GetTouch(0);
            var touchOne = Input.GetTouch(1);

            // if either of the touches ended or cancelled, do nothing
            if(touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled || 
                touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled)
            {
                return;
            }

            // if touch began for both touches, find the distance between them
            if(touchZero.phase == TouchPhase.Began && touchOne.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                initialScale = spawnedObject.transform.localScale;
            }
            else // if touch is moved
            {
                // find the current distance between the two touches
                var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

                //if accidentally touched or  pinch movement is very very small
                if (Mathf.Approximately(initialDistance, 0))
                {
                    return;
                }

                // scale the object based on the change in distance between the touches
                var factor = currentDistance / initialDistance;
                spawnedObject.transform.localScale = initialScale * factor;
            }
        }
    }
}