using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)// tocou pelo menos uma vez 
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Moved)// tocou e moveu o dedo 
            {
                Vector2 rot = new Vector2(t.deltaPosition.y, t.deltaPosition.x * -1);// ajuste da direcao e eixos 
                transform.Rotate(rot * 5 * Time.deltaTime, Space.World);
            }
        }

    }
}
