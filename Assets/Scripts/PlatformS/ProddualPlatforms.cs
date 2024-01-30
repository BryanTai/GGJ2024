using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProddualPlatforms : MonoBehaviour
{
    [SerializeField] private float spawnerGap = 1f;
    [SerializeField] private PlatformSpawnerArea[] spawners;

    private readonly float[] ZONE_HEIGHTS = new float[4] { 117.5f, 119.5f, 131.5f, 82.5f };

    // Start is called before the first frame update
    void Awake()
    {
        
        
        Vector3 currentPos = transform.position;

        for (int i = 0; i < spawners.Length; i++)
        {
            float currentHeight = 0;
            float spawnerHeight = spawners[i].Heigth;

            while (currentHeight < ZONE_HEIGHTS[i])
            {

                // offset each zone by its height

                var spawner = Instantiate(spawners[i], currentPos, Quaternion.identity);
                spawner.transform.SetParent(this.transform);

                currentHeight += spawnerHeight + spawnerGap;
                currentPos += Vector3.up * (spawnerHeight + spawnerGap);
            }
            spawnerGap += 0.2f;
        }

        



    }
}
