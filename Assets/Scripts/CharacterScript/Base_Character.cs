using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Character : MonoBehaviour
{
    [Header("Base_Property")]
    public float tauntValue = 0;
    public float tauntAddValue = 1;
    public float tauntlimitValue = 15;

    public float healthlimitValue = 0;
    public float healthValue = 10;
    public float attackValue = 0;

    public bool isDirtLoving = false;
    public bool isAttacked = false;
    public bool isGetHit = false;
    public bool inAttackRange = false;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            isAttacked=true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //HealthAdd(-attackValue);
            TauntAdd(tauntAddValue);
        }

        TauntValueCheckMachine();
        HealthValueCheckMachine();
        
    }
    public void TauntValueCheckMachine()
    {
        if(tauntValue >= tauntlimitValue)
        {
            Attack();
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
        
    }
    
    public void Die()
    {
        Debug.Log("Here is die");
    }

    public virtual void GetHit()
    {
        Debug.Log("Here is getHit");

        TauntAdd(tauntAddValue);

    }


}
