using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektuTransformacijas : MonoBehaviour
{

	public Objekti objektuSkripts;

	void Update()
	{
		if (objektuSkripts.PedejaisVilktais != null)
		{
			if (Input.GetKey(KeyCode.Z))
			{
				objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().Rotate(0, 0, Time.deltaTime * 40f);
			}
			if (Input.GetKey(KeyCode.X))
			{
				objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().Rotate(0, 0, -Time.deltaTime * 40f);
			}
			if (Input.GetKey(KeyCode.UpArrow))
			{
				if (objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y < 1f)
				{
					objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale = new Vector2(objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x, objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y + 0.002f);
				}

			}
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y >0.3f)
                {
                    objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale = new Vector2(objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x, objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y - 0.002f);
                }

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x < 1f)
                {
                    objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale = new Vector2(objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x+0.002f, objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y);
                }

            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x > 0.3f)
                {
                    objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale = new Vector2(objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x-0.002f, objektuSkripts.PedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y);
                }

            }
        }
	}
}
