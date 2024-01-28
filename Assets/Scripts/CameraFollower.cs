using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float YOffset = 6;
    private Camera _camera;
    private Transform _playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        _camera.transform.position = _playerTransform.position + (Vector3.up * YOffset);
    }
}
