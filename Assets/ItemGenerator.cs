using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    public GameObject p;
    public GameObject q;
    public GameObject r;
    private int s = -160;
    private int t = 120;
    private float u = 3.4f;




    private void Start()
    {
        for (int i = s; i < t; i += 15)
        {
            int v = Random.Range(1, 11);
            if (v <= 2)
            {
                for (float j = -1; j <= 1; j += .4f)
                {
                    GameObject w = Instantiate(r) as GameObject;
                    w.transform.position = new Vector3(4 * j, w.transform.position.y, i);

                }

            }
            else
            {
                for (int j = -1; j <= 1; j++)
                {
                    int d = Random.Range(1, 11);
                    int e = Random.Range(-5, 6);
                    if (1 <= d && d <= 6)
                    {
                        GameObject f = Instantiate(q) as GameObject;
                        f.transform.position = new Vector3(u * j, f.transform.position.y, i + e);
                    }
                    else if (7 <= d && d <= 9)
                    {
                        GameObject g = Instantiate(p) as GameObject;
                        g.transform.position = new Vector3(u * j, g.transform.position.y, i + e);
                    }
                }
            }
        }
    }
}