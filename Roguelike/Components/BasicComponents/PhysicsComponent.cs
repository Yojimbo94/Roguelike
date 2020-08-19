using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Components.BasicComponents
{
    class PhysicsComponent : Component
    {
        public Vector2 Acceleration;
        public Vector2 Velocity;
        public Vector2 Mass;


        public PhysicsComponent(Entity entity) : base(entity)
        {
        }
    }
}
