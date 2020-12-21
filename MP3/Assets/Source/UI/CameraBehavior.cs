using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehavior : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject TheWorldExtra;
    public GameObject TheWorld1;
    public GameObject SecondControl;
    public GameObject ControPanel;
    public GameObject LinePanel;
    public GameObject MainControl;
    // Start is called before the first frame update
    void Start()
    {
        TheWorldExtra.SetActive(false);
        SecondControl.SetActive(false);
        ControPanel.GetComponent<Image>().enabled = false;
        LinePanel.GetComponent<Image>().enabled = false;
        ControPanel.SetActive(false);
        LinePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cam1")) {
            TheWorld1.SetActive(true);
            cam1.SetActive(true);
            cam2.SetActive(false);
            MainControl.SetActive(true);
            MainControl.GetComponent<Image>().enabled = true;
            ControPanel.GetComponent<Image>().enabled = false;
            LinePanel.GetComponent<Image>().enabled = false;
            TheWorldExtra.SetActive(false);
            SecondControl.SetActive(false);
            ControPanel.SetActive(false);
            LinePanel.SetActive(false);
           
        }
        if (Input.GetButtonDown("Cam2"))
        {
            MainControl.GetComponent<Image>().enabled = false;
            MainControl.SetActive(false);

            TheWorld1.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(true);
            LinePanel.SetActive(true);
            TheWorldExtra.SetActive(true);
            SecondControl.SetActive(true);
            ControPanel.SetActive(true);
            
            ControPanel.GetComponent<Image>().enabled = true;
            LinePanel.GetComponent<Image>().enabled = true;
        }

        if (cam1.activeSelf == true) {
            Debug.Log("Here");
        
        }
    }
}
