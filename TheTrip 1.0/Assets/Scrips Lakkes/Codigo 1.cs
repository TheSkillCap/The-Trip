using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class TimeBarWithBlur : MonoBehaviour
{
    public Slider timeBar; // Referencia al Slider de la UI
    public PostProcessVolume postProcessVolume; // Referencia al volumen de post-procesado
    private DepthOfField depthOfField; // Efecto de profundidad de campo (blur)
    public float maxTime = 10f; // Tiempo máximo en segundos
    private float currentTime = 0f; // Tiempo actual

    void Start()
    {
        // Inicializar el efecto de profundidad de campo (blur)
        postProcessVolume.profile.TryGetSettings(out depthOfField);
        depthOfField.active = true;
        depthOfField.focusDistance.value = 1f; // Valor inicial del blur

        // Configurar el Slider
        timeBar.maxValue = maxTime;
        timeBar.value = 0f;
    }

    void Update()
    {
        // Incrementar el tiempo
        currentTime += Time.deltaTime;

        // Actualizar el valor del Slider
        timeBar.value = currentTime;

        // Aplicar el efecto de difuminado progresivo
        float blurIntensity = Mathf.Lerp(1f, 10f, currentTime / maxTime); // Ajusta los valores según sea necesario
        depthOfField.focusDistance.value = blurIntensity;

        // Detener el efecto cuando se alcance el tiempo máximo
        if (currentTime >= maxTime)
        {
            currentTime = maxTime;
            enabled = false; // Desactivar el script
        }
    }
}