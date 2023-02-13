using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    SkillData skillData = new SkillData();
    public string saveFile;

    public List<Skill> skills;

    public List<SkillUI> skillDisplays;
    public GameObject skillGrid;

    public int skillPointsLeft;
    public TMP_Text skillPointsText;

    private void Awake() {
        instance = this;
        saveFile = Application.persistentDataPath + "/Skills.json";
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < skillGrid.GetComponentsInChildren<SkillUI>().Length; i++)
        {
            skillDisplays.Add(skillGrid.GetComponentsInChildren<SkillUI>()[i]);
        }
        LoadSkills();
    }

    // Update is called once per frame
    void Update()
    {
        skillPointsText.text = "Skill Points Remaining: " + skillPointsLeft.ToString();
    }

    public void AcceptSkills()
    {
        for (int i = 0; i < skillDisplays.Count; i++)
        {
            skillDisplays[i].AcceptSkills();
        }
        SaveSkills();
    }

        
    public void SaveSkills()
    {        
        skillData.skills = skills;

        string jsonString = JsonUtility.ToJson(skillData);
        File.WriteAllText(saveFile, jsonString);
    }

    public void LoadSkills()
    {
        if (File.Exists(saveFile))
        {
            string fileContents = File.ReadAllText(saveFile);

            skillData = JsonUtility.FromJson<SkillData>(fileContents);
            skills = skillData.skills;
        }else{
            Debug.Log("File not found");
        }
    }
}

[System.Serializable]
public class Skill
{
    public string name;
    public int level;
}

[System.Serializable]
public class SkillData
{
    public List<Skill> skills;
}