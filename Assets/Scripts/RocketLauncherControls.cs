using UnityEngine;

public class RocketLauncherControls : MonoBehaviour
{
    private Camera _camera;
    
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 perpendicular = transform.position - mousePos;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);
    }
}
