using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    public class Player : ICreature
    {
        // J: Player может быть не один. Избавься от СТАТИЧЕСКИХ полей.
        // Кроме того, здесь можно вовсе обойтись без полей для player.
        public static int X, Y = 0;
        public static int dX, dY = 0;

        // умер-> исчез -> игра продолжается...
        public bool DeadInConflict(ICreature conflictedObject)
        {
            var checkConflicted = conflictedObject.ToString();
            if (checkConflicted == "Digger.Gold")
            {
                Game.Scores += 10;
            }

            if (checkConflicted == "Digger.Sack" || checkConflicted == "Digger.Monster")
            {
                return true;
            }

            return false;
        }


        // J: Это очень перегруженный задачами метод. Его стоит разбить на подзадачи
        // Так, в случае ошибки, можно будет легко понять где она.
        public CreatureCommand Act(int x, int y)
        {
            X = x;
            Y = y;

            // input button

            switch (Game.KeyPressed)
            {
                // J: System.Windows.Forms - излишне. Заимпорти (Using)
                case System.Windows.Forms.Keys.Left:
                    //J: Мы можем делегировать дальнейшее выполнение новому методу
                    //return Move(x, y, -1, 0)
                    // Возвращать он должен будет CreatureCommand
                    dX = -1;
                    dY = 0;
                    break;
                case System.Windows.Forms.Keys.Up:
                    //return Move(x, y, 1, 0)
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
            
            // Эта проверка тяжело читается. Стоит выделить метод для нее с говорящим именем.
            if (!(x + dX >= 0 && x + dX < width && y + dY >= 0 && y + dY < height))
            {
                Stay();
            }

            if (Game.Map[x + dX, y + dY] != null)
            {
                // J: Для проверки того, что объект Х имеет тип Type существует оператор X is Type
                
                // Проверка по изменчивому параметру, вроде имени текстуры - долгая, неудобно читается
                // и, в случае его изменения, придется искать его упоминания по всему коду.
                // Изменяющий может этого не знать, или знать не о всех местах, создаст ошибки.  
                
                // J: Исправь это всюду.
                if (Game.Map[x + dX, y + dY].ToString() == "Digger.Sack")
                    Stay();
            }

            //возвращение следующих координат отрисовки
            
            return new CreatureCommand() {DeltaX = dX, DeltaY = dY};
            // J: (не замечание)
            // Поясню значение этой строки. Это сокращенная форма инициализации объектов. 
            // Это ровно тоже, что и
            
            // var command = new CreatureCommand();
            // command.DeltaX = dX;
            // command.DeltaY = dY;
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }

        // J: Этот метод не совсем нужен.
        // Для того, чтобы оставить игрока на месте, достаточно возвращать new CreatureCommand(),
        // без аргументов, они будут назначены по умолчанию. Для чисел по умолчанию 0. 
        private static void Stay()
        {
            dX = 0;
            dY = 0;
        }
    }

    public class Terrain : ICreature
    {
        // возращаем имя файла
        public string GetImageFileName()
        {
            return "Terrain.png";
        }

        // возвращаем координаты отрисовки 
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand()
            {
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
    public class Sack : ICreature
    {
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

        // J: О, это очень хорошая идея.
        // Кстати, мы можем сделать это значение константой и дать название вроде FallCommand, StayCommand
        private CreatureCommand Fall()
        {
            return new CreatureCommand() {DeltaX = 0, DeltaY = 1};
        }

        private CreatureCommand DoNothing()
        {
            return new CreatureCommand() {DeltaX = 0, DeltaY = 0};
        }

        private int count = 0; // J: Название недостаточно подробно.  
        public static bool checkDeadPlayer = false; //J: Не используется

        public CreatureCommand Act(int x, int y)
        {
            if (y < Game.MapHeight - 1)
            {
                var map = Game.Map[x, y + 1]; // J: Вводящее в заблуждение название переменной. В ней лежит НЕ карта.
                if (map == null ||
                    (count > 0 && (map.ToString() == "Digger.Player" || map.ToString() == "Digger.Monster")))
                {
                    count++;
                    return Fall();
                }
            }

            if (count > 1)
            {
                count = 0;
                // J: Здесь можно вернуть по аналогии с Fall() и DoNothing()
                return new CreatureCommand() {DeltaX = 0, DeltaY = 0, TransformTo = new Gold()}; 
            }

            count = 0;
            return DoNothing();
        }
    }

    // класс реализующий золото
    public class Gold : ICreature
    {
        public string GetImageFileName()
        {
            return "Gold.png";
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand() {DeltaX = 0, DeltaY = 0};
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
        // J: Большой и перегруженный метод. См. рекомендации в Player
        public CreatureCommand Act(int x, int y)
        {
            int dx = 0;
            int dy = 0;

            // J: Можно сделать метод, возвращающий объект игрока или null  
            // Тогда не придется пользоваться статичными полями
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
            else
            {
                return Stay();
            }

            // Сложночитаемое условие, достойное метода
            if (!(x + dx >= 0 && x + dx < Game.MapWidth && y + dy >= 0 && y + dy < Game.MapHeight))
            {
                return Stay();
            }

            var map = Game.Map[x + dx, y + dy]; // Вводящее в заблуждение название
            if (map != null)
            {
                if (map.ToString() == "Digger.Terrain" || map.ToString() == "Digger.Sack" ||
                    map.ToString() == "Digger.Monster")
                {
                    return Stay();
                }
            }

            return new CreatureCommand()
            {
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

        // J: static принято писать После модификатора доступа
        static private CreatureCommand Stay()
        {
            return new CreatureCommand()
            {
                DeltaX = 0, DeltaY = 0
            };
        }


        static private bool IsPlayerAlive()
        {
            for (int i = 0; i < Game.MapWidth; i++)
            for (int j = 0; j < Game.MapHeight; j++)
            {
                var map = Game.Map[i, j]; // J: Вводящее в заблуждение название
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