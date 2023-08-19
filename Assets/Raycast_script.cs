using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Raycast_script : MonoBehaviour
{
    [SerializeField]
    public GameObject spawn_prefab;


    GameObject spawned_object;
    bool object_spawned;
    ARRaycastManager arrayman;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        object_spawned = false;
        arrayman = GetComponent<ARRaycastManager>();

    }
    void stoprun()
    {
        spawned_object.GetComponent<Animator>().SetBool("Run", false);
    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            
            {
                if (arrayman.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon) && !object_spawned)
                {
                    var hitpose = hits[0].pose;

                    // if (!object_spawned)
                    {
                        Debug.Log("Spwan");
                        spawned_object = Instantiate(spawn_prefab, hitpose.position, hitpose.rotation);
                        object_spawned = true;
                        // gameObject.GetComponent<Raycast_script>().enabled = false;
                    }
                }
                
            }

        }

    }
}
