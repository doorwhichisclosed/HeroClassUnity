using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class QuestPageInteraction : MonoBehaviour
{
    public Slider questSlider;
    public Button compensationReceiveButton;
    public GameObject contents;
  
    public void PlusSlider()
    {
        questSlider.value++;
        if (questSlider.value == questSlider.maxValue)
            compensationReceiveButton.interactable = true;
    }

    public void OnClick_compensation()
    {
        compensationReceiveButton.interactable = false;
        //보상 주는 함수
    }

    public void OnClick_Background()
    {
        for (int i = 0; i < contents.transform.childCount; i++)
        {
            contents.transform.GetChild(i).GetComponent<Quest>().FoldQuest();
        }
    }
}
