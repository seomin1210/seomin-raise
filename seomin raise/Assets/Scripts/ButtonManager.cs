using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject work = null;
    [SerializeField]
    private GameObject setting = null;
    [SerializeField]
    private GameObject shop = null;
    [SerializeField]
    private GameObject help = null;
    public void OnClickOpenWorkList()
    {
        GameManager.Instance.bOther = true;
        work.SetActive(true);
    }
    public void OnClickCloseWorkList()
    {
        GameManager.Instance.bOther = false;
        work.SetActive(false);
    }
    public void OnClickOpenShopList()
    {
        GameManager.Instance.bOther = true;
        shop.SetActive(true);
    }
    public void OnClickCloseShopList()
    {
        GameManager.Instance.bOther = false;
        shop.SetActive(false);
    }
    public void OnClickOpenHelpPanel()
    {
        GameManager.Instance.bOther = true;
        GameManager.Instance.bEsc = false;
        setting.SetActive(false);
        help.SetActive(true);
    }
    public void OnClickCloseHelpPanel()
    {
        GameManager.Instance.bOther = false;
        help.SetActive(false);
    }
    public void OpenSettingPanel()
    {
        setting.SetActive(true);
    }
    public void OnClickCloseSettingPanel()
    {
        setting.SetActive(false);
    }
    public void OnClickEscapeButton()
    {
        Application.Quit();
    }
}
