using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 1. Added the "GooseModdingAPI" project as a reference.
// 2. Compile this.
// 3. Create a folder with this DLL in the root, and *no GooseModdingAPI DLL*
using GooseShared;
using SamEngine;

namespace DragGoose
{
    public class ModEntryPoint : IMod
    {

        Random rnd = new Random();
        // Gets called automatically, passes in a class that contains pointers to
        // useful functions we need to interface with the goose.
        void IMod.Init()
        {
            // Subscribe to whatever events we want
            InjectionPoints.PostTickEvent += PostTick;
        }

        public void PostTick(GooseEntity g)
        {
            if (IsMouseOnGoose(g) && Input.leftMouseButton.Held == true && g.currentTask != 4)
            {
                g.position = new Vector2(Input.mouseX-5, Input.mouseY);
                g.direction = g.direction+rnd.Next(-10, 10);
            }

        }

        public bool IsMouseOnGoose(GooseEntity g)
        {
            float xDif = g.position.x - Input.mouseX;
            float yDif = g.position.y - Input.mouseY;

            if (((-45 < xDif) && (xDif < 45)) && ((-45 < yDif) && (yDif < 45)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
