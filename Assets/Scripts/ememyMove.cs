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
    private GameObject camerahi;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        camerahi = GameObject.Find("camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.y<gameManager.MinPosition.y-2){
            Destroy(gameObject);
        }
        //transform.position+=Vector3.down*Time.deltaTime*speed;
        transform.Translate(Vector3.down*Time.deltaTime*speed);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("lazer")){
            Instantiate(particle).transform.position=transform.position;
            camerahi.GetComponent<camera>().startshake(0.3f,0.3f);
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
            camerahi.GetComponent<camera>().startshake(0.3f,0.3f);
            Destroy(gameObject);
        }
    }
    private  IEnumerator damaged(){
        hp-=50;
        yield return new WaitForSeconds(0.1f);
        isdamaged=false;
    }
}
