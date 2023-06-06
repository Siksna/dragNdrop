using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UzvarasEkrans : MonoBehaviour {
	public GameObject Zvaigznes[];
		public int laiks = 0;


	void Start()
	{
		StartCoroutine(time());
	}

	IEnumerator time()
	{
		while (true)
		{


			timeCount();
		yield return new WaitForSeconds(1);
	}
}

void timeCount()
{
	laiks += 1;
}
    public void SpelesBeigsana()
	{
		if (NomesanasVieta.MasinuSk == 12)
		{

			if (laiks<=100)
			{
                Zvaigznes[0].setActive(true);
                Zvaigznes[1].setActive(true);
                Zvaigznes[2].setActive(true);
            }
			if (laiks>100 && laiks<=150)
			{
                Zvaigznes[0].setActive(true);
                Zvaigznes[1].setActive(true);
            }
			if(laiks>150)
			{
                Zvaigznes[0].setActive(true);
            }
		}
	}
		}