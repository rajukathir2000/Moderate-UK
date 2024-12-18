using TMPro;
using UnityEngine;

public class PromptManager : MonoBehaviour
{
    public string[] prompts; // Array for text prompts
    public AudioClip[] PromptsClips; // Array for audio clips
    public AudioSource PromptSource; // AudioSource to play audio
    public TMP_Text promptsTXT;
    



  
    // Dynamic function triggered by Animation Events
    public void TriggerPrompt(int promptIndex)
    {
        Debug.Log("triggered prompt");
        if (promptIndex >= 0 && promptIndex < prompts.Length && promptIndex < PromptsClips.Length)
        {
            // Set the audio clip and text dynamically based on the index
            PromptSource.clip = PromptsClips[promptIndex];
            PromptSource.Play(); // Play the audio clip
            promptsTXT.text = prompts[promptIndex]; // Display the text prompt
            Debug.Log($"Prompt triggered: {prompts[promptIndex]}");
        }
        else
        {
            Debug.LogWarning($"Invalid prompt index: {promptIndex}");
        }
    }
}

