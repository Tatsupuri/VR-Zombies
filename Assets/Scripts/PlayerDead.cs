using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
   
   [SerializeField] Text message;
   [SerializeField] private GameObject buttons;


   private void Start()
   {
       buttons.SetActive(false);
   }

    private void OnTriggerEnter(Collider collider){
        Debug.Log("Zombie Trigger is on");
        if(collider.gameObject.tag =="Player"){
            message.text = "GAME OVER";
            buttons.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponents<AudioSource>()[1].Stop();
            GameObject.FindGameObjectWithTag("Player").GetComponents<AudioSource>()[2].Play();
            Time.timeScale = 0;
        }

    }

}
