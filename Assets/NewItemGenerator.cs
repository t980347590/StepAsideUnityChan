using UnityEngine;
using System.Collections;

public class NewItemGenerator : MonoBehaviour
{
    public GameObject car;
    public GameObject coin;
    public GameObject cone;
    private float posRange = 3.4f;


    //unitychanを入れる
    public GameObject unitychan;
    //unitychanのｚ座標
    public float uniz;


    //アイテム生成用タイマー
    public float ItemTime;

    //アイテム生成時間間隔
    public float ItemInterval = 1;






    private void Start()
    {
        //


        unitychan = GameObject.Find("unitychan");


    }


    private void Update()
    {

        //
        //  Debug.Log(d);


        //ゴールの向こうにアイテム生成しないように防止
        uniz = unitychan.transform.position.z;
        if (uniz < 70)
        {
            //時間的間隔を1空けてアイテム生成

            ItemTime += Time.deltaTime;

            if (ItemTime > ItemInterval)
            {
                ItemTime = 0;

                int e = Random.Range(1, 11);

                if (e <= 2)
                {
                    ConeGenerator();
                }
                else
                {
                    CoinandCarGenerator();
                }


            }
            ItemInterval = 1;

        }

    }


    void ConeGenerator()
    {

        GameObject obj = (GameObject)Resources.Load("TrafficConePrefab");

        //unitychanの目前５０あたりにアイテム生成
        uniz = unitychan.transform.position.z;
        float putconeZ = uniz + 50;


        //アイテム設置の位置のばらつきをつくる
        float ofs = Random.Range(-5, 6);

        for (float j = -1; j <= 1; j += .4f)
        {

            Vector3 pos = new Vector3(j * 4,
                  obj.transform.position.y,
                  putconeZ + ofs);
            Instantiate(obj, pos, Quaternion.identity);

        }
    }

    void CoinandCarGenerator()
    {
        //unitychanの目前５０あたりにアイテム生成
        uniz = unitychan.transform.position.z;
        float putitemZ = uniz + 50;


        for (int j = -1; j <= 1; j++)
        {
            int item = Random.Range(1, 11);
            int offsetZ = Random.Range(-10, 11);
            if (1 <= item && item <= 6)
            {
                GameObject coinobject = Instantiate(coin) as GameObject;
                coinobject.transform.position = new Vector3(posRange * j, coinobject.transform.position.y, putitemZ + offsetZ);
            }
            else if (7 <= item && item <= 9)
            {
                GameObject carobject = Instantiate(car) as GameObject;
                carobject.transform.position = new Vector3(posRange * j, carobject.transform.position.y, putitemZ + offsetZ);
            }
        }

    }
}