using UnityEngine;
using System.Collections;

public class NavigateToDestination : MonoBehaviour
{
	[SerializeField]
	GameObject m_destination;

	NavMeshAgent m_agent;

	void Start()
	{
		m_agent = GetComponent<NavMeshAgent>();
		SetAgentColorToDestinationColor();
	}

	void SetAgentColorToDestinationColor()
	{
		var agentRenderer = GetComponentInChildren<Renderer>();
		agentRenderer.material = m_destination.renderer.material;
	}

	void Update()
	{
		m_agent.SetDestination(m_destination.transform.position);
	}
}
