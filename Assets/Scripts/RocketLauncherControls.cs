using UnityEngine;

public class RocketLauncherControls : MonoBehaviour
{
    [SerializeField] private GameObject _rocketPrefab;
    private Camera _camera;
    
    private void Awake()
    {
        _camera = Camera.main;

        if(_rocketPrefab == null)
        {
            Debug.LogError("ROCKET PREFAB IS MISSING!");
        }
    }

    private void Update()
    {
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 perpendicular = transform.position - mousePos;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);

        if(Input.GetButtonDown("Fire1"))
        {
            LaunchRocket();
        }
    }

    private void LaunchRocket()
    {
        GameObject newRocketGO = Instantiate(_rocketPrefab, this.transform.position, this.transform.rotation);
        if(newRocketGO.TryGetComponent<Rocket>(out var newRocket))
        {
            newRocket.Init(this.transform.up);
        }
        else
        {
            Debug.LogError("MISSING ROCKET COMPONENT");
        }
    }
}
