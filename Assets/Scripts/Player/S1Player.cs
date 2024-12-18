using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S1Player : MonoBehaviour
{
    public Animator nurseAnim;
    public AudioSource audioSource;
    public AudioClip closeEyes;
    public Image blackPanel;
    public ParticleSystem startParticle, carParticle;

    private void Start()
    {
        PlayerPrefs.DeleteAll(); // Reset all saved chest data
        PlayerPrefs.SetString("LastScene", "SafeRoom"); // Mark the last scene as Safe Room
        PlayerPrefs.Save();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("StartMarker"))
        {
            startParticle.gameObject.SetActive(false);
            Debug.Log("StartedTherapy");
            nurseAnim.SetBool("Start", true);
            Invoke("NurseIntro", 3f);
            Invoke("GetInCar", 14f);
        }
        else if(other.gameObject.CompareTag("CarMarker"))
        {
            carParticle.gameObject.SetActive(false);
            Debug.Log("GetIncar");
            gameObject.transform.SetPositionAndRotation(new Vector3(0.6f, -0.5f, -12.5f),Quaternion.Euler(0f, 0f, 0f));
            Debug.Log(transform.position);
            Invoke("CloseEyes", 3f);
        }
    }

    private void NurseIntro()
    {
        audioSource.Play();
    }

    private void GetInCar()
    {
        carParticle.gameObject.SetActive(true);        
        nurseAnim.SetBool("Start", false);
        nurseAnim.SetBool("GetIn", true);
    }

    void CloseEyes()
    {
        audioSource.clip = closeEyes;
        audioSource.Play();
        StartCoroutine(FadeIn());
        StartCoroutine(LoadSceneAfterDelay(1));
    }

    private IEnumerator LoadSceneAfterDelay(int sceneIndex)
    {
        yield return new WaitForSeconds(3f); // Wait for 5 seconds
        SceneManager.LoadSceneAsync(sceneIndex); // Load the scene asynchronously
    }

    private IEnumerator FadeIn()
    {
        float duration = 2f; // Duration of the fade
        float currentTime = 0f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, currentTime / duration); // Interpolates alpha
            blackPanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        blackPanel.color = new Color(0, 0, 0, 1); // Ensure it ends fully black
    }
}
