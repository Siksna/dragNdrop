using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AinuParslegsana : MonoBehaviour
{

    // Aizved uz sákumu
    public void UzSakumu()
    {
        SceneManager.LoadScene("Sakums", LoadSceneMode.Single);
    }
	//Aizved uz speli
    public void UzSpeli()
    {
        SceneManager.LoadScene("PilsetasKarte", LoadSceneMode.Single);
    }
	//Iziet vispar no aplikácijas ára
    public void Iziet()
    {
        Application.Quit();
    }

}
