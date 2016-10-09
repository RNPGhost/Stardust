﻿using UnityEngine;

public class CAsteroidDestruction : MonoBehaviour
{
	public float m_fDamageDealt;
	public int m_iPointsAwarded;
	public GameObject m_tExplosionVFX;
	public GameObject m_tImpactVFX;

	private void OnCollisionEnter(Collision i_tCollision)
	{
		// If we hit something with health, do damage to it
		CHealth tHealth = i_tCollision.gameObject.GetComponent<CHealth>();
		if (tHealth != null)
		{
			i_tCollision.gameObject.GetComponent<CHealth>().DoDamage(m_fDamageDealt);
		}

		// TODO: Use point of collision to set the rotation of the vfx
		Quaternion tVFXRotation = new Quaternion(0, 0, 0, 0);

		DestroySelf(m_tImpactVFX, tVFXRotation);
    }
	
	private void OnTouchDown()
	{
		CScoreController tScoreController = CScoreController.Instance;

		Debug.Assert(tScoreController != null, "CAsteroidDestruction::OnMouseDown: Score Controller hasn't been initialized");
		if (tScoreController != null)
		{
			CScoreController.Instance.IncreaseScore(m_iPointsAwarded);
		}

		DestroySelf(m_tExplosionVFX, transform.rotation);
	}
	
	private void DestroySelf(GameObject i_tVFXObject, Quaternion i_tVFXRotation)
	{
		// Create VFX
		Instantiate(i_tVFXObject, transform.position, i_tVFXRotation);

		Destroy(gameObject);
	}
}
