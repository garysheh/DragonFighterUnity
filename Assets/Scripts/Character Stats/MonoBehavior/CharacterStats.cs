using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public CharacterData_SO characterStats;
    public AttackData_SO attackData;
    public SkillData_SO skillData;

    [HideInInspector]
    public bool isCrit = false;

    #region from Stats_SO
    public int MaxHealth {
        get
        {
            if (characterStats != null)
            {
                return characterStats.maxHealth;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            characterStats.maxHealth = value;
        }
    }

    public int CurrentHealth
    {
        get
        {
            if (characterStats != null)
            {
                return characterStats.currentHealth;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            characterStats.currentHealth = value;
        }
    }

    public int MaxMana
    {
        get
        {
            if (characterStats != null)
            {
                return characterStats.maxMana;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            characterStats.maxMana = value;
        }
    }

    public int CurrentMana
    {
        get
        {
            if (characterStats != null)
            {
                return characterStats.currentMana;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            characterStats.currentMana = value;
        }
    }

    public int baseDefence
    {
        get
        {
            if (characterStats != null)
            {
                return characterStats.baseDefence;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            characterStats.maxHealth = value;
        }
    }

    public int CurrentDefence
    {
        get
        {
            if (characterStats != null)
            {
                return characterStats.currentDefence;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            characterStats.currentDefence = value;
        }
    }
    #endregion

    #region from Attack_SO
    public float AttackRange
    {
        get
        {
            if (attackData != null)
            {
                return attackData.attackRange;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            attackData.attackRange = value;
        }
    }

    public float AttackCD
    {
        get
        {
            if (attackData != null)
            {
                return attackData.attackCD;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            attackData.attackCD = value;
        }
    }

    public int MinDamage
    {
        get
        {
            if (attackData != null)
            {
                return attackData.minDamage;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            attackData.minDamage = value;
        }
    }

    public int MaxDamage
    {
        get
        {
            if (attackData != null)
            {
                return attackData.maxDamage;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            attackData.maxDamage = value;
        }
    }

    public float CritMultiplier
    {
        get
        {
            if (attackData != null)
            {
                return attackData.critMultiplier;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            attackData.critMultiplier = value;
        }
    }

    public float CriticalChance
    {
        get
        {
            if (attackData != null)
            {
                return attackData.critChance;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            attackData.critChance = value;
        }
    }
    #endregion

    #region from Skill_SO
    public string[] SkillName
    {
        get
        {
            if (skillData != null)
            {
                return skillData.skillName;
            }
            else
            {
                return null;
            }
        }
        set
        {
                skillData.skillName = value;
        }
    }

    public int[] ManaCost
    {
        get
        {
            if (skillData != null)
            {
                return skillData.manaCost;
            }
            else
            {
                return null;
            }
        }
        set
        {
            skillData.manaCost = value;
        }
    }

    public int[] SkillDamage
    {
        get
        {
            if (skillData != null)
            {
                return skillData.skillDamage;
            }
            else
            {
                return null;
            }
        }
        set
        {
            skillData.skillDamage = value;
        }
    }

    public int[] SkillCD
    {
        get
        {
            if (skillData != null)
            {
                return skillData.skillCD;
            }
            else
            {
                return null;
            }
        }
        set
        {
            skillData.skillCD = value;
        }
    }

    public float[] SkillRange
    {
        get
        {
            if (skillData != null)
            {
                return skillData.skillRange;
            }
            else
            {
                return null;
            }
        }
        set
        {
            skillData.skillRange = value;
        }
    }
    #endregion

    #region combat related
    public void takeDamage(CharacterStats attacker, CharacterStats defender)
    {
        //  default damge is 1
        int damage = Mathf.Max((attacker.damageCalc() - defender.CurrentDefence), 1);
        CurrentHealth = Mathf.Max((CurrentHealth - damage), 0);

        //  TODO: UI update
        //  TODO: leveling
    }

    public int damageCalc()
    {
        float damage = Random.Range(attackData.minDamage, attackData.maxDamage);
        return isCrit ? (int)(damage * attackData.critMultiplier) : (int)damage;
    }
    #endregion

}
