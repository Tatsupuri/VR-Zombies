using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      this.transform.Rotate(0,rotationSpeed * Time.deltaTime,0);   
    }

    public void Dead()
    {
            //Destroy(this.transform.parent.gameObject);
            //Debug.Log(this.transform.position);
            Destroy(this.gameObject);
            //Debug.Log("Destroy");
    }
}
