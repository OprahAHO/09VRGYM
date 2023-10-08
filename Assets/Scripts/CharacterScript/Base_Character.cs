using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Base_Character : MonoBehaviour
{
    [Header("Base_Property")]
    
    public float tauntValue = 1;

    public float tauntAddValue = 2;
    public float tauntlimitValue = 16;

    public float healthlimitValue = 0;
    public float healthValue = 10;
    public float attackValue = 3;

    public bool isDirtLoving = false;
    public bool isAttacked = false;
    public bool isGetHit = false;
    public bool inAttackRange = false;

    protected Dictionary<string, float> tauntValues = new Dictionary<string, float>();

    private void Start()
    {
        tauntValues.Add("Enemy", 1f);
        tauntValues.Add("T", 1f);
    }
    public void IncreaseTaunt(string attackerName, float tauntAValue)
    {
        if (!tauntValues.ContainsKey(attackerName))
        {
            tauntValues.Add(attackerName, tauntAValue);
            Debug.Log("Here is AddTauntAValue");
        }
        else
        {
            tauntValues[attackerName] += tauntAValue;
            Debug.Log(tauntValues[attackerName]);
        }
    }

    public void TauntAdd(float amount)
    {
        tauntValue += amount;
    }
    public void HealthAdd(float amount)
    {
        healthValue += amount;
    }

    

    protected virtual void Update()
    {
        TauntValueCheckMachine();
        HealthValueCheckMachine();
        
    }
    public string TauntValueCheckMachine()
    {
        /*if(tauntValue >= tauntlimitValue)
        {
            Attack();
        }*/
        var query = tauntValues
            .Where(pair => pair.Value > tauntlimitValue)
            .OrderByDescending(pair => pair.Value);
        var result = query.FirstOrDefault();

        if (result.Key != null)
        {
            return result.Key;
            
        }
        else
        {
            // 如果没有满足条件的键，返回 null 或者其他你认为合适的值
            return null;
        }
        

    }
  
    public void HealthValueCheckMachine() 
    {
        if (healthValue <= healthlimitValue)
        {
            Die();
        }
    }

    public virtual void Attack() 
    {
        Debug.Log("Here is Attack");
    }

    
    public void Die()
    {
        Debug.Log("Here is die");
    }

    public virtual void GetHit(string attacker, float HValue, float TValue)
    {
        IncreaseTaunt(attacker, TValue);
        HealthAdd(-HValue);
        Debug.Log("Here is getHit");
    }
}
