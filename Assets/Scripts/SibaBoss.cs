using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SibaBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject exeplosion;
    private float rotationZ = 0f;
    [SerializeField]
    private Slider hpBar;
    [SerializeField]
    private Sprite NextSprite1;
    [SerializeField]
    private Sprite NextSprite2;
    [SerializeField]
    private Sprite NextSprite3;
    float duration=2f,strength=0.7f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 diff = Vector2.zero;
    private float bossHp=200f;
    GameObject bullet;
    private Coroutine bossCo,bossCo2;
    private bool Dead;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bullet")){
            Destroy(other);
            bossHp--;
            if(bossHp<=0){
                if(Dead)return;
                Dead=true;
                hpBar.gameObject.SetActive(false);
                transform.DOMove(new Vector3(-0.08f,18.72f,0f),5f);
                StopAllCoroutines();
                spriteRenderer.sprite = NextSprite3;
                for(int i=0;i<10;i++){
                    Instantiate(exeplosion).transform.position = transform.position + new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f),0f);
                }
                StartCoroutine(inpiniti());
            }
            hpBar.value = bossHp/200f;
        }
        if(other.CompareTag("lazer")){
            bossHp-=10;
            if(bossHp<=0){
                if(Dead)return;
                Dead=true;
                hpBar.gameObject.SetActive(false);
                transform.DOMove(new Vector3(-0.08f,18.72f,0f),5f);
                StopAllCoroutines();
                spriteRenderer.sprite = NextSprite3;
                for(int i=0;i<10;i++){
                    Instantiate(exeplosion).transform.position = transform.position + new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f),0f);
                }
                StartCoroutine(inpiniti());
            }
            hpBar.value = bossHp/200f;
        }
    }
    private IEnumerator inpiniti(){
        yield return new WaitForSeconds(5f);
        animator.enabled=true;
        animator.Play("무한");
        yield return new WaitForSeconds(2f);
        GameManager.Instance.StartGoGo();
        Destroy(gameObject);
    }
    public void StartBoss(){
        bossCo=StartCoroutine(Boss());
    }
    private  IEnumerator Boss(){
        yield return new WaitForSeconds(3.3f);
        animator.enabled=false;
        hpBar.gameObject.SetActive(true);
        bossCo2=StartCoroutine(BossAttack11());
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(BossAttack3());
        yield return new WaitForSeconds(2.5f);
        while(true){
            int random;
            random = Random.Range(0,3);
            switch(random){
                case 0:
                StartCoroutine(BossAttack1());
                break;
                case 1:
                StartCoroutine(BossAttack2());
                break;
                case 2:
                StartCoroutine(BossAttack3());
                break;
            }
            yield return new WaitForSeconds(2.5f);
        }
        

        

        
    }

    private  IEnumerator Die(){
        spriteRenderer.sprite = NextSprite2;
        transform.DOShakePosition(duration,strength,18,90f,false,false);
        for(int i=0;i<10;i++){
             bullet = Instantiate(bulletPrefab);
            bullet.transform.position= transform.position;
            bullet.transform.rotation = Quaternion.Euler(0f,0f,100f+i*(150f/10f));
            yield return new WaitForSeconds(2f/20f);
        }
        spriteRenderer.sprite = NextSprite1;
    }
    private  IEnumerator BossAttack1(){
        spriteRenderer.sprite = NextSprite2;
        transform.DOShakePosition(duration,strength,18,90f,false,false);
        for(int i=0;i<20;i++){
             bullet = Instantiate(bulletPrefab);
            bullet.transform.position= transform.position;
            bullet.transform.rotation = Quaternion.Euler(0f,0f,100f+i*(150f/10f));
            yield return new WaitForSeconds(2f/20f);
        }
        spriteRenderer.sprite = NextSprite1;
    }
    private  IEnumerator BossAttack2(){
        spriteRenderer.sprite = NextSprite2;
        transform.DOShakePosition(duration,strength,18,90f,false,false);
        for(int i=0;i<20;i++){
             bullet = Instantiate(bulletPrefab);
            bullet.transform.position= transform.position;
            bullet.transform.rotation = Quaternion.Euler(0f,0f,(i<10)?100f+i*(150f/10f):250-(i-10)*(150f/10f));
            yield return new WaitForSeconds(2f/20f);
        }
        spriteRenderer.sprite = NextSprite1;
    }
    private  IEnumerator BossAttack3(){
        spriteRenderer.sprite = NextSprite2;
        transform.DOShakePosition(duration,strength,18,90f,false,false);
        for(int i=0;i<20;i++){
             bullet = Instantiate(bulletPrefab);
            bullet.transform.position= transform.position;
            bullet.transform.rotation = Quaternion.Euler(0f,0f,100f+Random.Range(0f,150f));
            yield return new WaitForSeconds(2f/20f);
        }
        spriteRenderer.sprite = NextSprite1;
    }
    private  IEnumerator BossAttack11(){
        while(true){
            bullet = Instantiate(bulletPrefab,transform);
            diff = GameManager.Instance.player.transform.position - transform.position;
            diff.Normalize();
            rotationZ = Mathf.Atan2(diff.y,diff.x)*Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0f,0f,rotationZ-90f);
            bullet.transform.parent=null;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
