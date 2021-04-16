using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class misa : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private GameManager gameManager = null;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject,3);
    }

    void Update()
    {
        transform.Translate(Vector2.up*Time.deltaTime*speed);
        if(transform.localPosition.y > gameManager.MaxPosition.y+2){
            Destroy(gameObject);
        }
    }
    
    [SerializeField]
    private void nono(){
        Destroy(gameObject);
    }



}
