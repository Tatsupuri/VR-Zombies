using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{   
    [SerializeField]
    public int  initialBullets = 6;

    public int bullets;
    

    //public bool sniperMode;

    [SerializeField]
    [Range(0.1f,1.5f)]
    private  float fireRate = 1;

    [SerializeField]
    [Range(1,10)]
    private int damage = 1;

    [SerializeField]
    private float impactForce = 30f;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    [SerializeField]
    private AudioSource gunFireSource;

    [SerializeField]
    private AudioSource noBullets;

    private Animator animator;

    private float timer;

    //[SerializeField]
    //private AudioSource magazineGet;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        //bullets = PlayerManager.instance.bullets;
    }

    void Update()
    {
     timer += Time.deltaTime;

     if(timer >= fireRate)
    {
        if(Input.GetButton("Fire1"))
        {
            timer = 0f;
            //animator.SetTrigger("Shoot");
            Debug.Log("shoot");
            FireGun();
            //bullets -= 1;
            //}else if(Input.GetButton("Fire2") && bullets == 0){
                //timer = 0f;
                //noBullets.Play();
            }

        }
    }

    private void FireGun()
    {
       Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f); 
       
       muzzleParticle.Play();
       gunFireSource.Play();

       Ray ray = new Ray(firePoint.position, firePoint.forward);
       RaycastHit hitInfo;

       if(Physics.Raycast(ray, out hitInfo, 100))
       {
           var health = hitInfo.collider.GetComponent<Health>();
           if(health != null)//敵以外のobjectはhealthを持っていないのでなにも起きないようにする
           {
               //Destroy(hitInfo.collider.gameObject);
               health.TakeDamage(damage);
           }

           if(hitInfo.rigidbody != null)
           {
               hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);
           }
       }
    }

    //public void TakeMagazine(int magazine)
    //{
    //    this.GetComponent<Gun>().bullets　+= magazine;
    //    magazineGet.Play();
    //}

    //public int NumOfBullets()
    //{
    //    return bullets;
    //}
}
