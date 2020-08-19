using Microsoft.Xna.Framework;
using Roguelike.Components;
using Roguelike.Scenes;
using Roguelike.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Entity : IEnumerable<Component>, IEnumerable
    {

        public bool Active = true;

        public Scene Scene { get; private set; }
        public List<Component> Components { get; private set; }

        private int _ID;
        private int _depth = 0;


        public Entity()
        {
            Components = new List<Component>();
        }
        


        //Appelé uniquement Entity Active == true
        public virtual void Update()
        {
            foreach (Component c in Components)
            {
                c.Update();
            }
        }

        //Appelé uniquement si Entity Visible == true
        public virtual void Render()
        {
            foreach (Component c in Components)
            {
                c.Render();
            }
        }

        public virtual void DebugRender()
        {
            foreach (Component c in Components)
            {
                c.RenderDebug();
            }
        }
       


        public int Depth
        {
            get { return _depth; }
            set
            {
                if (_depth != value)
                {
                    _depth = value;
                    //if (Scene != null)
                    //    Scene.SetActualDepth(this);
                }
            }
        }

        public int ID { get => _ID; set => _ID = value; }


        /*
        public Collider Collider
        {
            get { return collider; }
            set
            {
                if (value == collider)
                    return;

                if (collider != null)
                    collider.Removed();
                collider = value;
                if (collider != null)
                    collider.Added(this);
            }
        }

        public float Width
        {
            get
            {
                if (collider == null)
                    return 0;
                else
                    return collider.Width;
            }
        }

        public float Height
        {
            get
            {
                if (collider == null)
                    return 0;
                else
                    return collider.Height;
            }
        }

        public float Left
        {
            get
            {
                if (collider == null)
                    return X;
                else
                    return Position.X + collider.Left;
            }

            set
            {
                if (collider == null)
                    Position.X = value;
                else
                    Position.X = value - collider.Left;
            }
        }

        public float Right
        {
            get
            {
                if (collider == null)
                    return Position.X;
                else
                    return Position.X + collider.Right;
            }

            set
            {
                if (collider == null)
                    Position.X = value;
                else
                    Position.X = value - collider.Right;
            }
        }

        public float Top
        {
            get
            {
                if (collider == null)
                    return Position.Y;
                else
                    return Position.Y + collider.Top;
            }

            set
            {
                if (collider == null)
                    Position.Y = value;
                else
                    Position.Y = value - collider.Top;
            }
        }

        public float Bottom
        {
            get
            {
                if (collider == null)
                    return Position.Y;
                else
                    return Position.Y + collider.Bottom;
            }

            set
            {
                if (collider == null)
                    Position.Y = value;
                else
                    Position.Y = value - collider.Bottom;
            }
        }

        public float CenterX
        {
            get
            {
                if (collider == null)
                    return Position.X;
                else
                    return Position.X + collider.CenterX;
            }

            set
            {
                if (collider == null)
                    Position.X = value;
                else
                    Position.X = value - collider.CenterX;
            }
        }

        public float CenterY
        {
            get
            {
                if (collider == null)
                    return Position.Y;
                else
                    return Position.Y + collider.CenterY;
            }

            set
            {
                if (collider == null)
                    Position.Y = value;
                else
                    Position.Y = value - collider.CenterY;
            }
        }

        public Vector2 TopLeft
        {
            get
            {
                return new Vector2(Left, Top);
            }

            set
            {
                Left = value.X;
                Top = value.Y;
            }
        }

        public Vector2 TopRight
        {
            get
            {
                return new Vector2(Right, Top);
            }

            set
            {
                Right = value.X;
                Top = value.Y;
            }
        }

        public Vector2 BottomLeft
        {
            get
            {
                return new Vector2(Left, Bottom);
            }

            set
            {
                Left = value.X;
                Bottom = value.Y;
            }
        }

        public Vector2 BottomRight
        {
            get
            {
                return new Vector2(Right, Bottom);
            }

            set
            {
                Right = value.X;
                Bottom = value.Y;
            }
        }

        public Vector2 Center
        {
            get
            {
                return new Vector2(CenterX, CenterY);
            }

            set
            {
                CenterX = value.X;
                CenterY = value.Y;
            }
        }

        public Vector2 CenterLeft
        {
            get
            {
                return new Vector2(Left, CenterY);
            }

            set
            {
                Left = value.X;
                CenterY = value.Y;
            }
        }

        public Vector2 CenterRight
        {
            get
            {
                return new Vector2(Right, CenterY);
            }

            set
            {
                Right = value.X;
                CenterY = value.Y;
            }
        }

        public Vector2 TopCenter
        {
            get
            {
                return new Vector2(CenterX, Top);
            }

            set
            {
                CenterX = value.X;
                Top = value.Y;
            }
        }

        public Vector2 BottomCenter
        {
            get
            {
                return new Vector2(CenterX, Bottom);
            }

            set
            {
                CenterX = value.X;
                Bottom = value.Y;
            }
        }
        */

        //Nécessaires pour faire fonctionner IEnumarable. Peut bug parce que Components est un type perso à la base (CompontentList)
        public IEnumerator<Component> GetEnumerator()
        {
            return Components.GetEnumerator();
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
