using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkyboxColorChanger : MonoBehaviour
{
    public Button changeSkyboxColorButton; // Assign the button to trigger the color change
    public Material skyboxMaterial; // Assign the Skybox material
    public Color startColor = Color.blue; // Initial tint color of the Skybox
    public Color endColor = Color.red; // Target tint color of the Skybox
    public float duration = 2f; // Time to transition colors
    int c = 0;

    private void Start()
    {
        if (changeSkyboxColorButton != null)
        {
            changeSkyboxColorButton.onClick.AddListener(StartColorChange);
        }

        if (skyboxMaterial != null)
        {
            RenderSettings.skybox = skyboxMaterial; // Ensure the Skybox is assigned
            skyboxMaterial.SetColor("_Tint", startColor); // Set the initial tint color
        }
    }

    private void StartColorChange()
    {
        if (skyboxMaterial != null &&c==0)
        {
            c++;
            StartCoroutine(ChangeSkyboxColorGradually());
        }
    }

    private IEnumerator ChangeSkyboxColorGradually()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            skyboxMaterial.SetColor("_Tint", Color.Lerp(startColor, endColor, t));
            yield return null; // Wait for the next frame
        }

        skyboxMaterial.SetColor("_Tint", endColor); // Ensure the final color is set
    }
}
