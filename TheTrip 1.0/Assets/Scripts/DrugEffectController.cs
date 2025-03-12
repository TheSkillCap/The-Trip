using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DrugEffectController : MonoBehaviour
{
    public static DrugEffectController intance;

    public Camera mainCamera;
    private PostProcessVolume volume;
    private Vignette vign;
    private Grain grain;

    private void Awake()
    {
        if (intance == null)
        {
            intance = this;
        }
    }
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        volume = GetComponent<PostProcessVolume>();
        if (volume != null)
        {
            volume.profile.TryGetSettings(out vign);
            volume.profile.TryGetSettings(out grain);
        }

        if (vign != null) vign.intensity.value = 0.662f;
        if (grain != null) grain.intensity.value = 0.3f;
    }

    // Método público para aumentar los efectos cuando el jugador toca el cubo
    public void IncreaseEffects()
    {
        if (vign != null)
        {
            Debug.Log("prueba");
            vign.intensity.value += 0.2f; // Ajusta la cantidad de aumento
            vign.intensity.value = Mathf.Clamp(vign.intensity.value, 0, 1);
        }
        if (grain != null)
        {
            grain.intensity.value += 0.2f; // Ajusta la cantidad de aumento
            grain.intensity.value = Mathf.Clamp(grain.intensity.value, 0, 1);
        }
    }
    public void ReduceEffects()
    {
        if (vign != null)
        {
            Debug.Log("reduce");
            vign.intensity.value -= 0.2f; // Ajusta la cantidad de aumento
            vign.intensity.value = Mathf.Clamp(vign.intensity.value, 0, 1);
        }
        if (grain != null)
        {
            grain.intensity.value -= 0.2f; // Ajusta la cantidad de aumento
            grain.intensity.value = Mathf.Clamp(grain.intensity.value, 0, 1);
        }
    }
}
