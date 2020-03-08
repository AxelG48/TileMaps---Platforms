using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(Vector3.forward);
    }
}
