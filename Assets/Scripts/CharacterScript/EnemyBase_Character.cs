using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase_Character : Base_Character
{
    [Header("Enemy_Property")]
    public float T_tauntValue = 1;
    public void Start()
    {
        tauntValues.Add("Enemy", 1f);
        tauntValues.Add("T", 1f);
        tauntValues.Add("DPS1", 1f);

    }


}
