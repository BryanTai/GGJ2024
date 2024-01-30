using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceChanger : MonoBehaviour
{

    public Sprite flyingFace;
    public Sprite groundedFace;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponentInParent<PlayerControls>()._groundTrigger.IsGrounded)
        {
            GetComponent<SpriteRenderer>().sprite = groundedFace;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = flyingFace;
        }
    }
}
