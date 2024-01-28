using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disctanceClamp : MonoBehaviour
{

    // Update is called once per frame
    public Transform centerPt;

    void Update()
    {
        this.transform.position = centerPt.position;
    }
}
