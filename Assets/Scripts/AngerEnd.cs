using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerEnd : MonoBehaviour
{
    public Button toggleButton;
    public GameObject Nose, Hand,Nurse;
    // Start is called before the first frame update
    void Start()
    {
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(StartAnim);
            Debug.Log("Toggle button listener added.");
        }
        else
        {
            Debug.LogError("Toggle button is not assigned.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartAnim()
    {
        toggleButton.gameObject.SetActive(false);
        Hand.SetActive(true);
        Nose.SetActive(true);
        Invoke("ClosingSession", 35f);
    }

    void ClosingSession()
    {
        Hand.SetActive(false);
        Nose.SetActive(false);
        Nurse.gameObject.SetActive(true);


    }

}
