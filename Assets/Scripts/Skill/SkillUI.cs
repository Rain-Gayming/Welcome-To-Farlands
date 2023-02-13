using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public int displayLevel;
    public TMP_Text skillNameText;
    public TMP_Text levelText;
    public Button upButton;
    public Button downButton;
    //public Skill skillRelatedTo;
    public string skillName;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SkillManager.instance.skills.Count; i++)
        {
            if(SkillManager.instance.skills[i].name == skillName){
               displayLevel = SkillManager.instance.skills[i].level;
            }                
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < SkillManager.instance.skills.Count; i++)
        {            
            levelText.text = displayLevel.ToString();
            if(displayLevel == SkillManager.instance.skills[i].level){
                downButton.interactable = false;
            }else{
                downButton.interactable = true;
            }

            if(SkillManager.instance.skillPointsLeft == 0){
                upButton.interactable = false;
            }else{
                upButton.interactable = true;
            }
        }
    }
    public void UpSkill()
    {
        displayLevel++;
        SkillManager.instance.skillPointsLeft--;
    }
    public void DownSkill()
    {
        displayLevel--;
        SkillManager.instance.skillPointsLeft++;
    }

    public void AcceptSkills()
    {
        for (int i = 0; i < SkillManager.instance.skills.Count; i++)
        {
            if(SkillManager.instance.skills[i].name == skillName){
                SkillManager.instance.skills[i].level = displayLevel;
            }
        }
    }
}
