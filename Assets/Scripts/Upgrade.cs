using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] string upgradeName;
    [SerializeField] string description;
    [SerializeField] float baseCost;
    [SerializeField] float costIncreaseMod;
    [SerializeField] float addedCornPerClick;
    int upgradeLevel = 1;
    float cost;
    [SerializeField] TextMeshProUGUI shopText;
    [SerializeField] Button shopButton;

    CornClicker player;

    private void Start()
    {
        cost = baseCost;
        UIManager.instance.SetButtonText(shopText, upgradeName, description, cost, upgradeLevel);
        player = FindAnyObjectByType<CornClicker>();
    }
    public void OnPurchase()
    {
        if (player.score >= cost)
        {
            player.ReduceScore(cost);
            upgradeLevel++;
            IncreasePrice();
            UIManager.instance.SetButtonText(shopText, upgradeName, description, cost, upgradeLevel);
            player.flatCornUpgradePurchased(addedCornPerClick);
        }
    }
    private void IncreasePrice()
    {
        cost = Mathf.Ceil( baseCost + (upgradeLevel * Mathf.Exp(2) * costIncreaseMod));
        
    }
    
}
