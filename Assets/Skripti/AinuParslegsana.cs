using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AinuParslegsana : MonoBehaviour
{

    // Use this for initialization
    public void UzSakumu()
    {
        SceneManager.LoadScene("Sakums", LoadSceneMode.Single);
    }

    public void UzSpeli()
    {
        SceneManager.LoadScene("PilsetasKarte", LoadSceneMode.Single);
    }

    public void Iziet()
    {
        Application.Quit();
    }

}
