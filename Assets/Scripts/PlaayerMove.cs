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
    private GameObject jumug = null;

    [SerializeField]
    private float speed = 5f;
    private Vector2 targerPosition = new Vector2(0,-10);
    public GameObject misa;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Fire());
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Firehihi());
            
        }
        
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, targerPosition, speed * Time.deltaTime);
    }
    private IEnumerator Fire(){
        GameObject bullet;

        while(true){
            bullet = Instantiate(bulletPrefab,bulletPosition);
            bullet.transform.SetParent(null);
            yield return new WaitForSeconds(0.2f);
        }

    }
    private IEnumerator Firehihi(){
        jumug.SetActive(true);
        animator.SetTrigger("때렸다");
        yield return new WaitForSeconds(1f);
        Instantiate(misa).transform.position=bulletPosition.position;
        jumug.SetActive(false);

    }
}
