using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public enum SCENE
    {
        test, Title, Stage1, Stage2, Stage3, Stage4, Stage5, Stage6
    }
    public SCENE nextScene;

    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject buttons;
    [SerializeField] Text message;

    private int currentEnemies;
    private int initialEnemies;
    public Text enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        initialEnemies = enemies.transform.childCount;
        currentEnemies = initialEnemies;
        buttons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentEnemies = enemies.transform.childCount;
        enemyCount.text = "残り： " + currentEnemies + " / " + initialEnemies;

        if(currentEnemies == 0)
        {
            message.text = "CLEAR!!!";
            buttons.SetActive(true);
        }
    }


    public void StartGame() {
		SceneManager.LoadScene (nextScene.ToString());
	}


    public void ReStartGame() {
        Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}


	public void EndGame() {
		Application.Quit();
	}

}
