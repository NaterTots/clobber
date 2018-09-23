﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
	public PlayerMovement playerMovement = PlayerMovement.KeyboardAndMouse;

	public MeleeWeapon meleeWeapon;
	public ProjectileWeapon projectileWeapon;

	private void Awake()
	{
		switch (playerMovement)
		{
			case PlayerMovement.KeyboardAndMouse:
				gameObject.AddComponent<KeyboardAndMouseMovement>().player = this;
				break;
			case PlayerMovement.TwinStick:
				gameObject.AddComponent<TwinStickMovement>().player = this;
				break;
			case PlayerMovement.SingleStickMoveAndFace:
				gameObject.AddComponent<SingleStickMoveAndFace>().player = this;
				break;
		}
	}

	private void Start()
	{
		//this will reset the weapons each room - move this so it only happens once when the game starts
		meleeWeapon.SetWeaponDefinition(PlayerInfo.Instance.startingMeleeWeapon);
		projectileWeapon.SetWeaponDefinition(PlayerInfo.Instance.startingProjectileWeapon);
	}

	public void AttackWithPrimary(Vector2 pos)
	{
		projectileWeapon.OnFire();
	}

	public void AttackWithSecondary(Vector2 pos)
	{
		meleeWeapon.Attack();
	}
}

public enum PlayerMovement
{
	TwinStick,
	KeyboardAndMouse,
	SingleStickMoveAndFace
}
