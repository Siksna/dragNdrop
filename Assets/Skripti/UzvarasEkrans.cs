using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UzvarasEkrans : MonoBehaviour {
	public GameObject[] Zvaigznes;
	public GameObject UzvarasLogs;
	public GameObject LaikaTeksts;
	public NomesanasVieta BeiguEkrans;

	[HideInInspector]
		public int laiks = 0;

	//Saks skaitit laiku
	void Start()
	{
		StartCoroutine(time());
	}


	//kamér patiess skaita laiku ik péc 1 sekundes ĺauj mainít vértíbu
	IEnumerator time()
	{
		while (true)
		{


			timeCount();
		yield return new WaitForSeconds(1);
	}
}

	//Skaita pa vienam laiku
void timeCount()
{
	laiks += 1;
}

    public void SpelesBeigsana()
	{
		//Kad tiek sasniegtas 12 pareizi ievietotas masinas tika padota zina ka var aktivizet beigu ekranu un beigu ekrans padara sevi redzamu
		if (BeiguEkrans.AktivizetBeiguEkranu==true){
			Debug.Log ("Spele pabeigta");
			UzvarasLogs.SetActive(true);

			//No saskaitíta laika tiks izvadits laiks péc datuma formáta
			LaikaTeksts.GetComponent<Text>().text =laiks.ToString(@"hh\:mm\:ss\:fff");
			
			//ja laiks mazáks par 100 tad bus iedotas 3 zvaigznes
			if (laiks<=100)
			{
                Zvaigznes[0].SetActive(true);
				Zvaigznes[1].SetActive(true);
				Zvaigznes[2].SetActive(true);
            }
			//Ja laiks ir vairak par 100 un mazak vai vienadi ar 150 tad tiks iedotas 2 zvaigznes
			if (laiks>100 && laiks<=150)
			{
				Zvaigznes[0].SetActive(true);
				Zvaigznes[1].SetActive(true);
            }
			//Ja laiks ir vairak par 150 tad tiks iedota 1 zvaigzne
			if(laiks>150)
			{
				Zvaigznes[0].SetActive(true);
            }
		}
	}
	//Nospieźot pogu tiks restarteta spele
	public void RestartetSpeli(){
		SceneManager.LoadScene("PilsetasKarte", LoadSceneMode.Single);
	}
		}