using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetposition : MonoBehaviour
{
    public Transform body;
    public Transform leftfoot;
    public Transform rightfoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            print("reset pos");
            body.SetLocalPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            //transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //body.rotation = Quaternion.Euler(new Vector3(0, 0, 90));

            //print(leftfoot.rotation);
            //leftfoot.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //print(leftfoot.rotation);
            //leftfoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //rightfoot.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            
            //rightfoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            
            
            
        }
    }
}
