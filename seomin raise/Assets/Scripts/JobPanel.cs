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
    private bool bMoney = false;
    private bool bFor = false;

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
        if (GameManager.Instance.CurrentUser.userJob == job.jobName)
        {
            GameManager.Instance.UI.ErrorSameJob();
            return;
        }
        if (bFor)
            return;
        if (GameManager.Instance.CurrentUser.money < job.price)
        {
            if (GameManager.Instance.CurrentUser.money2 > 0)
            {
                long money2Leg = GameManager.Instance.CurrentUser.money2;
                bFor = true;
                for (int i = 0; i < money2Leg; i++)
                {
                    GameManager.Instance.CurrentUser.money2--;
                    GameManager.Instance.CurrentUser.money += 10000;
                    if (GameManager.Instance.CurrentUser.money > job.price)
                    {
                        bMoney = true;
                        break;
                    }
                }
                if (!bMoney)
                {
                    GameManager.Instance.UI.ErrorLackMoney();
                    GameManager.Instance.UI.UpdateMoneyPanel();
                    bFor = false;
                    return;
                }
            }
            else
            {
                GameManager.Instance.UI.ErrorLackMoney();
                bFor = false;
                return;
            }
        }
        if (GameManager.Instance.CurrentUser.userInt < job.needInt)
        {
            GameManager.Instance.UI.ErrorLackInt();
            bFor = false;
            bMoney = false;
            return;
        }
        GameManager.Instance.CurrentUser.money -= job.price;
        GameManager.Instance.CurrentUser.userJob = job.jobName;
        GameManager.Instance.CurrentUser.userJobc = job.mPc;
        GameManager.Instance.CurrentUser.userJobs = job.mPs;
        GameManager.Instance.UI.UpdateMoneyPanel();
        bMoney = false;
        bFor = false;
    }
}
