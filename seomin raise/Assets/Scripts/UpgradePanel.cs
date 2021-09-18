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
    private Button purchaseButton = null;
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
        priceText.text = string.Format("{0} ¾Ö³ÊÁö", stats.price);
    }
    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.money < stats.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.money -= stats.price;
        stats.amount++;
        stats.price = (long)(stats.price * 1.25f);
        UpdateValues();
        GameManager.Instance.UI.UpdateMoneyPanel();
    }
}
