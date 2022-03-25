using FinalGame.Functions.Exceptions;
using FinalGame.Objects;
using FinalGame.Usable;
using System;
using System.Collections.Generic;

namespace FinalGame
{
    public class Player : IStats
    {
        private FightMenu menu = new FightMenu();
        private Dictionary<string, int> Stats = new Dictionary<string, int>()
        {
            { "HP" , 50 },{ "MAXHP" , 50 },{ "MP" , 10 },{ "MAXMP" , 10 },{ "STR" , 10 },{ "DEF" , 10 },{ "INT" , 10 },{ "AGI" , 10 }
        };
        private List<IUsable> Items = new List<IUsable>() { new ThrowingKnife(), new ThrowingKnife(), new HealthPotion(), new HealthPotion() };
        private List<IUsable> Skills = new List<IUsable>() { new Heal(), new CrossSlash(), new Fireball(), new ElectricPulse(), new WaterSpear() };
        private Level level = new Level();
        private Fight currentFight;
        private int LastSelection = 0;

        private bool Defending, Return;
        public Player(bool create = false)
        {
            if (create)
                level.AddStats(this);
        }

        public void Enter(Dungeon enteredDungeon)
        {
            menu.DrawFightMenu();
            menu.DrawStats(this);
            enteredDungeon.BeginFights(this);
        }

        public void PlayerTurn()
        {
            RegenerateMP(3);

            if (Defending)
                Defending = false;

            do
            {
                Return = false;
                SelectAction();
            }
            while (Return);
        }

        public void SelectAction()
        {
            menu.DrawFightMenu();

            try
            {
                string Action = menu.SelectAction();
                GetType().GetMethod(Action).Invoke(this, null);
            }
            catch (NoChoiceException) { Return = true; }
        }

        public void Attack()
        {
            try
            {
                Enemy target = SelectTarget(currentFight);
                target.Hurt(Calculate.HitDamage(this, target));
            }
            catch (NoChoiceException) { Return = true; }
        }

        public void Skill()
        {
            try
            {
                int index = menu.DrawUsable(Skills);
                Skills[index].Use(currentFight);
            }
            catch (NoChoiceException) { Return = true; }
        }
        public void Item()
        {

            try
            {
                int index = menu.DrawUsable(Items);
                Items[index].Use(currentFight);
                Items.RemoveAt(index);
            }
            catch (NoChoiceException) { Return = true; }
        }
        public void Defend()
        {
            Defending = true;
            RegenerateMP(5);
            Log.Send("* Player recovered some MP from Defending!");
        }

        public Enemy SelectTarget(Fight fight)
        {
            int CurrentSelection = LastSelection;
            List<Enemy> enemyList = fight.GetEnemyList();
            if (CurrentSelection > enemyList.Count - 1)
                CurrentSelection = enemyList.Count - 1;

            while (true)
            {
                enemyList[CurrentSelection].DrawSprite(FightMenu.HighlightColor);

                int PreviousSelection = CurrentSelection;
                switch (Controller.GetButton())
                {
                    case ConsoleKey.LeftArrow:
                        CurrentSelection--;
                        break;
                    case ConsoleKey.RightArrow:
                        CurrentSelection++;
                        break;
                    case ConsoleKey.Z:
                        LastSelection = CurrentSelection;
                        enemyList[CurrentSelection].DrawSprite();
                        return enemyList[CurrentSelection];
                    case ConsoleKey.X:
                        enemyList[CurrentSelection].DrawSprite();
                        throw new NoChoiceException();
                }
                if (CurrentSelection < 0 || CurrentSelection > enemyList.Count - 1)
                    CurrentSelection = PreviousSelection;

                if (PreviousSelection != CurrentSelection)
                    enemyList[PreviousSelection].DrawSprite();
            }
        }

        public void Heal(int Amount)
        {
            if (Stats["HP"] + Amount > Stats["MAXHP"])
                Amount = Stats["MAXHP"] - Stats["HP"];
            Stats["HP"] += Amount;
            menu.UpdateStat(this, "HP");
            Log.Send($"* Player recovered {Amount} HP. {Stats["HP"]} HP left.");
        }

        public void Hurt(int DMG)
        {
            if (Defending)
                DMG /= 2;

            Stats["HP"] -= DMG;

            menu.UpdateStat(this, "HP");

            if (DMG != 0)
                Log.Send($"* Player took {DMG} DMG. {Stats["HP"]} HP left.");
            else
                Log.Send("* Player dodged an attack!");
        }

        public bool CheckIfEnoughMP(int Amount)
        {
            if (Stats["MP"] >= Amount)
            {
                return true;
            }
            else
            {
                Log.Send($"Not enought MP to use skill.");
                Return = true;
                return false;
            }
        }

        public void DrainMana(int Amount)
        {
            Stats["MP"] -= Amount;
            menu.UpdateStat(this, "MP");
        }
        public void RegenerateMP(int Amount)
        {
            if (Stats["MP"] + Amount > Stats["MAXMP"])
                Amount = Stats["MAXMP"] - Stats["MP"];
            Stats["MP"] += Amount;
            menu.UpdateStat(this, "MP");
        }
        public void PickUp(IUsable item)
        {
            if (Items.Count == 6)
            {
                Log.Send("* Inventory is full.");
            }

            else
            {
                Log.Send($"* Obtained a {item.GetName()}");
                Items.Add(item);
            }
        }

        public void SetCurrentFight(Fight fight)
        {
            currentFight = fight;
        }

        public List<int> GetStats()
        {
            return new List<int> {
                Stats["HP"], Stats["MAXHP"],Stats["MP"] ,Stats["MAXMP"] ,Stats["STR"] ,Stats["DEF"] ,Stats["INT"] ,Stats["AGI"]
            };
        }
        public int GetStat(string key)
        {
            return Stats[key];
        }
        public void UpStat(string key, int amount)
        {
            Stats[key] += amount;
        }
        public int GetLvl()
        {
            return level.GetLevel();
        }
        public Level Lvl()
        {
            return level;
        }
        public void CheckIfDied()
        {
            if (Stats["HP"] <= 0)
                throw new PlayerDeadException();
        }
    }
}
