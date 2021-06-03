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
    protected float speed;
    [SerializeField]
    private GameObject particle;
    [SerializeField]
    private GameObject exeplosion;
    float hp=100;
    private GameObject camerahi;
    private Animator animator;
    private bool isDead=false;
    private Collider2D col =null;
    private SpriteRenderer spriteRenderer;
    private bool chkhihi;
    protected int movemove;
    private void Start()
    {
        speed *= 1+(GameManager.Instance.addSpeed/40);
        gameManager = FindObjectOfType<GameManager>();
        camerahi = GameObject.Find("camera");
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        movemove=(transform.position.x>0)?1:-1;
    }

    private void Update()
    {
        if(chkhihi) return;
        if(GameManager.Instance.isBoss) {StartCoroutine(Dead());chkhihi=true;}
        if(isDead) return;
        
        //transform.position+=Vector3.down*Time.deltaTime*speed;
        ChkLimit();
        Move();
    }
    private void ChkLimit(){
        if(transform.localPosition.y<GameManager.Instance.MinPosition.y){
            Destroy(gameObject);
        }
        if(transform.localPosition.y>GameManager.Instance.MinPosition.y+50f){
            Destroy(gameObject);
        }
        if(transform.localPosition.x<GameManager.Instance.MinPosition.x-20f){
            Destroy(gameObject);
        }
        if(transform.localPosition.x>GameManager.Instance.MinPosition.x+20f){
            Destroy(gameObject);
        }
    }
    protected virtual void Move(){
        transform.Translate(Vector3.down*Time.deltaTime*speed);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(isDead) return;
        if (collision.CompareTag("lazer")){
            Instantiate(particle).transform.position=transform.position;
            camerahi.GetComponent<camera>().startshake(0.2f,0.3f);
            StartCoroutine(Dead());
            GameManager.Instance.AddScore(score);
        }
        if (collision.gameObject.layer==7){
            collision.GetComponent<misa>().Despawn();
            if(hp>0){
                if (isdamaged) return;
                isdamaged=true;
                StartCoroutine(damaged());
                if(hp>0) return;
            }
            //hp-=50;
            Instantiate(particle).transform.position=transform.position;
            GameManager.Instance.AddScore(score);
            camerahi.GetComponent<camera>().startshake(0.2f,0.3f);
            StartCoroutine(Dead());
        }
    }
    protected IEnumerator Dead(){
        spriteRenderer.material.SetColor("_Color",new Color(0f,0f,0f,0f));
        col.enabled = false;
        animator.Play("Explosion");
        isDead = true;
        Instantiate(exeplosion).transform.position = transform.position;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    private IEnumerator damaged(){
        hp-=50;
        spriteRenderer.material.SetColor("_Color",new Color(1f,1f,1f,0f));
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material.SetColor("_Color",new Color(0f,0f,0f,0f));
        isdamaged=false;
    }
}
