using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Character : Base_Character
{
    [Header("T_Property")]
    public float defendProb = 20;
    protected override void Update()
    {
        S_defendCheckMachine();
        GetHit();
        base.Update();
    }

    private void S_defendCheckMachine()
    {
        if(isAttacked)
        {
            float floatValue = Random.Range(0f, 1f);
            isGetHit = floatValue <= defendProb / 100f;

            if(!isGetHit)
            {
                Debug.Log("defend Success");
            }
            isAttacked = false;
        }
       
    }

    public override void GetHit()
    {
        if (isGetHit)
        {
            HealthAdd(-attackValue);
            isGetHit = false;
            base.GetHit();
        }
    }

    private void S_SmellDiffuse()
    {

    }

    public override void Attack()
    {
        //Debug.Log("Here is TAttack");

    }
}
