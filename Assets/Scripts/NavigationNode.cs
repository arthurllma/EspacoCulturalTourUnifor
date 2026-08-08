using UnityEngine;

public class NavigationNode : MonoBehaviour
{
    [Header("Imagem 360 do Nó")]
    public Material roomSkybox;

    [Header("Minimapa")]
    public Vector2 minimapPosition;

    [Header("Conexões Direcionais")]
    public NavigationNode forwardNode;
    public NavigationNode backNode;
    public NavigationNode leftNode;
    public NavigationNode rightNode;

    public void ActivateNode()
    {
        if (roomSkybox != null)
        {
            RenderSettings.skybox = roomSkybox;
            DynamicGI.UpdateEnvironment();
        }
        else
        {
            Debug.LogWarning($"[AVISO] O nó {gameObject.name} foi ativado, mas o campo 'Room Skybox' está VAZIO (None)!");
        }
    }
}