using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject WorkScroll = null;
    [SerializeField]
    private GameObject BackWorkCloseButton = null;
    public void OnClickOpenWorkList()
    {
        BackWorkCloseButton.SetActive(true);
        WorkScroll.SetActive(true);
    }
    public void OnClickCloseWorkList()
    {
        BackWorkCloseButton.SetActive(false);
        WorkScroll.SetActive(false);
    }

    
}
