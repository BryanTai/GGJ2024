using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rocket : MonoBehaviour
{
    [SerializeField] private float _rocketSpeed;
    [SerializeField] private float _secondsToLive;
    [SerializeField] private Rigidbody2D _rigidBody;

    private float _secondsAlive;

    private void Awake()
    {
        if(_rigidBody == null)
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }
    }

    public void Init(Vector3 rocketDirection)
    {
        _rigidBody.velocity = rocketDirection * _rocketSpeed * -1;
    }

    private void Update()
    {
        _secondsAlive += Time.deltaTime;

        if(_secondsAlive >= _secondsToLive)
        {
            Explode();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //TODO: When rocket hits a platform, explode

        Explode();
    }

    private void Explode()
    {
        Debug.Log("KABOOM!");
        Destroy(this.gameObject);
    }
}
