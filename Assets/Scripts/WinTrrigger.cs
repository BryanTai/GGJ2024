using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class WinTrrigger : MonoBehaviour
{

    [SerializeField] private UIController _timerController;

    public float MoveToEndTimer = 3f;

    private void Awake()
    {
        if(_timerController != null)
        {
            _timerController = FindObjectOfType<UIController>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _timerController.StopTheTimer();
            StartCoroutine(MoveToEndScreen());
        }
    }

    private IEnumerator MoveToEndScreen() 
    { 
        yield return new WaitForSeconds(MoveToEndTimer);
        SceneManager.LoadScene(2);
    }

}
