using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NullSave.TOCK.Stats
{
    public class ProjectileLauncher : MonoBehaviour
    {

        #region Variables

        public Projectile projectile;
        public Transform projectileSpawn;
        public float launchInterval = 5f;
        public float spawnDelay = 1f;

        private float launchElapsed, spawnElapsed;
        private Projectile curProjectile;

        #endregion

        #region Unity Methods

        private void Update()
        {
            if (curProjectile == null)
            {
                spawnElapsed += Time.deltaTime;
                if (spawnElapsed >= spawnDelay)
                {
                    curProjectile = Instantiate(projectile, projectileSpawn);
                    spawnElapsed = 0;
                }
            }
            else
            {
                launchElapsed += Time.deltaTime;
                if (launchElapsed >= launchInterval)
                {
                    curProjectile.Launch();
                    curProjectile = null;
                    launchElapsed = 0;
                }
            }
        }

        #endregion

    }
}