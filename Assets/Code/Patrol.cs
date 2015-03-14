using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Patrol : MonoBehaviour
{
	[SerializeField]
	List<GameObject> m_patrolPoints = new List<GameObject>();

	[SerializeField]
	TextMesh m_statusText;

	NavMeshAgent m_agent;

	void Start()
	{
		m_agent = GetComponent<NavMeshAgent>();

		StartCoroutine(PatrolSequence());
	}

	IEnumerator PatrolSequence()
	{
		while (true)
		{
			foreach (var patrolPoint in m_patrolPoints)
			{
				// Move to patrol point
				m_agent.destination = patrolPoint.transform.position;
				m_statusText.text = "Checking " + patrolPoint.name;

				while (!AtDestination())
					yield return null;

				// Wait for a moment
				yield return new WaitForSeconds(2.0f);
			}
		}
	}

	bool AtDestination()
	{
		return m_agent.hasPath && m_agent.remainingDistance <= 0.5f;
	}
}
