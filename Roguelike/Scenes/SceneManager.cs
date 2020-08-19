using Microsoft.Xna.Framework;
using Roguelike.Scenes.Scenes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Scenes
{
    public class SceneManager : IEnumerable<Scene>, IEnumerable
    {
        public List<Scene> Scenes;

        public SceneManager()
        {
            Scenes = new List<Scene>();
            Gameplay game = new Gameplay();
            Scenes.Add(game);
        }

        public void Update()
        {
            int i = 0;
            foreach (Scene s in Scenes)
            {
                if (s.IsOver)
                {
                    Scenes.RemoveAt(i);
                    i--;
                }else
                    s.Update();
                i++;
            }
        }
        public  void Render()
        {
            foreach (Scene s in Scenes)
                s.Render();
        }

        public void DebugRender()
        {
            foreach (Scene s in Scenes)
                s.DebugRender();
        }

        public IEnumerator<Scene> GetEnumerator()
        {
            return Scenes.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
