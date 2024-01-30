using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicplayer : MonoBehaviour
{
    private static musicplayer instance = null;
    public static musicplayer Instance
    {
        get { return instance; }
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
