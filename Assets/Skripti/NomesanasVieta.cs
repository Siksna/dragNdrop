using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NomesanasVieta : MonoBehaviour,IDropHandler {

		private float vietasZrot, velkObjZRot, rotacijasStarpiba;
	private Vector2 vietasIzm, velkObjIzm;
	private float xIzmStarpiba, yIzmStarpiba;
	[HideInInspector]
	public Objekti objektuSkripts;
	public static int MasinuSk=0;
	public int laiksH,laiksM,laiksS;

	[HideInInspector]
	public int laiks = 0;
    public void OnDrop(PointerEventData eventData)
    {
       if(eventData.pointerDrag!=null)
		{
			if(eventData.pointerDrag.tag.Equals(tag))
			{
				vietasZrot = eventData.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;

				velkObjZRot=GetComponent<RectTransform>().transform.eulerAngles.z;

				rotacijasStarpiba=Mathf.Abs(vietasZrot-velkObjZRot);

				vietasIzm = eventData.pointerDrag.GetComponent<RectTransform>().localScale;

				velkObjIzm=GetComponent<RectTransform>().localScale;

				xIzmStarpiba = Mathf.Abs(vietasIzm.x - velkObjIzm.x);
                yIzmStarpiba = Mathf.Abs(vietasIzm.y - velkObjIzm.y);

                Debug.Log("Objektu rotācijas starpība: "+rotacijasStarpiba+"\nPlatuma starpība: "+xIzmStarpiba + "\nAugstuma starpība: " + yIzmStarpiba+"\nMasinu skaits: "+MasinuSk);


				if ((rotacijasStarpiba <= 6 && (xIzmStarpiba <= 0.05 && yIzmStarpiba <= 0.05) || (rotacijasStarpiba >= 354 && rotacijasStarpiba <= 360) && (xIzmStarpiba <= 0.05 && yIzmStarpiba <= 0.05))) {

					//Skaita maśínas lídz kamér ir 12 ievietotas maśínas pareizajás vietás un tad padod zińu ka var aktivizét uzvaras ekránu
					MasinuSk+=1;
					if (MasinuSk == 12) {
						//Iesledz uzvaras ekranu
						objektuSkripts.UzvarasLogs.SetActive(true);
						//Laiku konvertacijas
						laiksH = laiks / 3600;
						laiksM = laiks / 60;
						laiksS = laiks-laiksM*60;
						//Laiku izvade
						objektuSkripts.LaikaTeksts.GetComponent<Text>().text ="Jūsu laiks\n"+laiksH.ToString()+":"+laiksM.ToString()+":"+laiksS.ToString();

						//ja laiks mazáks par 100 tad bus iedotas 3 zvaigznes
						if (laiks<=100)
						{
							objektuSkripts.Zvaigznes[0].SetActive(true);
							objektuSkripts.Zvaigznes[1].SetActive(true);
							objektuSkripts.Zvaigznes[2].SetActive(true);
						}
						//Ja laiks ir vairak par 100 un mazak vai vienadi ar 150 tad tiks iedotas 2 zvaigznes
						if (laiks>100 && laiks<=150)
						{
							objektuSkripts.Zvaigznes[0].SetActive(true);
							objektuSkripts.Zvaigznes[1].SetActive(true);
						}
						//Ja laiks ir vairak par 150 tad tiks iedota 1 zvaigzne
						if(laiks>150)
						{
							objektuSkripts.Zvaigznes[0].SetActive(true);
						}
					}
					Debug.Log("Nomests pareizajā vietā!"+MasinuSk);
					objektuSkripts.vaiIstajaVieta = true;
					eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition=GetComponent<RectTransform>().anchoredPosition;
					eventData.pointerDrag.GetComponent<RectTransform>().localRotation = GetComponent<RectTransform>().localRotation;
					eventData.pointerDrag.GetComponent<RectTransform>().localScale = GetComponent<RectTransform>().localScale;

					switch (eventData.pointerDrag.tag)
					{
						case "Atkritumi":
							objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[0]);
								break;
                        case "Atrie":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[1]);
                            break;
                        case "Buss":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[2]);
                            break;
					case "b2":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[3]);
						break;
					case "Cementa":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[4]);
						break;
					case "e46":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[5]);
						break;
					case "e61":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[6]);
						break;
					case "Eskavators":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[7]);
						break;
					case "Policija":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[8]);
						break;
					case "Traktors1":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[9]);
						break;
					case "Traktors5":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[10]);
						break;
					case "Ugunsdzeseji":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[11]);
						break;
						default:
							Debug.Log("Tags nav definēts!");
							break;

                    }

                }
			}
			//Ja tagi nesakrti tatad nepareiza vieta
			else
			{
				objektuSkripts.vaiIstajaVieta = false;
				objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[0]);

                switch (eventData.pointerDrag.tag)
                {
                    case "Atkritumi":
						objektuSkripts.AtkritumuMasina.GetComponent<RectTransform>().localPosition = objektuSkripts.atkrMKoord;
                        break;
                    case "Atrie":
                        objektuSkripts.AtraPalidziba.GetComponent<RectTransform>().localPosition = objektuSkripts.atrPKoord;
                        break;
                    case "Buss":
                        objektuSkripts.Autobuss.GetComponent<RectTransform>().localPosition = objektuSkripts.bussKoord;
                        break;
				case "b2":
					objektuSkripts.b2.GetComponent<RectTransform>().localPosition = objektuSkripts.b2Koord;
					break;
				case "Cementa":
					objektuSkripts.CementaMasina.GetComponent<RectTransform>().localPosition = objektuSkripts.CementaKoord;
					break;
				case "e46":
					objektuSkripts.e46.GetComponent<RectTransform>().localPosition = objektuSkripts.e46Koord;
					break;
				case "e61":
					objektuSkripts.e61.GetComponent<RectTransform>().localPosition = objektuSkripts.e61Koord;
					break;
				case "Eskavators":
					objektuSkripts.Eskavators.GetComponent<RectTransform>().localPosition = objektuSkripts.EskavatoraKoord;
					break;
				case "Policija":
					objektuSkripts.Policija.GetComponent<RectTransform>().localPosition = objektuSkripts.PolicijasKoord;
					break;
				case "Traktors1":
					objektuSkripts.Traktors1.GetComponent<RectTransform>().localPosition = objektuSkripts.Traktors1Koord;
					break;
				case "Traktors5":
					objektuSkripts.Traktors5.GetComponent<RectTransform>().localPosition = objektuSkripts.Traktors5Koord;
					break;
				case "Ugunsdzeseji":
					objektuSkripts.Ugunsdzeseji.GetComponent<RectTransform>().localPosition = objektuSkripts.UgunsdzesejiKoord;
					break;
                    default:
                        Debug.Log("Tags nav definēts!");
                        break;

                }
            }
		}

    }

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
		
	public void RestartetSpeli(){
		//Nospieźot pogu tiks restarteta spele un mainigie tiks parveidoti atpakal uz 0
		SceneManager.LoadScene("PilsetasKarte", LoadSceneMode.Single);
		MasinuSk = 0;
		laiks = 0;
	}

}
	
	
	// Update is called once per frame
	
