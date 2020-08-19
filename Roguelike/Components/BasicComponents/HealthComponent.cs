using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Components.BasicComponents
{
    class HealthComponent : Component
    {
        public int Health;
        public int MaxHealth;

        public HealthComponent(Entity entity) : base(entity)
        {
        }
    }
}
