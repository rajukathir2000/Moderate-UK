using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTransition : MonoBehaviour
{
    public GameObject[] chest;
    public AudioSource audioSource;
    public AudioClip allClearedClip, chestAvailableClip, fromSafeRoomClip;

    private void Start()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("LastScene", "SafeRoom");
            PlayerPrefs.Save();
            PlayFromSafeRoomClip();
            return;
        }
        if (currentScene == 1)
        {
            bool allChestsCleared = true;

            for (int i = 0; i < chest.Length; i++)
            {
                if (PlayerPrefs.GetInt("Chest" + i, 1) == 0)
                {
                    chest[i].SetActive(false);
                }
                else
                {
                    chest[i].SetActive(true);
                    allChestsCleared = false;
                }
            }

            string lastScene = PlayerPrefs.GetString("LastScene", "");
            if (lastScene == "SafeRoom")
            {
                PlayFromSafeRoomClip();
            }
            else if (lastScene == "Button1" || lastScene == "Button2")
            {
                if (allChestsCleared)
                {
                    PlayAllClearedAudio();
                }
                else
                {
                    PlayChestAvailableAudio();
                }
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    public void Button1()
    {
        SetChestInactive(0);
        StartCoroutine(LoadSceneAfterDelay(2, "Button1"));
    }

    public void Button2()
    {
        SetChestInactive(1);
        StartCoroutine(LoadSceneAfterDelay(4, "Button2"));
    }

    private IEnumerator LoadSceneAfterDelay(int sceneIndex, string buttonName)
    {
        PlayerPrefs.SetString("LastScene", buttonName);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    private void SetChestInactive(int chestIndex)
    {
        PlayerPrefs.SetInt("Chest" + chestIndex, 0);
    }

    private void PlayChestAvailableAudio()
    {
        audioSource.clip = chestAvailableClip;
        audioSource.Play();
    }

    private void PlayAllClearedAudio()
    {
        audioSource.clip = allClearedClip;
        audioSource.Play();
    }

    private void PlayFromSafeRoomClip()
    {
        audioSource.clip = fromSafeRoomClip;
        audioSource.Play();
    }
}
