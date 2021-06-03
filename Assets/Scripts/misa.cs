using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class misa : MonoBehaviour
{
    [SerializeField]
    public float speed;
    private GameManager gameManager = null;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.up*Time.deltaTime*speed);
        if(transform.localPosition.y > gameManager.MaxPosition.y+2){
            Despawn();
        }
        if(transform.localPosition.x > gameManager.MaxPosition.x+2){
            Despawn();
        }
        if(transform.localPosition.y < gameManager.MinPosition.y-2){
            Despawn();
        }
        if(transform.localPosition.x < gameManager.MinPosition.x-2){
            Despawn();
        }
    }
    public void Despawn(){
        transform.SetParent(GameManager.Instance.poolManager.transform,false);

        gameObject.SetActive(false);
    }
    
    [SerializeField]
    private void nono(){
        Destroy(gameObject);
    }



}
