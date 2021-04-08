using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ememyMove : MonoBehaviour
{
    private GameManager gameManager = null;
    [SerializeField]
    private long score = 9;
    [SerializeField]
    private bool isdamaged;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject particle;
    float hp=100;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position+=Vector3.down*Time.deltaTime*speed;
        transform.Translate(Vector3.down*Time.deltaTime*speed);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("lazer")){
            Instantiate(particle).transform.position=transform.position;
            Destroy(gameObject);
        }
        if (collision.CompareTag("Bullet")){
            Destroy(collision.gameObject);
            if(hp>0){
                if (isdamaged) return;
                isdamaged=true;
                StartCoroutine(damaged());
                if(hp>0) return;
            }
            //hp-=50;
            Instantiate(particle).transform.position=transform.position;
            gameManager.AddScore(score);
            Destroy(gameObject);
        }
    }
    private  IEnumerator damaged(){
        hp-=50;
        yield return new WaitForSeconds(0.1f);
        isdamaged=false;
    }
}
