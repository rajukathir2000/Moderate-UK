//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class BreathingOrb : MonoBehaviour
//{
//    public Button toggleButton;
//    public Text buttonText;
//    private bool isBreathing;
//    public Animator LungsAnim, NurseAnim;
//    public GameObject Lungs, Nurse;
//    public TMP_Text PromptText1;
//    public float transitionDelay = 10f;
//    private bool isSecondAnimationPlaying = false;

//    void Start()
//    {
//        if (Lungs != null)
//        {
//            LungsAnim = Lungs.GetComponent<Animator>();
//            Lungs.SetActive(false);
//        }
//        else
//        {
//            Debug.LogError("Lungs GameObject is not assigned or missing Animator component.");
//        }

//        if (Nurse != null)
//        {
//            NurseAnim = Nurse.GetComponent<Animator>();
//            Nurse.SetActive(false);
//        }
//        else
//        {
//            Debug.LogError("Nurse GameObject is not assigned or missing Animator component.");
//        }


//        if (toggleButton != null)
//        {
//            toggleButton.onClick.AddListener(ToggleBreathing);
//        }
//        else
//        {
//            Debug.LogError("Toggle button is not assigned.");
//        }
//    }

//    public void ToggleBreathing()
//    {
//        isBreathing = !isBreathing;

//        if (isBreathing)
//        {
//            Lungs.SetActive(true);
//            StartAnimating();
//        }
//    }

//    public void StartAnimating()
//    {
//        toggleButton.gameObject.SetActive(false);
//        if (LungsAnim != null)
//        {
//            LungsAnim.enabled = true;
//            LungsAnim.SetBool("Started", true);
//            LungsAnim.SetBool("Completed", false);
//        }
//        else
//        {
//            Debug.LogWarning("Lungs Animator is not assigned. Cannot start animation.");
//        }
//    }

//    public void LungsToNurse()
//    {
//        Lungs.SetActive(false);
//        Nurse.SetActive(true);
//        NurseAnim.SetBool("Started", true);
//        if (NurseAnim != null)
//        {
//            NurseAnim.enabled = true;
//            if (!isSecondAnimationPlaying)
//            {
//                isSecondAnimationPlaying = true;
//                Invoke("TriggerSecondNurseAnimation", transitionDelay);
//            }
//        }
//        else
//        {
//            Debug.LogError("Nurse Animator is not assigned.");
//        }


//    }

//    private void TriggerSecondNurseAnimation()
//        {
//            if (NurseAnim != null)
//            {
//                NurseAnim.SetTrigger("EndSit");
//                NurseAnim.SetBool("Started", false);
//            }
//            else
//            {
//                Debug.LogWarning("Nurse Animator is not assigned.");
//            }
//        }

//        public void BreathinPrompt()
//        {
//            PromptText1.gameObject.SetActive(true);
//            AudioManager.instance.PlayMusic("BreathIn");
//            PromptText1.text = "Breath In";
//        }

//        public void HoldPrompt()
//        {
//            AudioManager.instance.PlayMusic("Hold");
//            PromptText1.text = "Hold";

//        }

//        public void BreathoutPrompt()
//        {
//            AudioManager.instance.PlayMusic("BreathOut");
//            PromptText1.text = "Breath Out Slowly";
//        }

//        public void Nurseprompt1()
//        {
//            AudioManager.instance.PlayMusic("Nurse1");
//            PromptText1.text = "Now Watch me as I demonstrate a simple sit-up exercise.";
//        }
//        public void Nurseprompt2()
//        {
//        AudioManager.instance.PlayMusic("Nurse2");
//            PromptText1.text = "Follow along at your own pace?let?s do this together";
//        }
//    public void Nurseprompt0()
//    {
//        AudioManager.instance.PlayMusic("Nurse0");
//        PromptText1.text = "Great job with the breathing!";
//    }


