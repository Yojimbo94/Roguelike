using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Roguelike.Scenes
{
    public class Scene : IEnumerable<Entity>, IEnumerable
    {
        public List<Entity> Entities;
        public bool Active;
        public bool IsOver;

        public Scene()
        {
            Active = true;
            IsOver = false;
            Entities = new List<Entity>();
        }


        public virtual void Update()
        {
            foreach(Entity e in Entities)
                e.Update();
        }

        internal void DebugRender()
        {
            foreach (Entity e in Entities)
                e.DebugRender();
        }

        public virtual void Render()
        {
            foreach (Entity e in Entities)
                e.Render();
        }
        public IEnumerator<Entity> GetEnumerator()
        {
            return Entities.GetEnumerator();
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
