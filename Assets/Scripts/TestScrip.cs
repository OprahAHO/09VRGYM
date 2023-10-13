using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScrip : MonoBehaviour
{
    public bool inAttackRange;

    TestScrip t;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1111111111");
        t = other.GetComponent<TestScrip>();

        if (t != null)
        {
            inAttackRange = true;
            Debug.Log("inAttackRange");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (t != null)
        {
            inAttackRange = false;
            Debug.Log("outAttackRange");
        }

    }
}
