using UnityEngine;
using System.Collections.Generic;

public class TrilhaContinuaAvancada : MonoBehaviour
{
    [Header("Nome Único Deste Som")]
    public string idDoAudio;

    [Header("Zerar os áudios anteriores ao entrar nesta cena?")]
    public bool zerarAudiosAnteriores = false;

    private static Dictionary<string, TrilhaContinuaAvancada> instancias = new Dictionary<string, TrilhaContinuaAvancada>();

    void Awake()
    {
       
        if (zerarAudiosAnteriores)
        {
            foreach (var tocador in instancias.Values)
            {
                if (tocador != null && tocador != this)
                {
                    Destroy(tocador.gameObject);
                }
            }
            instancias.Clear(); 
        }

        if (instancias.ContainsKey(idDoAudio))
        {
            if (instancias[idDoAudio] != this)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            instancias[idDoAudio] = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}