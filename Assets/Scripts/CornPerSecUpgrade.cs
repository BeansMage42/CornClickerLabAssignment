using UnityEngine;

public class CornPerSecUpgrade : Upgrade
{
    public override void OnPurchase()
    {

        if (player.score >= cost)
        {
            if (upgradeLevel == 0) spawner.SetSpawnerActive(true);
            player.ReduceScore(cost);
            upgradeLevel++;
            IncreasePrice();
            UIManager.Instance.SetButtonText(shopText, upgradeName, description, cost, upgradeLevel);
            player.CornPerSecondUpgrade(amountIncrease);
        }
    }
}
