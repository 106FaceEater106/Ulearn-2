using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    /*
    public class Settings {
        public int HeightMap(){
            return Game.MapHeight;
        }

        public int WidthMap(){
            return Game.MapWidth;
        }

    }
    */

    // Task 1 Добавление двух классов Игрок и Поле
    //Напишите здесь классы Player, Terrain и другие.
    public class Player : ICreature  {
       //Координатные поля
        public static int X, Y = 0;
        public static int dX, dY = 0;

        // умер-> исчез -> игра продолжается...
       /* public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }
       
        
        public bool DeadInConflict(ICreature conflictedObject)
        {
           return false;
        }
        */
        public bool DeadInConflict(ICreature conflictedObject)
        {          
            var checkConflicted = conflictedObject.ToString();
            if (checkConflicted == "Digger.Gold"){
                Game.Scores += 10;
                }
            if (checkConflicted == "Digger.Sack" || checkConflicted == "Digger.Monster")
            {
                
                return true;
            }
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

            if (Game.Map[x + dX, y + dY] != null)
            {
                if (Game.Map[x + dX, y + dY].ToString() == "Digger.Sack")
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
    // класс реализующий мешок с золотом
    public class Sack : ICreature {
    
        public string GetImageFileName()
        {
            return "Sack.png";
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 5;
        }

       
        private CreatureCommand Fall()
        {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 1 };
        }

        private CreatureCommand DoNothing()
        {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }

        private int count = 0;
        public static bool checkDeadPlayer = false;

        public CreatureCommand Act(int x, int y)
        {
            if (y < Game.MapHeight - 1)
            {
                var map = Game.Map[x, y + 1];
                if (map == null || (count > 0 && (map.ToString() == "Digger.Player" || map.ToString() == "Digger.Monster")))
                {
                    count++;
                    return Fall();
                }
            }

            if (count > 1)
            {
                count = 0;
                return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };
            }
            count = 0;
            return DoNothing();
        }




    }
    // класс реализующий золото
    public class Gold : ICreature{
        public string GetImageFileName()
        {
            return "Gold.png";
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            var checkConflicted = conflictedObject.ToString();
            return (checkConflicted == "Digger.Player" || checkConflicted == "Digger.Monster");
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

    }

    // класс реализующий монстра 
     public class Monster : ICreature
     {
     

        public CreatureCommand Act(int x, int y)
        {
            int dx = 0;
            int dy = 0;

            if (IsPlayerAlive())
            {
                if (Player.X == x)
                {
                    if (Player.Y < y) dy = -1;
                    else if (Player.Y > y) dy = 1;
                }

                else if (Player.Y == y)
                {
                    if (Player.X < x) dx = -1;
                    else if (Player.X > x) dx = 1;
                }
                else
                {
                    if (Player.X < x) dx = -1;
                    else if (Player.X > x) dx = 1;
                }
            }
            else{
                return Stay();
                }

            if (!(x + dx >= 0 && x + dx < Game.MapWidth && y + dy >= 0 && y + dy < Game.MapHeight)){
                return Stay();
            }

            var map = Game.Map[x + dx, y + dy];
            if (map != null){
                if (map.ToString() == "Digger.Terrain" || map.ToString() == "Digger.Sack" || map.ToString() == "Digger.Monster"){
                    return Stay();
                }
            }
                    
            return new CreatureCommand() { 
                DeltaX = dx, DeltaY = dy
            };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            var checkConflicted = conflictedObject.ToString();
            return (checkConflicted == "Digger.Sack" || checkConflicted == "Digger.Monster");
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            return "Monster.png";
        }

        static private CreatureCommand Stay()
        {

            return new CreatureCommand() { 
                DeltaX = 0, DeltaY = 0 
            };
        }


        static private bool IsPlayerAlive()
        {
            for (int i = 0; i < Game.MapWidth; i++)
                for (int j = 0; j < Game.MapHeight; j++)
                {
                    var map = Game.Map[i, j];
                    if (map != null)
                    {
                        if (map.ToString() == "Digger.Player")
                        {
                            Player.X = i;
                            Player.Y = j;
                            return true;
                        }
                    }
                }
            return false;
        }
     }

}
