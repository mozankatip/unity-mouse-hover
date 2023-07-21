using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour
{
    public Renderer[] renderers;
    public Animator animator;
    public ParticleSystem hoverParticle;
    public GameObject uiObject;

    private Color[] originalEmissionColors;
    private bool isHovering;

    private void Start()
    {
        originalEmissionColors = new Color[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            originalEmissionColors[i] = renderers[i].material.GetColor("_EmissionColor");
        }

        // Hide the UI object initially
        if (uiObject != null)
        {
            uiObject.SetActive(false);
        }
    }

    private void Update()
    {
        // If the pointer is over a UI element, return
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // Cast a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits the object with the Hover script
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            // Object is being hovered over
            if (!isHovering)
            {
                SetHoverEmissionColor();
                PlayHoverAnimation();
                PlayHoverParticle();

                Debug.Log("You are hovering over " + gameObject.name);

                // Show the UI object
                if (uiObject != null)
                {
                    uiObject.SetActive(true);
                }
            }
        }
        else
        {
            // Object is not being hovered over
            if (isHovering)
            {
                ResetOriginalEmissionColor();
                StopHoverAnimation();
                StopHoverParticle();

                // Hide the UI object
                if (uiObject != null)
                {
                    uiObject.SetActive(false);
                }
            }
        }
    }

    private void SetHoverEmissionColor()
    {
        foreach (var renderer in renderers)
        {
            Material material = renderer.material;
            Color originalEmissionColor = material.GetColor("_EmissionColor");

            // Modify the emission color
            Color hoverEmissionColor = new Color(0.3f, 0.3f, 0.3f); // Replace with your desired color
            material.SetColor("_EmissionColor", hoverEmissionColor);

            // Enable emission if necessary
            material.EnableKeyword("_EMISSION");

            renderer.material = material;
        }
    }

    private void ResetOriginalEmissionColor()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            Material material = renderers[i].material;

            // Restore the original emission color
            material.SetColor("_EmissionColor", originalEmissionColors[i]);

            // Enable emission if necessary
            material.EnableKeyword("_EMISSION");

            renderers[i].material = material;
        }
    }

    private void PlayHoverAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("IsHovering", true);
        }

        isHovering = true;
    }

    private void StopHoverAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("IsHovering", false);
        }

        isHovering = false;
    }

    private void PlayHoverParticle()
    {
        if (hoverParticle != null)
        {
            hoverParticle.Play();
        }
    }

    private void StopHoverParticle()
    {
        if (hoverParticle != null)
        {
            hoverParticle.Stop();
        }
    }
}
