using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSequenceUnlock : MonoBehaviour
{
    Manager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    // Secuencia correcta de botones (puedes usar cualquier KeyCode o Input)
    private readonly List<KeyCode> correctSequence = new List<KeyCode>
    {
        KeyCode.UpArrow,
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.DownArrow,
        KeyCode.RightArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.LeftArrow
    };

    private List<KeyCode> inputBuffer = new List<KeyCode>(); // Buffer para capturar entradas

    void Update()
    {
        // Detecta teclas presionadas
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                AddKeyToBuffer(key);
            }
        }
    }

    void AddKeyToBuffer(KeyCode key)
    {
        inputBuffer.Add(key);

        // Si el buffer excede la secuencia, elimina el más antiguo
        if (inputBuffer.Count > correctSequence.Count)
        {
            inputBuffer.RemoveAt(0);
        }

        // Comprueba si la secuencia coincide
        if (IsSequenceCorrect())
        {
            Unlock();
        }
    }

    bool IsSequenceCorrect()
    {
        if (inputBuffer.Count != correctSequence.Count) return false;

        for (int i = 0; i < correctSequence.Count; i++)
        {
            if (inputBuffer[i] != correctSequence[i])
            {
                return false;
            }
        }
        return true;
    }

    void Unlock()
    {
        Debug.Log("¡Secuencia correcta! Todo desbloqueado.");
        // Aquí pones tu lógica para desbloquear el contenido
        manager.Unlock();
    }
}
