using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    Vector3 Initposition;
    Quaternion rot;
    int layerMask = 1 << 6;

    public FPSWalk walk;
    public Transform InspectZone;

    public static GameObject currentObj, manager;
    private Rigidbody rb;

    bool inspecting = false;

    private void Start()
    {
        manager = GameObject.Find("PhysicsManager");
    }

    void Update()
    {
        RaycastHit info;
        if(Physics.Raycast(transform.position,transform.forward, out info, 4f, layerMask))
        {
            StopAllCoroutines();
            currentObj = info.collider.gameObject;
            rb = currentObj.GetComponent<Rigidbody>();
            Initposition = info.collider.transform.position;
            rot = Quaternion.Euler(info.collider.transform.localEulerAngles);
            if(rb != null)
            {
                rb.isKinematic = true;
            }
            walk.enabled = false;
            StartCoroutine(MoveToTarget(currentObj, InspectZone.position, 0.8f));
            inspecting = true;
            manager.GetComponent<ItemTransforms>().enabled = true;
            currentObj.transform.rotation = Quaternion.Euler(rot.eulerAngles);
            StartCoroutine(MoveToTarget(currentObj, Initposition, Time.deltaTime*100f));
            inspecting = false;
            walk.enabled = true;
            if(rb != null)
            {
                StartCoroutine(TogglePhysics(rb, true, 5f));
            }
        }

        //transform.Rotate(new Vector3(Time.deltaTime * -5, 0, 0));
    }

    IEnumerator MoveToTarget(GameObject MovedObj, Vector3 Target, float speed)
    {
        while (MovedObj.transform.position != Target)
        {
            MovedObj.transform.position = Vector3.MoveTowards(MovedObj.transform.position, Target, Time.deltaTime * speed);
            yield return null;
        }
    }

    IEnumerator TogglePhysics(Rigidbody rb, bool value, float TimeWait)
    {
        yield return new WaitForSeconds(TimeWait);
        rb.isKinematic = !value;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
