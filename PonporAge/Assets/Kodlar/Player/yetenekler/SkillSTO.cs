using UnityEngine;

[CreateAssetMenu(fileName =" Skill",menuName ="Skills/skill")]
public class SkillSTO : ScriptableObject
{
    public string skillName;
    public SkillEnum _skillEnum;
    public Sprite icon;
    public KeyCode activationKey;
    public float cooldown;
    public GameObject skillEffectPrefab;

}
