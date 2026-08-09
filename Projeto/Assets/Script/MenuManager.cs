using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
  
    public void IniciarJogo()
    {
        
        SceneManager.LoadScene("cena-1");
    }
}