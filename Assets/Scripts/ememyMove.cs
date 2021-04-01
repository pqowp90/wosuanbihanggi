using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ememyMove : MonoBehaviour
{
    [SerializeField]
    private bool isdamaged;
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
        //transform.position+=Vector3.down*Time.deltaTime*speed;
        transform.Translate(Vector3.down*Time.deltaTime*speed);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("lazer")){
            Destroy(gameObject);
        }
        if (collision.CompareTag("Bullet")){
            Destroy(collision.gameObject);
            if(hp>0){
                if (isdamaged) return;
                isdamaged=true;
                StartCoroutine(damaged());
                return;
            }
            //hp-=50;
            
            Destroy(gameObject);
        }
    }
    private  IEnumerator damaged(){
        hp-=50;
        yield return new WaitForSeconds(0.1f);
        isdamaged=false;
    }
}
