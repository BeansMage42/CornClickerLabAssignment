
using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class PopCornMaker : SingletonPersistant<PopCornMaker>
{
   

    public float cornSpawnDelay;
    private float timer;
    private List<ICornSpawner> cornToSpawn = new List<ICornSpawner>();
    [SerializeField] private ICornSpawner normalCorn;

    private void Start()
    {
        GameManager.Instance.cornClicker.OnClickAction += ClickPopCornSpawn;

    }
    private void Update()
    {
        if (cornToSpawn.Count > 0)
        {
            if (timer < cornSpawnDelay)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                SpawnCorns();
            }
        }
    }
    private void SpawnCorns()
    {
        foreach (var corn in cornToSpawn)
        {
            corn.Spawn();
        }
    }
    public void StartSpawning(ICornSpawner spawner)
    {
       cornToSpawn.Add(spawner);
    }
   
    public void CPSUpdate(float CPS)
    {
        cornSpawnDelay = 0.5f/CPS;
    }
    
    public void ClickPopCornSpawn(float corn)
    {
        normalCorn.Spawn();
    }
}
