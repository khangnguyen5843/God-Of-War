using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelController: MonoBehaviour
{
    public GameObject panel;
    public List<Button> skillButtons; 
    private List<int> selectedSkillsIndexes = new List<int>();

    private void Start()
    {
        foreach (Button button in skillButtons)
        {
            button.enabled = false;
        }
        panel.SetActive(false);
    }

    public void ActivateSkillPanel()
    {
        Debug.Log("Test error");
        // popup panel skill
        panel.SetActive(true);
        selectedSkillsIndexes.Clear();
        SelectRandomSkills();
    }

    public void SelectRandomSkills()
    {
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
