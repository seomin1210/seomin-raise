using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JobPanel : MonoBehaviour
{
    [SerializeField]
    private Image jobImage = null;
    [SerializeField]
    private Text jobNameText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Text jobNeedInt = null;
    [SerializeField]
    private Sprite[] jobSprite = null;

    private Job job = null;

    public void SetValue(Job job)
    {
        jobNameText.text = job.jobName;
        this.job = job;
        UpdateValues();
    }
    public void UpdateValues()
    {
        jobImage.sprite = jobSprite[job.jobNumber];
        jobNameText.text = job.jobName;
        priceText.text = string.Format("{0} 원", job.price);
        jobNeedInt.text = string.Format("필요지능 {0}", job.needInt);
    }
    public void OnClickJob()
    {
        if (GameManager.Instance.CurrentUser.money < job.price)
        {
            GameManager.Instance.UI.ErrorLackMoney();
            return;
        }
        if (GameManager.Instance.CurrentUser.userInt < job.needInt)
        {
            GameManager.Instance.UI.ErrorLackInt();
            return;
        }
        GameManager.Instance.CurrentUser.money -= job.price;
        GameManager.Instance.CurrentUser.userJobc = job.mPc;
        GameManager.Instance.CurrentUser.userJobs = job.mPs;
        GameManager.Instance.UI.UpdateMoneyPanel();
    }
}
