using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleSystemFadeOut : MonoBehaviour
{
    public float playDuration = 1f; // How long the particle system plays normally
    public float fadeDuration = 1.5f; 

    private ParticleSystem particleSystem;
    private float elapsedTime;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        // Configure the Color over Lifetime module for fade effect
        var colorOverLifetime = particleSystem.colorOverLifetime;
        colorOverLifetime.enabled = true;

        // Set up fresh fade (nice lol)
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
        );
        colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);

        particleSystem.Play();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Stop the particle emission after the play duration
        if (elapsedTime >= playDuration && particleSystem.isEmitting)
        {
            particleSystem.Stop(); 
        }

        // Destroy the particle system after fade duration completes
        if (elapsedTime >= playDuration + fadeDuration)
        {
            Destroy(gameObject);
        }
    }
}

