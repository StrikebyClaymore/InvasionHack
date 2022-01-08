using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Factory;
using Assets.Scripts.Mobs;

namespace Assets.Scripts.Projectiles
{
	public class Projectile : MonoBehaviour
	{
		private Rigidbody _rb;
		private Collider _collider; 
		private ProjectileFactory _originFactory;
		private float moveSpeed;
		private int damage;
		private List<string> _ignoringCollisionTags = new List<string>(){"Area"};

		public ProjectileFactory OriginFactory
		{
			get => _originFactory;
			set => _originFactory = value;
		}

		private void Awake()
		{
			_rb = GetComponent<Rigidbody>();
			_collider = GetComponentInChildren<Collider>(true);
		}

		private void FixedUpdate()
		{
			var velocity = transform.forward * (moveSpeed * Time.fixedDeltaTime);
			//transform.Translate(velocity);
			_rb.MovePosition(transform.position + velocity);
		}

		public void Spawn(Vector3 pos, Quaternion rot, ProjectileData data)
		{
			AddIgnoreCollisionTags(data.ignoreCollisionTags);
			damage = data.damage;
			moveSpeed = data.moveSpeed;
			transform.position = pos;
			transform.rotation = rot;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (_ignoringCollisionTags.Contains(other.gameObject.tag))
				return;
			
			_collider.enabled = false;
			
			var hitble = other.gameObject.GetComponent<IHitble>();
			hitble?.GetHit(damage);

			_originFactory.Reclaim(this);
		}

		private void AddIgnoreCollisionTags(string[] ignoringTags)
		{
			foreach (var tag in ignoringTags)
			{
				if(!_ignoringCollisionTags.Contains(tag))
					_ignoringCollisionTags.Add(tag);
			}
		}
	}
}
