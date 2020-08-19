using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Components.BasicComponents
{
    class SpriteComponent : Component
    {
        public Texture2D Sheet;
        public int Sheet_Width;
        public int Sheet_Height;
        public int Width;
        public int Height;
        public int Nb_anim;

        public SpriteComponent(Entity entity, Texture2D sheet, int nb_anim) : base(entity)
        {
            Sheet = sheet;
            Nb_anim = nb_anim;
            Sheet_Width = sheet.Width;
            Sheet_Height = sheet.Height;
        }
    }
}
