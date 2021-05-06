using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SibaBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Sprite NextSprite1;
    [SerializeField]
    private Sprite NextSprite2;
    float duration=2f,strength=0.7f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    public void StartBoss(){
        StartCoroutine(Boss());
    }
    private  IEnumerator Boss(){
        yield return new WaitForSeconds(3.3f);
        animator.enabled=false;
        spriteRenderer.sprite = NextSprite2;
        transform.DOShakePosition(duration,strength,18,90f,false,false);
        for(int i=0;i<10;i++){
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.rotation = new Quaternion(0f,0f,100f+i*(150f/10f),0f);
            bullet.transform.position= transform.position;
            yield return new WaitForSeconds(2f/10f);
        }
        spriteRenderer.sprite = NextSprite1;

        
    }
}
