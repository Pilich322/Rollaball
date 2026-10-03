using TMPro;
using UnityEngine;

public class UnderRoofController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private Material transparentMaterial;

    private MeshRenderer meshRenderer;
    private Material originalMaterial;

    void Start()
    {
        meshRenderer = GetComponentInParent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            meshRenderer.material = transparentMaterial;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            meshRenderer.material = originalMaterial;
    }
}
