using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [Header("Configurações de Navegação")]
    [Tooltip("Digite o nome exato da próxima cena (Ex: cena-2)")]
    [SerializeField] private string proximaCena;

    [Tooltip("Tecla que permite navegar para esta cena via teclado")]
    [SerializeField] private KeyCode teclaParaAndar = KeyCode.W;

    void Update()
    {
        if (Input.GetKeyDown(teclaParaAndar))
        {
            AndarParaProximaRua();
        }
    }

    void OnMouseDown()
    {
        AndarParaProximaRua();
    }

    // Método centralizado para mudar a cena
    private void AndarParaProximaRua()
    {
        if (!string.IsNullOrEmpty(proximaCena))
        {
            SceneManager.LoadScene(proximaCena);
        }
        else
        {
            Debug.LogWarning("O nome da próxima cena não foi preenchido!");
        }
    }
}