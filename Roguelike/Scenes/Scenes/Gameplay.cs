using Roguelike.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Scenes.Scenes
{
    public class Gameplay : Scene
    {
        private Level _currentLevel;
        public Gameplay()
        {
            _currentLevel = new Level();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Render()
        {
            base.Render();
        }
    }
}
