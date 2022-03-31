using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeControl : MonoBehaviour
{
        private bool gyroEnabled;
        private Gyroscope gyro;

        private GameObject cam;
        public GameObject fps;
        private Quaternion rot;

        private void Start()
        {
            cam = new GameObject("Cam Container");

            fps.transform.position = transform.position;
            transform.SetParent(fps.transform);

            gyroEnabled = EnableGyro();
        }

        private bool EnableGyro()
        {
            if (SystemInfo.supportsGyroscope)
            {
                gyro = Input.gyro;
                gyro.enabled = true;

                cam.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
                rot = new Quaternion(0, 0, 1, 0);

                return true;
            }
            return false;
        }
        private void Update()
        {
            if (gyroEnabled)
            {
                transform.localRotation = gyro.attitude * rot;
            }
        }
}
