using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text textScore=null;
    [SerializeField]
    private Text textLife=null;
    [SerializeField]
    private GameObject enemyCroissantPrefab;
    [SerializeField]
    private long score = 0;
    [SerializeField]

    private int life=3;
    void Start()
    {
        StartCoroutine(SpawnCroissant());
    }
    public void AddScore(long addScore){
        score += addScore;
        UpdateUI();
    }
    public void UpdateUI(){
        //textScore.text = "SCORE\n"+score.ToString();
         textScore.text = string.Format("SCORE\n{0}",score);
    }
    public void Dead(){
        life--;
        textLife.text = string.Format("LIFE\n{0}",life);
        if(life<=0){
            SceneManager.LoadScene("gameover");
        }
    }
    private IEnumerator SpawnCroissant(){
        while(true){
            
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


}
