using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D rb;

    public void OnPlay()
	{
		rb.bodyType = RigidbodyType2D.Dynamic;
	}
}
