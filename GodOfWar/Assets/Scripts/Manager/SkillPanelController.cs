﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelController: MonoBehaviour
{
    public GameObject panel;
    public List<Button> skillButtons; 
    private List<int> selectedSkillsIndexes = new List<int>();

    public void ActivateSkillPanel()
    {
        foreach (Button button in skillButtons)
        {
            button.enabled = true;
        }
        panel.SetActive(true);
        selectedSkillsIndexes.Clear();
        SelectRandomSkills();
    }

    public void SelectRandomSkills()
    {
        Debug.Log("skill: " + selectedSkillsIndexes.Count);
        
        // random skill
        while (selectedSkillsIndexes.Count < 3)
        {
            int randomIndex = Random.Range(0, skillButtons.Count);
            if (!selectedSkillsIndexes.Contains(randomIndex))
            {
                selectedSkillsIndexes.Add(randomIndex);
            }
        }

        for(int i = 0; i < 3; i++)
        {
            skillButtons[i].gameObject.SetActive(true);
            Debug.Log("random");
        }
        
    }

    public void CloseSkillPanel()
    {
        foreach(Button button in skillButtons)
        {
            button.enabled = false;
        }
        // Gọi hàm này khi nhân vật đã chọn xong kỹ năng
        panel.SetActive(false);
    }

    
}
