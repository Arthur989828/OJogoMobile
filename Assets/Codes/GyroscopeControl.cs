using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeControl : MonoBehaviour
{
    private bool enabledGyro;
    private Gyroscope gyro;

    private GameObject camContainer;
    private QualitySettings rot;

    // Start is called before the first frame update
    private void Start()
    {
        camContainer = new GameObject("Cam Container");
        camContainer.transform.position = transform.position;
        transform.SetParent(camContainer.transform);

        enabledGyro = GyroEnabled();
    }

    private bool GyroEnabled()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            enabledGyro = true;

            camContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            //rot = new Quaternion(0, 0, 1, 0);

            return true;
        }

        return false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (enabledGyro)
        {
            //transform.localRotation = gyro.attitude * rot;
        }
    }

}
