using UnityEngine;

public class ClickUpgrade : Upgrade
{
    public override void OnPurchase()
    {
        if (player.score >= cost)
        {
            player.ReduceScore(cost);
            upgradeLevel++;
            IncreasePrice();
            UIManager.Instance.SetButtonText(shopText, upgradeName, description, cost, upgradeLevel);
            player.flatCornUpgradePurchased(amountIncrease);
        }
    }
}
