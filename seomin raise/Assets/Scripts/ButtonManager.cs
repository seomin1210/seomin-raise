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
