using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Text textBestScore=null;
    private void Start() {
        textBestScore.text = string.Format("BEST SCORE\n{0}",PlayerPrefs.GetInt("BEST",0));
    }
    public void retry(){
        SceneManager.LoadScene("Main");
    }
}
