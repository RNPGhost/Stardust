﻿using UnityEngine;

public class CHealth : MonoBehaviour
{
	public float m_fMaxHealth;
	private float m_fCurrentHealth;

	public void DoDamage(float i_fDamageTaken)
	{
		m_fCurrentHealth -= i_fDamageTaken;
		if (m_fCurrentHealth <= 0)
		{
			m_fCurrentHealth = 0;
			// Planet destroyed
		}
	}

	private void Start()
	{
		m_fCurrentHealth = m_fMaxHealth;
	}
}
