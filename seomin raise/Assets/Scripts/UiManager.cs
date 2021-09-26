using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Text moneyText;
    [SerializeField]
    private GameObject error = null;
    [SerializeField]
    private Text errorText = null;
    [SerializeField]
    private GameObject upgradePanelTemplate = null;
    [SerializeField]
    private GameObject jobPanelTemplate = null;

    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();
    private List<JobPanel> jobPanelList = new List<JobPanel>();
    void Start()
    {
        UpdateMoneyPanel();
        CreatePanels();
        CreateJobPanels();
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
    public void OnClickImage()
    {
        GameManager.Instance.CurrentUser.money += 1 + GameManager.Instance.CurrentUser.userStr*2 + GameManager.Instance.CurrentUser.userJobc;
        UpdateMoneyPanel();
    }
    public void UpdateMoneyPanel()
    {
        moneyText.text = string.Format("{0} 원", GameManager.Instance.CurrentUser.money);
    }
    public void ErrorLackMoney()
    {
        errorText.text = string.Format("돈이 부족합니다.");
        error.SetActive(true);
        Invoke("SetActiveFalse", 1);
    }
    public void SetActiveFalse()
    {
        error.SetActive(false);
    }

    public void ErrorLackInt()
    {
        errorText.text = string.Format("지능이 부족합니다.");
        error.SetActive(true);
        Invoke("SetActiveFalse", 1);
    }
}
