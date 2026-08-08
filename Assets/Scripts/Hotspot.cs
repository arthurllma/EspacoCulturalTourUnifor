using UnityEngine;

public class Hotspot : MonoBehaviour
{
    [Header("Nó de Destino")]
    public NavigationNode targetNode; // Arraste para cá o nó da sala para onde este hotspot leva

    private NavigationManager navManager;
    private Vector3 originalScale;

    void Start()
    {
        // Encontra o gerenciador de navegação na cena
        navManager = Object.FindFirstObjectByType<NavigationManager>();
        originalScale = transform.localScale;
    }

    // Ação executada ao clicar no objeto
    private void OnMouseDown()
    {
        if (targetNode != null && navManager != null)
        {
            navManager.NavigateTo(targetNode);
        }
    }

    // Feedback visual: Mouse entra no objeto
    private void OnMouseEnter()
    {
        transform.localScale = originalScale * 1.2f; // Aumenta 20%
    }

    // Feedback visual: Mouse sai do objeto
    private void OnMouseExit()
    {
        transform.localScale = originalScale; // Volta ao tamanho original
    }
}