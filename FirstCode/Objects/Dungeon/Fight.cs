using System.Collections.Generic;
using System.Threading;

namespace FinalGame
{
    public class Fight
    {
        private List<Enemy> enemyList = new List<Enemy>();
        private bool Clear = false;
        private Player player;
        private int TurnCount = 0;

        public Fight() { }
        public static Fight operator +(Fight fight, Enemy enemy)
        {
            fight.enemyList.Add(enemy);
            return fight;
        }

        public List<Enemy> GetEnemyList() { return enemyList; }
        public Player GetPlayer() { return player; }

        public void Start(Player player)
        {
            this.player = player;
            player.SetCurrentFight(this);

            DrawEnemies();
            while (!Clear)
            {
                Turn();
                if (enemyList.Count == 0)
                    Clear = true;
            }
        }

        public void Turn()
        {
            TurnCount++;
            Log.Send($"----- Turn {TurnCount} -----");

            player.PlayerTurn();

            for (int i = 0; i < enemyList.Count; i++)
            {
                Enemy enemy = enemyList[i];
                if (enemy.CheckIfDied())
                {
                    enemy.ClearSpriteAndHPBar();
                    enemy.DropReward(player);
                    enemyList.Remove(enemy);
                    --i;
                    continue;
                }
            }

            for (int i = 0; i < enemyList.Count; i++)
            {
                Thread.Sleep(500);
                Enemy enemy = enemyList[i];
                enemy.Attack(player);

                player.CheckIfDied();
            }

            Log.Send("");
            Thread.Sleep(300);
        }

        public void DrawEnemies()
        {
            int EnemyPos = 15;
            int totalWidth = 0;
            foreach (Enemy e in enemyList)
                totalWidth += e.GetSpriteWidth();
            int DistanceBetweenEnemies = (52 - totalWidth) / (enemyList.Count + 1);

            foreach (Enemy enemy in enemyList)
            {
                EnemyPos += DistanceBetweenEnemies;
                enemy.SetPosition(EnemyPos, 15 - enemy.GetSpriteLength() / enemy.GetSpriteWidth());
                enemy.DrawSprite();
                enemy.DrawHPBar();
                EnemyPos += enemy.GetSpriteWidth() + 1;
            }

        }

    }
}
