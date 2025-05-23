using System;
using UnityEngine;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] SkillEnum skillEnum;

    [SerializeField] public SkillSTO heandlerSkill;

    [SerializeField] public KeyCode activiteKeykde;


    void Start()
    {
        if (heandlerSkill != null)
        {
            skillEnum = heandlerSkill._skillEnum;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(activiteKeykde))
        {
            Debug.Log($"aktive edilen yetenek : {heandlerSkill.name} \n aktive edilen tus {activiteKeykde}");
        }
    }
}
