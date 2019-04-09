using UnityEngine;
using System.Collections;

public class ItemDestroyer : MonoBehaviour
{
    private GameObject unitychan;
    private float distance;

    private void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        this.distance = unitychan.transform.position.z - this.transform.position.z;



    }
    private void Update()
    {
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - distance);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}