using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    string state;

    public GameObject scoreDisplay;
    float score;

    float multi;

    public GameObject Player;
    public GameObject PlayerSpawnVFX;

    int numOfPlayer;

    public GameObject Spawner;
    public GameObject SelectionArea;

    public GameObject UI;

    public GameObject uiscore;
    public GameObject uihighscore;

    // Start is called before the first frame update
    void Start()
    {
        numOfPlayer = 1;
        state = "Menu";

        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
        }
        else
        {
            uihighscore.GetComponent<TextMeshProUGUI>().text = "highscore: " + PlayerPrefs.GetInt("highscore").ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(state == "Gameplay")
        {
            scoreDisplay.SetActive(true);

            multi = 1 + ((GameObject.FindGameObjectsWithTag("Player").Length - 1) * 0.2f);
            score += Time.deltaTime * multi;

            if (score / 25 > numOfPlayer)
            {
                numOfPlayer += 1;
                Instantiate(PlayerSpawnVFX);
                Invoke("Spawn", 1);
            }

            scoreDisplay.GetComponent<TextMeshProUGUI>().text = ((int)score).ToString();
        }
    }

    public void Lost()
    {
        if ((int)score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", (int)score);
        }

        state = "Menu";
        Spawner.SetActive(false);
        SelectionArea.SetActive(false);
        DestroyAllPlayer();

        UI.gameObject.SetActive(true);
        uihighscore.GetComponent<TextMeshProUGUI>().text = "highscore: " + PlayerPrefs.GetInt("highscore").ToString();
        uiscore.SetActive(true);
        uiscore.GetComponent<TextMeshProUGUI>().text = "score: " + ((int)score).ToString();
    }

    void Spawn()
    {
        Instantiate(Player);
    }

    void DestroyAllPlayer()
    {
        foreach(GameObject G in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(G, 1);
        }
    }

    public void Restart()
    {
        foreach (GameObject G in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(G, 1);
        }

        foreach (GameObject G in GameObject.FindGameObjectsWithTag("Obstacles"))
        {
            Destroy(G);
        }

        numOfPlayer = 1;
        state = "Gameplay";
        Spawner.SetActive(true);
        SelectionArea.SetActive(true);

        UI.gameObject.SetActive(false);
        Spawn();
        score = 0;
    }
}
