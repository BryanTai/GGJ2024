using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer))]
public class PlatformSpawnerArea : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;

    [SerializeField] private SpriteRenderer sprite;

    public float Heigth
    {
        get { return sprite.bounds.size.y; }
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;

        var bounds = sprite.bounds;
        var spawnX = Random.Range(bounds.center.x - bounds.extents.x, bounds.center.x + bounds.extents.x);
        var spawnY = Random.Range(bounds.center.y - bounds.extents.y, bounds.center.y + bounds.extents.y);

        var spawnPostion = new Vector3(spawnX, spawnY, 0);

        var index = Random.Range(0, platformPrefabs.Length);

        Instantiate(platformPrefabs[index], spawnPostion, Quaternion.identity).transform.SetParent(this.transform);
        


        //var scaler = platform.GetComponent<PlatformScaler>();
        //scaler.SetScale(Random.Range(minLength, maxLength));

    }
}
