using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Text moneyText;
    [SerializeField]
    private Text diamondText;
    [SerializeField]
    private GameObject errorPanel = null;
    [SerializeField]
    private Text errorText = null;
    [SerializeField]
    private GameObject upgradePanelTemplate = null;
    [SerializeField]
    private GameObject jobPanelTemplate = null;
    [SerializeField]
    private GameObject shopPanelTemplate = null;

    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();
    private List<JobPanel> jobPanelList = new List<JobPanel>();
    private List<ShopPanel> shopPanelList = new List<ShopPanel>();
    void Start()
    {
        UpdateMoneyPanel();
        CreateUpgradePanels();
        CreateJobPanels();
        CreateShopPanels();
    }
    private void CreateUpgradePanels()
    {
        GameObject newPanel = null;
        UpgradePanel newPanelComponent = null;
        foreach (Stats stats in GameManager.Instance.CurrentUser.statsList)
        {
            newPanel = Instantiate(upgradePanelTemplate, upgradePanelTemplate.transform.parent);
            newPanelComponent = newPanel.GetComponent<UpgradePanel>();
            newPanelComponent.SetValue(stats);
            newPanel.SetActive(true);
            upgradePanelList.Add(newPanelComponent);
        }
    }
    private void CreateJobPanels()
    {
        GameObject newPanel = null;
        JobPanel newPanelComponent = null;
        foreach (Job job in GameManager.Instance.CurrentUser.jobList)
        {
            newPanel = Instantiate(jobPanelTemplate, jobPanelTemplate.transform.parent);
            newPanelComponent = newPanel.GetComponent<JobPanel>();
            newPanelComponent.SetValue(job);
            newPanel.SetActive(true);
            jobPanelList.Add(newPanelComponent);
        }
    }
    private void CreateShopPanels()
    {
        GameObject newPanel = null;
        ShopPanel newPanelComponent = null;
        foreach (Shop shop in GameManager.Instance.CurrentUser.shopList)
        {
            newPanel = Instantiate(shopPanelTemplate, shopPanelTemplate.transform.parent);
            newPanelComponent = newPanel.GetComponent<ShopPanel>();
            newPanelComponent.SetValue(shop);
            newPanel.SetActive(true);
            shopPanelList.Add(newPanelComponent);
        }
    }
    public void OnClickImage()
    {
        int randomDiamond = Random.Range(0, 101);
        if(randomDiamond == 0)
            GameManager.Instance.CurrentUser.diamond++;
        if(GameManager.Instance.itemClickDouble == true)
            GameManager.Instance.CurrentUser.money += (2 + GameManager.Instance.CurrentUser.userStr * 2 + GameManager.Instance.CurrentUser.userJobc)*2;
        else
            GameManager.Instance.CurrentUser.money += 2 + GameManager.Instance.CurrentUser.userStr*2 + GameManager.Instance.CurrentUser.userJobc;
        UpdateMoneyPanel();
    }
    public void UpdateMoneyPanel()
    {
        int moneyLength = (int)(GameManager.Instance.CurrentUser.money / 10000);
        for(int i = 0; i < moneyLength; i++)
        {
            if (GameManager.Instance.CurrentUser.money >= 10000)
            {
                GameManager.Instance.CurrentUser.money2 += 1;
                GameManager.Instance.CurrentUser.money -= 10000;
            }
        }
        if(GameManager.Instance.CurrentUser.money2 >= 1)
        {
            moneyText.text = string.Format("{0} 만원", GameManager.Instance.CurrentUser.money2);
            diamondText.text = string.Format("{0} 개", GameManager.Instance.CurrentUser.diamond);
        }
        else
        {
            moneyText.text = string.Format("{0} 원", GameManager.Instance.CurrentUser.money);
            diamondText.text = string.Format("{0} 개", GameManager.Instance.CurrentUser.diamond);
        }
    }
    public void ErrorLackMoney()
    {
        errorText.text = string.Format("돈이 부족합니다.");
        errorPanel.SetActive(true);
        Invoke("SetActiveFalse", 1);
    }
    public void ErrorLackInt()
    {
        errorText.text = string.Format("지능이 부족합니다.");
        errorPanel.SetActive(true);
        Invoke("SetActiveFalse", 1);
    }
    public void ErrorLackDiamond()
    {
        errorText.text = string.Format("다이아가 부족합니다.");
        errorPanel.SetActive(true);
        Invoke("SetActiveFalse", 1);
    }
    public void ErrorSameJob()
    {
        errorText.text = string.Format("이미 하고있는 직업입니다.");
        errorPanel.SetActive(true);
        Invoke("SetActiveFalse", 1);
    }
    public void SetActiveFalse()
    {
        errorPanel.SetActive(false);
    }
}
