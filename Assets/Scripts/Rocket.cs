using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rocket : MonoBehaviour
{

    [SerializeField] private float _rocketSpeed = 200f;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _secondsToLive = 3f;

    private Vector3 _endPosition;
    private Vector3 _startPosition;
    private float _secondsAlive;

    private void Awake()
    {
        if(_rigidBody == null)
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        _startPosition = this.transform.position;
        _endPosition = _startPosition + this.transform.eulerAngles * _rocketSpeed;

    }

    private void Update()
    {
        _secondsAlive += Time.deltaTime;

        this.transform.position = Vector3.Lerp(_startPosition, _endPosition, Time.deltaTime);

        if(_secondsAlive >= _secondsToLive)
        {
            Explode();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //TODO: When rocket hits a platform, explode

    }

    private void Explode()
    {
        Debug.Log("KABOOM!");
        Destroy(this.gameObject);
    }
}
