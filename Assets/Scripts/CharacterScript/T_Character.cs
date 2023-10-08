using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class T_Character : Base_Character
{
    [Header("T_Property")]
    public float defendProb = 20;//�����ɹ��ĸ���
    public float Enemy_tauntValue = 1;

    //��������������Ҫ���ι���
    public GameObject enemy;
    public string enemyName = "enemy";
    private float inDammage;
    private float intauntValue;
    protected override void Update()
    {
        S_defendCheckMachine(inDammage, intauntValue);
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
            if(enemy!=null)
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

    private void S_SmellDiffuse()
    {

    }

    //����OnTriggerEnterû�б�ʹ�ã�������Ҫһ���µ��ж��߼����ж��Ƿ��ǵ����ҵ����Ƿ��ڹ�����Χ
    private void OnTriggerEnter(Collider other)
    {
        EnemyBase_Character enemy = other.GetComponent<EnemyBase_Character>();

        if (enemy != null)
        {
            inAttackRange = true;
            Debug.Log("inAttackRange");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inAttackRange = false;
        Debug.Log("outAttackRange");
    }

    public override void Attack()
    {
        //Debug.Log("Here is TAttack");
        if (inAttackRange)
        {
            if(Input.GetKeyDown(KeyCode.H))
            {
                
                enemy.GetComponent<EnemyBase_Character>().GetHit(enemyName, attackValue, tauntAddValue);
                Debug.Log("here is attack");
            }
        }
    }
}
