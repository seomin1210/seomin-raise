using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Text moneyText;
    [SerializeField]
    private GameObject upgradePanelTemplate = null;

    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();
    void Start()
    {
        UpdateMoneyPanel();
        CreatePanels();
    }
    private void CreatePanels()
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
    public void OnClickImage()
    {
        GameManager.Instance.CurrentUser.money++;
        UpdateMoneyPanel();
    }
    public void UpdateMoneyPanel()
    {
        moneyText.text = string.Format("{0} ¿ø", GameManager.Instance.CurrentUser.money);
    }
}
