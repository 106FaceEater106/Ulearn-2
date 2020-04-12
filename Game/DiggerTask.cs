using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    //Напишите здесь классы Player, Terrain и другие.
    public class Player : ICreature{
       //Координатные поля
        public static int X, Y = 0;
        public static int dX, dY = 0;

        // умер-> исчез -> игра продолжается...
       /* public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }
        */
        
        public bool DeadInConflict(ICreature conflictedObject)
        {
           return false;
        }
        

        public CreatureCommand Act(int x, int y){
                X = x;
                Y = y;

            // input button

            switch(Game.KeyPressed){
                case System.Windows.Forms.Keys.Left:
                    dX = -1;
                    dY = 0;
                    break;
                case System.Windows.Forms.Keys.Up:
                    dX = 0;
                    dY = -1;
                    break;
                case System.Windows.Forms.Keys.Right:
                    dX = 1;
                    dY = 0;
                    break;
                case System.Windows.Forms.Keys.Down:
                    dX = 0;
                    dY = 1;
                    break;
                default:
                    Stay();
                    break;
            }
            var height = Game.MapHeight;
            var width = Game.MapWidth;
            
            //Запрет выхода за пределы карты 
            if (!(x + dX >= 0 && x + dX < width && y + dY >= 0 && y + dY < height)){
                Stay();
            }
            //возвращение следующих координат отрисовки
            return new CreatureCommand() { 
                DeltaX = dX, DeltaY = dY 
            };

        
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }

        private static void Stay()
        {
            dX = 0;
            dY = 0;
        }
        
    }

    public class Terrain : ICreature {

        // возращаем имя файла
        public string GetImageFileName(){
            return "Terrain.png";
        }
        // возвращаем координаты отрисовки 
        public CreatureCommand Act(int x, int y){
               return new CreatureCommand() {
                   DeltaX = 0, DeltaY = 0
               };    
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }

        public int GetDrawingPriority()
        {
            return 2;
        }
    }
}
