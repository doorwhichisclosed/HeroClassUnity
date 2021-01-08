using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonInfo : MonoBehaviour
{
    public bool isMain;
    public bool isSub;
    public bool isNew;
    public bool isHardcore;
    public bool canEnter;

    public GameObject newImage;
    public GameObject hardCoreImage;

    public void UpdateDungeonInfo()
    {
        if (isNew)
            newImage.SetActive(true);
        else if(!isNew)
            newImage.SetActive(false);
        if (isHardcore)
            hardCoreImage.SetActive(true);
        else if (!isHardcore)
            hardCoreImage.SetActive(false);
        if (canEnter)
            GetComponent<Button>().interactable = true;
        else
            GetComponent<Button>().interactable = false;
    }
}
