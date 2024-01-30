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
        body.rotation = Quaternion.Lerp(body.rotation, Quaternion.Euler(new Vector3(0, 0, 90)), Time.deltaTime);
        leftfoot.rotation = Quaternion.Lerp(body.rotation, Quaternion.Euler(new Vector3(0, 0, 180)), Time.deltaTime);

        rightfoot.rotation = Quaternion.Lerp(body.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), Time.deltaTime);  
        if (Input.GetKeyDown(KeyCode.R))
        {
            //transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //transform.position = new Vector3(0, 0, 0);

            body.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            body.position = new Vector3(0, 0, 0);

            leftfoot.rotation = Quaternion.Euler(new Vector3(0, 0, 180));

            rightfoot.rotation = Quaternion.Euler(new Vector3(0, 0, 0));




            //print(leftfoot.rotation);
            //
            //print(leftfoot.rotation);
            //leftfoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //

            //rightfoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //Time.timeScale = 0;


        }
    }
}
