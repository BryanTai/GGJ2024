using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rocket : MonoBehaviour
{
    [SerializeField] private float _rocketSpeed;
    [SerializeField] private float _secondsToLive;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionPower;
    [SerializeField] private Rigidbody2D _rigidBody;

    private float _secondsAlive;

    private void Awake()
    {
        if(_rigidBody == null)
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }
    }

    public void LaunchRocket(Vector3 rocketDirection)
    {
        Vector2 rocketForceVector = rocketDirection * _rocketSpeed * -1;
        _rigidBody.AddForce(rocketForceVector);
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
        Explode();
    }

    private void Explode()
    {
        Vector3 explosionPosition = this.transform.position;
        Collider2D buntCollider = Physics2D.OverlapCircle(explosionPosition, _explosionRadius, LayerMask.GetMask("Bunt"));

        if(buntCollider != null && buntCollider.TryGetComponent<Rigidbody2D>(out Rigidbody2D buntRigidbody))
        {
            buntRigidbody.AddExplosionForce(_explosionPower, explosionPosition, _explosionRadius);
        }

        Destroy(this.gameObject);
    }
}
