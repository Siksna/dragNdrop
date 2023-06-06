using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NomesanasVieta : MonoBehaviour,IDropHandler {

		private float vietasZrot, velkObjZRot, rotacijasStarpiba;
	private Vector2 vietasIzm, velkObjIzm;
	private float xIzmStarpiba, yIzmStarpiba;
	public Objekti objektuSkripts;
	public int MasinuSk=0;
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

                Debug.Log("Objektu rotācijas starpība: "+rotacijasStarpiba+"\nPlatuma starpība: "+xIzmStarpiba + "\nAugstuma starpība: " + yIzmStarpiba);


				if ((rotacijasStarpiba <= 6 && (xIzmStarpiba <= 0.15 && yIzmStarpiba <= 0.15) || (rotacijasStarpiba >= 354 && rotacijasStarpiba <= 360) && (xIzmStarpiba <= 0.15 && yIzmStarpiba <= 0.15)))
				{

					Debug.Log("Nomests pareizajā vietā!");
					MasinuSk++;
					objektuSkripts.vaiIstajaVieta = true;
					eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition=GetComponent<RectTransform>().anchoredPosition;
					eventData.pointerDrag.GetComponent<RectTransform>().localRotation = GetComponent<RectTransform>().localRotation;
					eventData.pointerDrag.GetComponent<RectTransform>().localScale = GetComponent<RectTransform>().localScale;

					switch (eventData.pointerDrag.tag)
					{
						case "Atkritumi":
							objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[1]);
								break;
                        case "Atrie":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[2]);
                            break;
                        case "Buss":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[3]);
                            break;
					case "b2":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[4]);
						break;
					case "Cementa":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[5]);
						break;
					case "e46":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[6]);
						break;
					case "e61":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[7]);
						break;
					case "Eskavators":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[8]);
						break;
					case "Policija":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[9]);
						break;
					case "Traktors1":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[10]);
						break;
					case "Traktors5":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[11]);
						break;
					case "Ugunsdzeseji":
						objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanasKoAtskanot[12]);
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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
