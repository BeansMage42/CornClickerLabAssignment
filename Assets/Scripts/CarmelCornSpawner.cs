using UnityEngine;

public class CarmelCornSpawner : ICornSpawner
{
    public override void Spawn()
    {
        if (isActive)
        {
            Vector2 randomPos = Random.insideUnitCircle * 5 + Vector2.zero;
            randomPos.y = 5f;
            Destroy(Instantiate(cornToSpawn, randomPos, Quaternion.identity), 5f);
        }
    }
    /*public override void SetSpawnerActive(bool active)
    {
        isActive = active;
        PopCornMaker.Instance.StartSpawning(this);
    }*/
}
