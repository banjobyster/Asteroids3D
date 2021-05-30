using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrayMode : MonoBehaviour
{
    public GameObject volume;
    public GameObject xray;
    int x = 1;
    float time1 = 1000;
    float time2 = 0;

    private void Start()
    {
        volume.SetActive(true);
        xray.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //print(x);
        if (Input.GetKeyDown(KeyCode.X) && x==1 && time1>100)
        {
            time1 = 0;
            volume.SetActive(false);
            xray.SetActive(true);
            x = 0;
        }else if (time2>600)
        {
            time2 = 0;
            volume.SetActive(true);
            xray.SetActive(false);
            x = 1;
        }

        if (x == 1)
        {
            time1 += 0.1f;
        }
        if (x == 0)
        {
            time2 += 0.1f;
        }

    }
}
