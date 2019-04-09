using UnityEngine;
using System.Collections;

public class MyCameraController : MonoBehaviour
{
    private GameObject h;
    private float j;

    private void Start()
    {
        this.h = GameObject.Find("unitychan");
        this.j = h.transform.position.z - this.transform.position.z;

        

    }
    private void Update()
    {
        this.transform.position = new Vector3(0, this.transform.position.y, this.h.transform.position.z - j);
    }
}