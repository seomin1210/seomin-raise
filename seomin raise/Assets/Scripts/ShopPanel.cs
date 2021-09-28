using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField]
    private Image itemImage = null;
    [SerializeField]
    private Text itemNameText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Sprite[] itemSprite = null;

    private Shop shop = null;

    public void SetValue(Shop shop)
    {
        itemNameText.text = shop.itemName;
        this.shop = shop;
        UpdateValues();
    }
    public void UpdateValues()
    {
        itemImage.sprite = itemSprite[shop.itemNumber];
        itemNameText.text = shop.itemName;
        priceText.text = string.Format("{0} °³", shop.price);
    }
    public void OnClickItem()
    {
        if (GameManager.Instance.CurrentUser.diamond < shop.price)
        {
            GameManager.Instance.UI.ErrorLackDiamond();
            return;
        }
        GameManager.Instance.CurrentUser.diamond -= shop.price;
        switch (shop.itemNumber)
        {
            case 0:
                GameManager.Instance.itemClickDouble = true;
                break;
            case 1:
                GameManager.Instance.itemSecondDouble = true;
                break;
            default:
                break;
        }
        GameManager.Instance.UI.UpdateMoneyPanel();
    }
}
