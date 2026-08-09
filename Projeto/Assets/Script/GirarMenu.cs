using UnityEngine;

public class GirarMenu : MonoBehaviour
{
    [Header("Velocidade do Giro")]
    [SerializeField] private float velocidade = 2f;

    void Update()
    {
        
        transform.Rotate(0, velocidade * Time.deltaTime, 0);
    }
}