//}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreathingOrb : MonoBehaviour
{
    public Button toggleButton;
    public Text buttonText;
    private bool isBreathing;
    public Animator LungsAnim, NurseAnim;
    public GameObject Lungs, Nurse, key;
    public TMP_Text PromptText1;
    public float transitionDelay = 10f;
    private bool isSecondAnimationPlaying = false,nurseprompt1 = false;

    void Start()
    {
        Debug.Log("BreathingOrb script initialized.");

        if (Lungs != null)
        {
            LungsAnim = Lungs.GetComponent<Animator>();
            Lungs.SetActive(false);
            Debug.Log("Lungs GameObject and Animator initialized.");
        }
        else
        {
            Debug.LogError("Lungs GameObject is not assigned or missing Animator component.");
        }

        if (Nurse != null)
        {
            NurseAnim = Nurse.GetComponent<Animator>();
            Nurse.SetActive(false);
            Debug.Log("Nurse GameObject and Animator initialized.");
        }
        else
        {
            Debug.LogError("Nurse GameObject is not assigned or missing Animator component.");
        }

        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleBreathing);
            Debug.Log("Toggle button listener added.");
        }
        else
        {
            Debug.LogError("Toggle button is not assigned.");
        }
    }

    public void ToggleBreathing()
    {
        isBreathing = !isBreathing;
        Debug.Log("ToggleBreathing called. isBreathing: " + isBreathing);

        if (isBreathing)
        {
            Lungs.SetActive(true);
            Debug.Log("Lungs activated.");
            StartAnimating();
        }
    }

    public void StartAnimating()
    {
        Invoke(nameof(Nurseprompt0), 50f);
        Invoke(nameof(Nurseprompt1), 24f);
        toggleButton.gameObject.SetActive(false);
        Debug.Log("StartAnimating called.");

        if (LungsAnim != null)
        {
            LungsAnim.enabled = true;
            LungsAnim.SetBool("Started", true);
            LungsAnim.SetBool("Completed", false);
            Debug.Log("Lungs animation started.");
        }
        else
        {
            Debug.LogWarning("Lungs Animator is not assigned. Cannot start animation.");
        }
    }

    public void Nurseprompt0()
    {
        Instantiate(key, new Vector3(0, 1.5f, 2.25f), Quaternion.identity);
        Debug.Log("Nurseprompt0 called.");
        AudioManager.instance.PlayMusic("Nurse0");
        PromptText1.text = "Here's your key to mind!";
    }

    public void LungsToNurse()
    {
        Debug.Log("LungsToNurse called.");

        Lungs.SetActive(false);
        Nurse.SetActive(true);
        NurseAnim.SetBool("Started", true);
        Debug.Log("Nurse activated and animation started.");

        if (NurseAnim != null)
        {
            NurseAnim.enabled = true;
            if (!isSecondAnimationPlaying)
            {
                isSecondAnimationPlaying = true;
                Invoke("TriggerSecondNurseAnimation", transitionDelay);
                Debug.Log("Scheduled second nurse animation with delay: " + transitionDelay);
            }
        }
        else
        {
            Debug.LogError("Nurse Animator is not assigned.");
        }
    }

    private void TriggerSecondNurseAnimation()
    {
        Debug.Log("TriggerSecondNurseAnimation called.");

        if (NurseAnim != null)
        {
            NurseAnim.SetTrigger("EndSit");
            NurseAnim.SetBool("Started", false);
            Debug.Log("Second nurse animation triggered.");
            Invoke("Nurseprompt2",1);
        }
        else
        {
            Debug.LogWarning("Nurse Animator is not assigned.");
        }
    }

    public void BreathinPrompt()
    {
        Debug.Log("BreathinPrompt called.");

        PromptText1.gameObject.SetActive(true);
        AudioManager.instance.PlayMusic("BreathIn");
        PromptText1.text = "Breath In";
    }

    public void HoldPrompt()
    {
        Debug.Log("HoldPrompt called.");

        AudioManager.instance.PlayMusic("Hold");
        PromptText1.text = "Hold";
    }

    public void BreathoutPrompt()
    {
        Debug.Log("BreathoutPrompt called.");

        AudioManager.instance.PlayMusic("BreathOut");
        PromptText1.text = "Breath Out Slowly";
    }

    public void Nurseprompt1()
    {
        if (nurseprompt1 == false)
        {
            nurseprompt1 = true;
            Debug.Log("Nurseprompt1 called.");
            AudioManager.instance.PlayMusic("Nurse1");
            PromptText1.text = "Now watch me as I demonstrate a simple sit-up exercise.";
        }
    }

    public void Nurseprompt2()
    {
        Debug.Log("Nurseprompt2 called.");

        AudioManager.instance.PlayMusic("Nurse2");
        PromptText1.text = "See your anxiety level is decreased and you are better.";
    }
}


