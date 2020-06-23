using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{

    Animator animator;
    Attacker attacker;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherCollider.tag.Equals("Gravestone"))
        {
            animator.SetTrigger("JumpTrigger");
        }
        else if(otherCollider.GetComponent<Defender>())
        {
            attacker.Attack(otherObject);           
        }


    }   

}
