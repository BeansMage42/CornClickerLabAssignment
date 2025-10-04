using UnityEngine;

public abstract class ICornSpawner : MonoBehaviour
{
    [SerializeField] protected GameObject cornToSpawn;
    protected bool isActive = true;
    public abstract void Spawn();
    public void SetSpawnerActive(bool active)
    {

        isActive = active;
        PopCornMaker.Instance.StartSpawning(this);
    }
}
