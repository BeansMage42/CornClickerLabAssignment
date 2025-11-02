using System;
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
    private float cornPerSecond = 0;
    private float cornPerSecondMult = 1;
    public Action<float> OnClickAction;



    private void Start()
    {
        UIManager.Instance.CornPerClick((basePerClick + cornPerClickFlatModifier) * cornPerClickMultiplier);
    }

    public void CornClicked()
    {
        score += (basePerClick + cornPerClickFlatModifier) * cornPerClickMultiplier;
        
        

       OnClickAction?.Invoke(score);

        if (score > 50)
        {
            UIManager.Instance.TextColor(Color.yellow);
        }
    }

    private void Update()
    {
        score += (cornPerSecond * cornPerSecondMult) * Time.deltaTime;
        UIManager.Instance.UpdateScore(score);
    }
    

    public void ReduceScore(float scoreReduction)
    {
        score -= scoreReduction;
        UIManager.Instance.UpdateScore(score);
    }

    public void flatCornUpgradePurchased(float upgradeBonus)
    {
        cornPerClickFlatModifier += upgradeBonus;
        UIManager.Instance.CornPerClick((basePerClick + cornPerClickFlatModifier) * cornPerClickMultiplier);

    }
    public void CornPerSecondUpgrade(float upgradeBonus)
    {
        cornPerSecond += upgradeBonus;
        PopCornMaker.Instance.CPSUpdate(cornPerSecond);
        UIManager.Instance.CornPerSecond((cornPerSecond * cornPerSecondMult));
    
    }
    
}
