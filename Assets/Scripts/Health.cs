using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{

    [SerializeField]
    public float startingHealth = 5.0f;

    public float currentHealth;
    private Animator animator;
    private NavMeshAgent agent;

    private bool damaged;

    private int countor = 0;
    [SerializeField] private int coolTime = 50;

    void Update()
    {
        
    }

    //void OnEnable()//OnEnableはObjectができる度に実行されるのでリスポーンとか可能
    void Start()
    {   
        if(this.tag != "Player")
        {
            currentHealth = startingHealth;
        }
        
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
        //Die();
        //this.gemeObject.GetComponent<Rigidbody>().detectCollisions = false; 
        animator.SetTrigger("Death");
        this.GetComponent<AudioSource>().enabled = false; 
        agent.speed = 0;
        Destroy(this.gameObject, 3.0f);
        }

        //animator.SetTrigger("Damage");
        damaged  = true;
    }

    public bool Dead()
    {   
        if(currentHealth <= 0)
        {
            return true;
        }else{
            return false;
        }
    }

    public bool Damaged()
    {
        if(damaged){
           return true;
        }else{
            return false;
        }         
    }

    public float StartHealth()
    {
        return startingHealth;
    }

    public float Ref()
    {
        return currentHealth;
    }

}
