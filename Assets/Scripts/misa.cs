using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class misa : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Start()
    {
        Destroy(gameObject,3);
    }

    void Update()
    {
        transform.position+=Vector3.up*Time.deltaTime*speed;
    }
    
    [SerializeField]
    private void nono(){
        Destroy(gameObject);
    }



}
