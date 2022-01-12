using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Mobs.Enemies.SimpleCube
{
    public class SimpleCubeMovement : EnemyMovement
    {
        private Collider _collider;
        
        protected override void Start()
        {
            base.Start();
            _collider = GetComponent<Collider>();
            GenerateDirection();
        }

        private void GenerateDirection()
        {
            Quaternion ang;
            Vector3 dir;
            float dist = 14f;
            Vector3 pos = transform.position;
            List<Quaternion> angles = new List<Quaternion>();
            for (int i = 0; i < 36; i++){
                ang = Quaternion.Euler(0f, (float)i * 10, 0f);
                dir = ang * new Vector3(1f, 0f, 0f);
                RaycastHit hit;
                Physics.Raycast(pos, dir, out hit, dist, LayerMask.GetMask("Bounds"));
                if(hit.collider != null){
                    //Debug.DrawLine(pos, pos + (ang * new Vector3(hit.distance, 0f, 0f)), Color.red, 5f);
                    continue;
                }
                //Debug.DrawLine(pos, pos + dir, Color.green, 5f);
                angles.Add(ang);
            }
            
            if(angles.Count == 0)
                return;
        
            int dice = Random.Range(0, angles.Count);

            dir = angles[dice] * new Vector3(dist, 0f, 0f);
            //Debug.DrawLine(pos + new Vector3(0f, 0.1f, 0f), pos + dir + new Vector3(0f, 0.1f, 0f), Color.blue, 5f);

            transform.rotation = angles[dice];

            transform.LookAt(transform.position + dir);
            ChangeState(States.MoveToDirection);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.gameObject.GetComponent<SimpleCubeAttack>();
                if (enemy)
                {
                    enemy.Collapse(GetComponent<Enemy>());
                    Destroy(gameObject);
                }
            }
        }
    }
}
