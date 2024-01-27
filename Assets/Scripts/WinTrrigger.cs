using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class WinTrrigger : MonoBehaviour
{

    public float MoveToEndTimer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            StartCoroutine(MoveToEndScreen());
    }

    private IEnumerator MoveToEndScreen() 
    { 
        yield return new WaitForSeconds(MoveToEndTimer);
        SceneManager.LoadScene(2);
    }

}
