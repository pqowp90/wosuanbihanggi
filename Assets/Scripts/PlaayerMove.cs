using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaayerMove : MonoBehaviour
{
    [SerializeField]
    private Transform bulletPosition = null;
    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    private GameObject dadadadadada = null;
    [SerializeField]
    private GameObject jumug = null;
    [SerializeField]
    private float deleydadada;
    [SerializeField]
    private float deleydododododo;
    [SerializeField]
    private float deleyfirehi;
    [SerializeField]
    private float barssadeley=0.2f;
    [SerializeField]
    private float speed = 5f;
    private SpriteRenderer spriteRenderer = null;
    private bool isDamaged=false;
    private Vector2 targerPosition = new Vector2(0,-10);
    private GameManager gameManager = null;
    public GameObject misa;
    Animator animator;
    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();    
        gameManager = FindObjectOfType<GameManager>();
        //Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
        StartCoroutine(Fire());
    }

    void Update()
    {
        if (deleydadada>0f)
            deleydadada-=Time.deltaTime;
        if (deleyfirehi>0f)
            deleyfirehi-=Time.deltaTime;
        if (deleydododododo>0f)
            deleydododododo-=Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            targerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targerPosition.x = Mathf.Clamp(targerPosition.x,gameManager.MinPosition.x,gameManager.MaxPosition.x);
            targerPosition.y = Mathf.Clamp(targerPosition.y,gameManager.MinPosition.y,gameManager.MaxPosition.y);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targerPosition, speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (deleyfirehi<=0f)
                StartCoroutine(Firehihi());
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (deleydadada<=0f)   
                StartCoroutine(dadada());
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (deleydododododo<=0f)   
                StartCoroutine(dododododo());
        }
        
    }
    private IEnumerator Fire(){
        while(true){
            SpawnOrInstantiate();
            yield return new WaitForSeconds(barssadeley);
        }

    }
    private void SpawnOrInstantiate(){
        GameObject bullet=null;
        if(GameManager.Instance.poolManager.transform.childCount>0){
            bullet = GameManager.Instance.poolManager.transform.GetChild(0).gameObject;
            bullet.transform.SetParent(bulletPosition);
            bullet.transform.position = bulletPosition.position;
            bullet.SetActive(true);
        }else{
        bullet = Instantiate(bulletPrefab,bulletPosition);
        }
        if(bullet != null){
            bullet.transform.SetParent(null);
        }
    }
    private IEnumerator Damage(){
        for(int i=0;i<3;i++){
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
        isDamaged=false;

    }
    private IEnumerator Firehihi(){
        deleyfirehi=7;
        jumug.SetActive(true);
        animator.SetTrigger("때렸다");
        yield return new WaitForSeconds(1f);
        Instantiate(misa).transform.position=bulletPosition.position;
        jumug.SetActive(false);

    }
    private IEnumerator dododododo(){
        deleydododododo=5;
        animator.SetBool("기관총발싸",true);
        barssadeley = 0.05f;
        yield return new WaitForSeconds(4f);
        animator.SetBool("기관총발싸",false);
        barssadeley = 0.2f;
    }
    private IEnumerator dadada(){
        deleydadada=5;
        dadadadadada.SetActive(true);
        yield return new WaitForSeconds(4f);
        dadadadadada.SetActive(false);

    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="enemy"){
            if(isDamaged) return;
            isDamaged=true;
            StartCoroutine(Damage());
            gameManager.Dead();
        }
    }
}
