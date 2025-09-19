using TMPro;
using UnityEngine;

public class CornClicker : MonoBehaviour
{
    [Header("Object references")]
    [SerializeField] GameObject popCornObj;
    public float score;
    [Header("Clicking Variables")]
    [SerializeField] private float basePerClick = 1;
    private float cornPerClickFlatModifier = 0;
    private float cornPerClickMultiplier = 1;
    [Header("popcorn spawning")]
    [SerializeField] Vector2 spawnCenter;
    [SerializeField] float spawnRadius;


    private void Start()
    {
        UIManager.instance.CornPerClick((basePerClick + cornPerClickFlatModifier) * cornPerClickMultiplier);
    }

    public void CornClicked()
    {
        score += (basePerClick + cornPerClickFlatModifier) * cornPerClickMultiplier;
        
        SpawnPopcorn();
        SoundManager.instance.PlayPopSound();

        UIManager.instance.UpdateScore(score);

        if (score > 50)
        {
            UIManager.instance.TextColor(Color.yellow);
        }
    }

    private void SpawnPopcorn()
    {
        Quaternion rot = Random.rotation;
        rot.x = 0;
        rot.y = 0;

        Vector2 randomPos = Random.insideUnitCircle * spawnRadius + spawnCenter;

        GameObject spawnedPopCorn = Instantiate(popCornObj, randomPos,rot);
        spawnedPopCorn.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * 5;
        Destroy(spawnedPopCorn, 5f);

    }

    public void ReduceScore(float scoreReduction)
    {
        score -= scoreReduction;
        UIManager.instance.UpdateScore(score);
    }

    public void flatCornUpgradePurchased(float upgradeBonus)
    {
        cornPerClickFlatModifier += upgradeBonus;
        UIManager.instance.CornPerClick((basePerClick + cornPerClickFlatModifier) * cornPerClickMultiplier);

    }
    
}
