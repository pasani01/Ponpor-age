using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class SkillSlotList : MonoBehaviour
{
    [SerializeField] public List<SkillSlot> skillSlots = new List<SkillSlot>();
    [SerializeField] public bool isSlotsEmpty;

    public SkillSTO skillSTO;


    void Update()
    {
        isSlotsEmpty = skillSlots.Any(slot => slot.heandlerSkill == null);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetSkill(skillSTO);
        }
    }



    public void GetSkill(SkillSTO skill)
    {
        foreach (var item in skillSlots)
        {
            if (item.heandlerSkill == null)
            {
                item.heandlerSkill = skill;
                break;
            }

        }
    }

}
