using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class T_Character : Base_Character
{
    [Header("T_Property")]
    public float defendProb = 20;//防御成功的概率
    //public float Enemy_tauntValue = 1;

    //下面这两个后面要传参过来
   
    public string enemyName = "Enemy";


    private float inDammage = 3;
    private float intauntValue = 2;

    public void Start()
    {
        tauntValues.Add("Enemy", 1f);
        tauntValues.Add("T", 1f);
        tauntValues.Add("DPS1", 1f);

    }

    protected override void Update()
    {
        S_defendCheckMachine(inDammage, intauntValue);
        //Attack()这个函数是要从Update删掉的，现在是方便测试所以随便写了个触发
        Attack();
        base.Update();
    }

    private void S_defendCheckMachine(float HValue, float TValue)
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
            if(CharacterObject[0]!= null)
            {
                GetHit(enemyName, HValue, TValue);
                Debug.Log("here is gethit");
            }
        }
       
    }

    public override void GetHit(string attacker, float HValue, float TValue)
    {
        if (isGetHit)
        {
            Debug.Log("Here is getHit");

            IncreaseTaunt(attacker, TValue);
            HealthAdd(-HValue);
            isGetHit = false;
        }
    }

    EnemyBase_Character enemy;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("inTrigger");
        enemy = other.GetComponent<EnemyBase_Character>();

        if (enemy != null)
        {
            inAttackRange = true;
            Debug.Log("inAttackRange");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (enemy != null)
        {
            inAttackRange = false;
            Debug.Log("outAttackRange");
        }     
    }

    public override void Attack()
    {
        //Debug.Log("Here is TAttack");
        if (inAttackRange)
        {
            if(Input.GetKeyDown(KeyCode.H))
            {

                CharacterObject[0].GetComponent<EnemyBase_Character>().GetHit(enemyName, attackValue, tauntAddValue);
                Debug.Log("here is attack");
            }
        }
    }
    public void Skill_Smell()
    {

    }
}
