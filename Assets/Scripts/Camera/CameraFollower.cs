using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float YOffset = 6;
    private Camera _camera;
    public Transform _playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;

        if(_playerTransform == null)
        {
            GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var playerY = _playerTransform.position.y;
        var camPos = new Vector3(_camera.transform.position.x, playerY + YOffset, -1);
        _camera.transform.position = camPos;
    }
}
