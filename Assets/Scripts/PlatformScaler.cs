using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScaler : MonoBehaviour
{
    //min size
    [SerializeField] private float minLength = 2f;
    [SerializeField] private float maxLength = 8f;
    //max size
    //these are lengths

    // Start is called before the first frame update
    void Start()
    {


    }

  public void SetScale(float length)
    {
        var scale = new Vector2(length, transform.localScale.y);
        transform.localScale = scale;
    }
}
