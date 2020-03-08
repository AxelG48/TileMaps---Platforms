using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentobject : MonoBehaviour
{
    int temp = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > 7)
        {
            temp = -1;
        } else  if (transform.position.y < -1.7)
        {
            temp = 1;
        } else if (transform.eulerAngles.z == 90 && transform.position.x < 37.72)
        {
            temp = -1;
        } else if (transform.eulerAngles.z == 90 && transform.position.x > 43.63)
        {
            temp = 1;
        }

        transform.Translate(new Vector3(0, 1, 0) * temp * Time.deltaTime);

    }
}
