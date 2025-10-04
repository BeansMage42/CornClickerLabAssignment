using UnityEngine;

public class NormalPopcornSpawner : ICornSpawner
{

    [Header("popcorn spawning")]
    [SerializeField] Vector2 spawnCenter;
    [SerializeField] float spawnRadius;
    public override void Spawn()
    {

        Quaternion rot = Random.rotation;
        rot.x = 0;
        rot.y = 0;

        Vector2 randomPos = Random.insideUnitCircle * spawnRadius + spawnCenter;

        GameObject spawnedPopCorn = Instantiate(cornToSpawn, randomPos, rot);
        spawnedPopCorn.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * 5;
        Destroy(spawnedPopCorn, 5f);
    }
}
