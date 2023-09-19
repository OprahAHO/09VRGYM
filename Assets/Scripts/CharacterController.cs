using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject[] character;
    private GameObject canControlChar;
    void Update()
    {
        CharacterChose();
        CharacterControl();
    }

    void CharacterChose()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            character[0].SetActive(true);
            character[1].SetActive(false);
            character[2].SetActive(false);
            character[3].SetActive(false);
            canControlChar = character[0];

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            character[0].SetActive(false);
            character[1].SetActive(true);
            character[2].SetActive(false);
            character[3].SetActive(false);
            canControlChar = character[1];

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            character[0].SetActive(false);
            character[1].SetActive(false);
            character[2].SetActive(true);
            character[3].SetActive(false);
            canControlChar = character[2];

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            character[0].SetActive(false);
            character[1].SetActive(false);
            character[2].SetActive(false);
            character[3].SetActive(true);
            canControlChar = character[3];

        }
    }
    void CharacterControl()
    {
        if(canControlChar != null)
        {
            Animator charAni;
            Transform charTrans;
            charAni = canControlChar.GetComponent<Animator>();
            charTrans = canControlChar.GetComponent<Transform>();
            if (Input.GetKeyDown(KeyCode.W))
            {
                charAni.SetFloat("Foward", 1);
                charAni.SetBool("NewBool", true);
                charAni.SetInteger("NextAni", 0);

            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                charAni.SetFloat("Foward", 0);
            }


            if(Input.GetKeyDown(KeyCode.A))
            {
                charAni.SetFloat("Right", 1);
                charAni.SetBool("NewBool", true);
                charAni.SetInteger("NextAni", 0);

            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                charAni.SetFloat("Right", 0);
            }


            if (Input.GetKeyDown(KeyCode.D))
            {
                charAni.SetFloat("Right", -1);
                charAni.SetBool("NewBool", true);
                charAni.SetInteger("NextAni", 0);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                charAni.SetFloat("Right", 0);
            }
            

            if(Input.GetKeyDown(KeyCode.J))
            {
                charAni.SetBool("NewBool", true);
                charAni.SetInteger("NextAni", 1);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                charAni.SetBool("NewBool", true);
                charAni.SetInteger("NextAni", 2);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                charAni.SetBool("NewBool", true);
                charAni.SetInteger("NextAni", 3);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                charAni.SetBool("NewBool", true);
                charAni.SetInteger("NextAni", 4);
            }
            

        }
    }
}

