using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField] protected string upgradeName;
    [SerializeField] protected string description;
    [SerializeField] protected float baseCost;
    [SerializeField] protected float costIncreaseMod;
    [SerializeField] protected float amountIncrease;
    protected int upgradeLevel = 0;
    protected float cost;
    [SerializeField] protected TextMeshProUGUI shopText;
    [SerializeField] protected Button shopButton;
    [SerializeField] protected ICornSpawner spawner;

    protected CornClicker player;

    private void Start()
    {
        cost = baseCost;
        UIManager.Instance.SetButtonText(shopText, upgradeName, description, cost, upgradeLevel);
        player = FindAnyObjectByType<CornClicker>();
    }
    public abstract void OnPurchase();
    protected void IncreasePrice()
    {
        cost = Mathf.Ceil( baseCost * (costIncreaseMod * Mathf.Exp(upgradeLevel)));
        
    }
    
}
