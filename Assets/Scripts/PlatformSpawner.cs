using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer))]
public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField, Range(0f, 1f)] private float chanceToMove;
    [Space]
    [SerializeField] private float minMoveSpeed = 2;
    [SerializeField] private float maxMoveSpeed = 8;
    [Space]
    [SerializeField] private float minLength = 2;
    [SerializeField] private float maxLength = 8;

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;

        var bounds = sprite.bounds;
        var spawnX = Random.Range(bounds.center.x - bounds.extents.x, bounds.center.x + bounds.extents.x);
        var spawnY = Random.Range(bounds.center.y - bounds.extents.y, bounds.center.y + bounds.extents.y);

        var spawnPostion = new Vector3(spawnX, spawnY, 0);

        var platform = Instantiate(platformPrefab, spawnPostion, Quaternion.identity);

        var mover = platform.GetComponent<PlatformMover>();
        mover.SetSpeed(Random.Range(minMoveSpeed, maxMoveSpeed));

        if(Random.Range(0f, 1f) < chanceToMove)
        {
            mover.isActive = true;
        }

        var scaler = platform.GetComponent<PlatformScaler>();
        scaler.SetScale(Random.Range(minLength, maxLength));

    }
}
