using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class EMWaveHelper : MonoBehaviour
{
	public GameObject Invoker;

	private float transparency;
	private float radius;
	private float timeTraversed;

    // Start is called before the first frame update
    void Start()
    {
		initTransform();
    }

    // Update is called once per frame
    void Update()
    {
		radius += LightSpeed * Time.deltaTime;
		float scale = radius / 25;
		gameObject.transform.localScale = new Vector3(scale, scale, 1);

		Color color = gameObject.GetComponent<SpriteRenderer>().color;
		timeTraversed += Time.deltaTime;
		color.a = Mathf.Pow(2, -timeTraversed);
		gameObject.GetComponent<SpriteRenderer>().color = color;

		gameObject.GetComponent<CircleCollider2D>().radius = radius;
    }

	private void initTransform()
	{
		gameObject.transform.position = Invoker.transform.position;
		radius = 0.25f;
	}
}
