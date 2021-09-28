using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    private Image statsImage = null;
    [SerializeField]
    private Text statsNameText = null;
    [SerializeField]
    private Text amountText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Sprite[] statsSprite = null;

    private Stats stats = null;

    public void SetValue(Stats stats)
    {
        statsNameText.text = stats.statsName;
        this.stats = stats;
        UpdateValues();
    }
    public void UpdateValues()
    {
        statsImage.sprite = statsSprite[stats.statsNumber];
        statsNameText.text = stats.statsName;
        amountText.text = string.Format("{0}", stats.amount);
        priceText.text = string.Format("{0} ¿ø", stats.price);
    }
    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.money < stats.price)
        {
            GameManager.Instance.UI.ErrorLackMoney();
            return;
        }
        GameManager.Instance.CurrentUser.money -= stats.price;
        stats.amount++;
        stats.price = (long)(stats.price * 1.1f);
        switch (stats.statsNumber)
        {
            case 0:
                GameManager.Instance.CurrentUser.userStr = stats.amount;
                break;
            case 1:
                GameManager.Instance.CurrentUser.userDex = stats.amount;
                break;
            case 2:
                GameManager.Instance.CurrentUser.userInt = stats.amount;
                break;
            default:
                break;
        }
        UpdateValues();
        GameManager.Instance.UI.UpdateMoneyPanel();
    }
}
