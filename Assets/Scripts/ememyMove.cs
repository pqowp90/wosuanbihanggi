using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ememyMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    float hp=100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=Vector3.down*Time.deltaTime*speed;
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Bullet")){
            hp-=50;
        }
        if (hp<0){
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
