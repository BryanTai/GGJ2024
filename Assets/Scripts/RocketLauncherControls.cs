using UnityEngine;

public class RocketLauncherControls : MonoBehaviour
{
    private const int TOTAL_ROCKET_AMMO = 1;

    [SerializeField] private GameObject _rocketPrefab;
    [SerializeField] private GroundTrigger _groundTrigger;
    [SerializeField] private UIController _uiController;
    private Camera _camera;
    public GameObject rocketlauncherNozzle;

    private int _ammoCount;
    
    private void Awake()
    {
        _camera = Camera.main;

        if(_rocketPrefab == null)
        {
            Debug.LogError("ROCKET PREFAB IS MISSING!");
        }

        if(_groundTrigger == null)
        {
            _groundTrigger = this.transform.parent.gameObject.GetComponentInChildren<GroundTrigger>();
        }
        
        if(_uiController == null)
        {
            _uiController = FindObjectOfType<UIController>();
        }

        ReloadRockets();
    }

    private void Update()
    {
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 perpendicular = transform.position - mousePos;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);
        transform.Rotate(new Vector3(0, 0, -90));

        if(Input.GetButtonDown("Fire1"))
        {
            if(_ammoCount <= 0)
            {
                DisplayEmptyRocketsWarning();
            }
            else
            {
                LaunchRocket();
            }
        }

        if(_groundTrigger.IsGrounded)
        {
            ReloadRockets();
        }
    }


    private void LaunchRocket()
    {
        GameObject newRocketGO = Instantiate(_rocketPrefab, rocketlauncherNozzle.transform.position, rocketlauncherNozzle.transform.rotation);
        if(newRocketGO.TryGetComponent<Rocket>(out var newRocket))
        {
            newRocket.LaunchRocket(rocketlauncherNozzle.transform.up);
            _ammoCount--;
            _uiController.SetRocketAmmo(_ammoCount);
        }
        else
        {
            Debug.LogError("MISSING ROCKET COMPONENT");
        }
    }

    private void ReloadRockets()
    {
        _ammoCount = TOTAL_ROCKET_AMMO;
        _uiController.SetRocketAmmo(_ammoCount);
    }

    private void DisplayEmptyRocketsWarning()
    {
        Debug.Log("Out of rockets!");
    }
}
