using Roguelike.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Components
{
    public abstract class Component
    {
        public Entity Entity { get; set; }

        public Component(Entity entity)
        { 
            Added(entity);
        }

        public virtual void Added(Entity entity)
        {
            Entity = entity;
        }

        public virtual void Removed(Entity entity)
        {
            Entity = null;
        }

        public virtual void Update()
        {

        }
        public virtual void Render()
        {

        }
        public virtual void RenderDebug()
        {

        }
    }
}
