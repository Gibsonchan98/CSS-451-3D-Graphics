using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public partial class KelvinMainController : MonoBehaviour
{
    public KelvinWorld World;
    public Slider BossHealth, PlayerHealth;
    KelvinSceneNode theRoot;
    float bossH, playerH;
    public GameObject panel;
    public Text text;
    public Button Play, Exit;
    private void Awake()
    {
        theRoot = World.TheRoot;

        //set up first level
        theRoot.transform.GetComponent<KelvinAttack1>().enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        bossH = BossHealth.value;
        playerH = PlayerHealth.value;
        Button playB = Play.GetComponent<Button>();
        playB.onClick.AddListener(PlayAgain);
        Button exitB = Exit.GetComponent<Button>();
        exitB.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        mouseEvents();
        //Quit Game
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        }

        PlayerHealthCheck();
        BossStage();
        if (playerH < 1)
        {
            panel.SetActive(true); 

            text.text = "GAME OVER";
        }
        if (bossH < 1)
        {
            panel.SetActive(true);
            text.text = "YOU WON";
        }
    }

    void BossStage()
    {
        bossH -= World.hitBoss();
        //update slider 
        BossHealth.value = bossH;
        //second stage
        if (bossH < 60 && bossH > 20)
        {
            if (theRoot.transform.GetComponent<KelvinAttack2>().enabled != true)
            {
                theRoot.transform.GetComponent<KelvinAttack1>().enabled = false;
                theRoot.transform.GetComponent<KelvinAttack2>().enabled = true;
            }
        }
        //third stage
        if (bossH < 21 && bossH > 0)
        {
            if (theRoot.transform.GetComponent<KelvinAttack3>().enabled != true)
            {
                theRoot.transform.GetComponent<KelvinAttack2>().enabled = false;
                theRoot.transform.GetComponent<KelvinAttack3>().enabled = true;
            }
        }
    }

    void PlayerHealthCheck()
    {
        if (theRoot.transform.GetComponent<KelvinAttack1>().enabled == true)
        {
            playerH -= World.swordHit();
        }
        if (theRoot.transform.GetComponent<KelvinAttack2>().enabled == true)
        {
            playerH -= World.bulletHit();
        }
        if (theRoot.transform.GetComponent<KelvinAttack3>().enabled == true)
        {
            playerH -= World.jumpHit();
        }
        //set player slider value
        PlayerHealth.value = playerH;
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene("KelvinBossGame");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
