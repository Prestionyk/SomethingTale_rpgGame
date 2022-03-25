
using FinalGame.Usable;

namespace FinalGame
{
    class HealthPotion : IUsable
    {
        private string Name;
        public HealthPotion()
        {
            Name = "Health Potion";
        }

        public string GetName() { return Name; }

        public void Use(Fight fight)
        {
            fight.GetPlayer().Heal(30);
        }
    }
}
