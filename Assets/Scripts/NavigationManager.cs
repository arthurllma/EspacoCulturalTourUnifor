using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class NavigationManager : MonoBehaviour
{
    [Header("Nó Inicial")]
    public NavigationNode currentNode;

    [Header("Interface UI")]
    public TextMeshProUGUI progressText;
    public TextMeshProUGUI tutorialText; // "Arraste o mouse para olhar ao redor"
    public GameObject victoryPanel;      // Mensagem/Painel de "Todas as salas foram exploradas"
    public GameObject menuPanel;

    [Header("Minimapa")]
    public RectTransform playerIndicator;

    [Header("Áudio e Efeitos")]
    public AudioSource audioSource;
    public AudioClip footstepSFX;
    public AudioClip victorySFX;

    [Header("Botões Direcionais da Tela")]
    public Button btnForward;
    public Button btnBack;
    public Button btnLeft;
    public Button btnRight;

    private int totalNodesInScene = 0;
    private bool hasWon = false;
    private bool hasShownNode02Tutorial = false; // Garante que a mensagem do Nó 2 só apareça 1 vez

    // Histórico de nós visitados
    public HashSet<NavigationNode> visitedNodes = new HashSet<NavigationNode>();

    private void Start()
    {
        totalNodesInScene = GetComponentsInChildren<NavigationNode>(true).Length;

        // Oculta a mensagem de vitória ao iniciar
        if (victoryPanel != null)
            victoryPanel.SetActive(false);

        // Exibe o tutorial temporário inicial de 3 segundos
        if (tutorialText != null)
        {
            tutorialText.gameObject.SetActive(true);
            tutorialText.text = "Arraste o mouse para olhar ao redor";
            StartCoroutine(HideTutorialRoutine(7f));
        }

        if (currentNode != null)
        {
            // O parâmetro 'false' impede que o som de passos toque ao iniciar o jogo
            NavigateTo(currentNode, playSound: false);
        }
    }

    private IEnumerator HideTutorialRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (tutorialText != null)
        {
            tutorialText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Keyboard.current == null || currentNode == null) return;

        // Leitura do teclado: WASD ou Setas direcionais
        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
            GoForward();
        else if (Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame)
            GoBack();
        else if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame)
            GoLeft();
        else if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame)
            GoRight();
    }

    public void NavigateTo(NavigationNode targetNode, bool playSound = true)
    {
        if (targetNode == null) return;

        currentNode = targetNode;

        // 1. Troca a foto 360° no Skybox
        currentNode.ActivateNode();

        // 2. Toca o efeito sonoro de passos
        if (playSound && audioSource != null && footstepSFX != null)
        {
            audioSource.PlayOneShot(footstepSFX);
        }

        // 3. Atualiza o marcador no Minimapa
        UpdateMinimap();

        // 4. Registra no histórico e verifica progresso/vitória
        visitedNodes.Add(currentNode);
        UpdateProgressUI();

        // 5. Verifica se chegou ao Nó 2 para exibir a dica temporária de 2 segundos
        CheckNode02Tutorial();

        // 6. Atualiza a exibição das setas na tela
        UpdateNavigationButtons();
    }

    private void CheckNode02Tutorial()
    {
        // Verifica se é o Node_02 e se a dica ainda não foi exibida
        if (!hasShownNode02Tutorial && currentNode != null && currentNode.name.Equals("Node_02"))
        {
            hasShownNode02Tutorial = true;

            if (tutorialText != null)
            {
                StopAllCoroutines();

                tutorialText.gameObject.SetActive(true);
                tutorialText.text = "Escolha um lado (esquerda ou direita) para explorar o museu";
                StartCoroutine(HideTutorialRoutine(2f)); // Fica visível por 2 segundos
            }
        }
    }

    private void UpdateMinimap()
    {
        if (playerIndicator != null && currentNode != null)
        {
            playerIndicator.anchoredPosition = currentNode.minimapPosition;
        }
    }

    private void UpdateNavigationButtons()
    {
        if (currentNode == null) return;

        if (btnForward != null)
            btnForward.gameObject.SetActive(currentNode.forwardNode != null && currentNode.forwardNode != currentNode);

        if (btnBack != null)
            btnBack.gameObject.SetActive(currentNode.backNode != null && currentNode.backNode != currentNode);

        if (btnLeft != null)
            btnLeft.gameObject.SetActive(currentNode.leftNode != null && currentNode.leftNode != currentNode);

        if (btnRight != null)
            btnRight.gameObject.SetActive(currentNode.rightNode != null && currentNode.rightNode != currentNode);
    }

    private void UpdateProgressUI()
    {
        if (progressText != null)
        {
            progressText.text = $"Salas Visitadas: {visitedNodes.Count} / {totalNodesInScene}";
        }

        // Verifica se todas as salas foram visitadas
        if (!hasWon && visitedNodes.Count >= totalNodesInScene && totalNodesInScene > 0)
        {
            TriggerVictory();
        }
    }

    private void TriggerVictory()
    {
        hasWon = true;

        // Toca som de vitória
        if (audioSource != null && victorySFX != null)
        {
            audioSource.PlayOneShot(victorySFX);
        }

        // Exibe o painel de vitória e esconde após 3 segundos
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            StartCoroutine(HideVictoryPanelRoutine(2f)); // <--- Temporizador adicionado
        }
    }

    private IEnumerator HideVictoryPanelRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
    }
    public void StartExperience()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false); // Esconde a tela de menu
        }
    }

    public void GoForward() => NavigateTo(currentNode.forwardNode);
    public void GoBack() => NavigateTo(currentNode.backNode);
    public void GoLeft() => NavigateTo(currentNode.leftNode);
    public void GoRight() => NavigateTo(currentNode.rightNode);
}
