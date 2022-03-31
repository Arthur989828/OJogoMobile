using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTransforms : MonoBehaviour
{
    public float Speed = 100f;

    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxis("Mouse X") * Speed;
        float y = Input.GetAxis("Mouse Y") * Speed;
        PickItem.currentObj.transform.Rotate(-Vector3.up * x, Space.World);
        PickItem.currentObj.transform.Rotate(-Vector3.forward * y, Space.World);

    }
}
