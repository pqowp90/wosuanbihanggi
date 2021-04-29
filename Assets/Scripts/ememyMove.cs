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
    private Animator animator;
    private bool isDead=false;
    private Collider2D col =null;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        camerahi = GameObject.Find("camera");
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if(gameManager.isBoss) StartCoroutine(Dead());
        if(isDead) return;
        if(transform.localPosition.y<gameManager.MinPosition.y-2){
            Destroy(gameObject);
        }
        //transform.position+=Vector3.down*Time.deltaTime*speed;
        transform.Translate(Vector3.down*Time.deltaTime*speed);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(isDead) return;
        if (collision.CompareTag("lazer")){
            Instantiate(particle).transform.position=transform.position;
            camerahi.GetComponent<camera>().startshake(0.2f,0.3f);
            StartCoroutine(Dead());
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
            camerahi.GetComponent<camera>().startshake(0.2f,0.3f);
            StartCoroutine(Dead());
        }
    }
    private IEnumerator Dead(){
        spriteRenderer.material.SetColor("_Color",new Color(0f,0f,0f,0f));
        col.enabled = false;
        animator.Play("Explosion");
        isDead = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    private  IEnumerator damaged(){
        hp-=50;
        spriteRenderer.material.SetColor("_Color",new Color(1f,1f,1f,0f));
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material.SetColor("_Color",new Color(0f,0f,0f,0f));
        isdamaged=false;
    }
}
