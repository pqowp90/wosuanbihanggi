using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyCroissantPrefab;
    void Start()
    {
        StartCoroutine(SpawnCroissant());
    }
    private IEnumerator SpawnCroissant(){
        float spawnDeley = 0f;
        spawnDeley = Random.Range(2f,5f);
        float RandomX = 0f;
        RandomX = Random.Range(-7f,7f);


        for(int i=0;i<6;i++){
            yield return new WaitForSeconds(0.2f);
            Instantiate(enemyCroissantPrefab, new Vector2(RandomX,20f),Quaternion.identity);
        }
        yield return new WaitForSeconds(spawnDeley);
    }


}
