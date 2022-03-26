using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    void Update()
    {
        //transform.Rotate(new Vector3(Time.deltaTime * -5, 0, 0));
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
