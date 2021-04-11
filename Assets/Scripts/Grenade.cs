using UnityEngine;
using System.Collections;

public class Grenade : Projectile
{
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag(seekTag))
			Hit(col);
	}
}
