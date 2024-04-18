using UnityEngine;

public class ControladorDeSonidos : MonoBehaviour
{
    public AudioSource player1Sound; // Referencia al AudioSource del sonido del jugador 1
    public AudioSource player2Sound; // Referencia al AudioSource del sonido del jugador 2

    // Método para reproducir el sonido del jugador 1
    public void ReproducirSonidoPlayer1()
    {
        if (player1Sound != null)
        {
            player1Sound.Play();
        }
        else
        {
            Debug.LogWarning("No se encontró AudioSource para el sonido del jugador 1.");
        }
    }

    // Método para reproducir el sonido del jugador 2
    public void ReproducirSonidoPlayer2()
    {
        if (player2Sound != null)
        {
            player2Sound.Play();
        }
        else
        {
            Debug.LogWarning("No se encontró AudioSource para el sonido del jugador 2.");
        }
    }

    // Ejemplo de una función que controla cuándo reproducir cada sonido
    public void ControlarReproduccionDeSonidos(int jugador)
    {
        if (jugador == 1)
        {
            ReproducirSonidoPlayer1();
        }
        else if (jugador == 2)
        {
            ReproducirSonidoPlayer2();
        }
        else
        {
            Debug.LogWarning("Número de jugador no válido.");
        }
    }
}