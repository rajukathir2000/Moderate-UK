using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestAnimTrans : MonoBehaviour
{
    public Button triggerButton; // Assign the UI button
    public Animator targetAnimator;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle.gameObject.SetActive(false);
        if (triggerButton != null && targetAnimator != null)
        {
            // Add a listener to the button click event
            triggerButton.onClick.AddListener(SetAnimationTrigger);
        }
    }

    private void SetAnimationTrigger()
    {
        particle.gameObject.SetActive(true);
        // Set the trigger parameter in the Animator
        if (targetAnimator != null)
        {
            targetAnimator.SetTrigger("Clicked");
        }
    }
}
