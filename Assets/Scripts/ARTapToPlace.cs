using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace : MonoBehaviour
{
    public GameObject spawnablePrefab;

    ARRaycastManager m_arRaycastManager;
    Camera arCam;
    public GameObject spawnedObject = null;

    //public Text text;

    private bool isPlacingObject = false;

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    void Start()
    {
        spawnedObject = null;
        m_arRaycastManager = GetComponent<ARRaycastManager>();
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    private void SpawnPrefab(Vector3 spawnPosition)
    {
        if (isPlacingObject)
            return;

        isPlacingObject = true;
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
                    spawnedObject = hit.collider.gameObject;
                    if (hit.collider.gameObject.tag == "Spawnable")
                    {
                        spawnedObject = hit.collider.gameObject;
                        //text.text = null;
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