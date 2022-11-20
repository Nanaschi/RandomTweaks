using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var spawner = new Spawner();
            
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{spawner.GetRandomEnemy().EnemyType} ");
            }
        }
    }

    public class Enemy
    {
        private EnemyType _enemyType;

        public EnemyType EnemyType => _enemyType;

        public int ChanceToSpawn => _chanceToSpawn;

        private int _chanceToSpawn;

        public Enemy(EnemyType enemyType, int chanceToSpawn)
        {
            _enemyType = enemyType;
            _chanceToSpawn = chanceToSpawn;
        }
        
        public Enemy(EnemyType enemyType)
        {
            _enemyType = enemyType;
        }
    }

    public enum EnemyType
    {
        Empty,
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }
}

public class Spawner
{
    private List<Enemy> _enemies = new List<Enemy>()
    {
        new Enemy(EnemyType.Common, 10),
        new Enemy(EnemyType.Uncommon, 3),
        new Enemy(EnemyType.Rare,2),
        new Enemy(EnemyType.Epic, 1)
    };

    private Random _random;
    private int totalChanceToSpawn;

    public Spawner()
    {
        _random = new Random();
        foreach (var enemy in _enemies)
        {
            totalChanceToSpawn += enemy.ChanceToSpawn;
        }
    }

    public Enemy GetRandomEnemy()
    {
        
        
        Enemy firstOrDefaultEnemy = _enemies.FirstOrDefault
            (enemy => (((float)enemy.ChanceToSpawn/ totalChanceToSpawn)).IsSatisfiedPercent()) ?? new Enemy(EnemyType.Empty);
        
        return firstOrDefaultEnemy;
    }

    public bool GetSatisfied()
    {
        Enemy check = _enemies.FirstOrDefault(enemy => enemy.EnemyType == EnemyType.Rare);
        var chance = (float)check.ChanceToSpawn / totalChanceToSpawn;
        Console.WriteLine(chance);
        return chance.IsSatisfiedPercent();
    }
}