using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject target;
    public AudioSource music;
    public AudioClip win;
    public bool didwin = false;
    public bool level2 = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void LateUpdate()
    {
        if (target != null && level2==false)
        {
            this.transform.position = new Vector3(target.transform.position.x, this.transform.position.y, this.transform.position.z);
        } else if (target != null && level2 == true)
        {
            this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
        }
        if (didwin == true)
        {
            music.Stop();
            music.clip = win;
            music.Play();
            didwin = false;

        }
    }
}