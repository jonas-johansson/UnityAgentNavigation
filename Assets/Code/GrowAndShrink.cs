using UnityEngine;
using System.Collections;

public class GrowAndShrink : MonoBehaviour
{
	Vector3 m_scaleAtStart;

	void Start()
	{
		m_scaleAtStart = transform.localScale;
	}

	void Update()
	{
		float multiplier = Mathf.Sin(Time.time * 4.0f) * 0.25f + 0.75f;
		transform.localScale = m_scaleAtStart * multiplier;
	}
}
