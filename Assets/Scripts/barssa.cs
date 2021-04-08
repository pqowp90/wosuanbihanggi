using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barssa : MonoBehaviour
{
    private Transform bulletPosition = null;
    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Fire(){
        GameObject bullet;

        while(true){
            bullet = Instantiate(bulletPrefab,bulletPosition);
            bullet.transform.SetParent(null);
            yield return new WaitForSeconds(0.2f);
        }

    }
}
