using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HotelAccounting 
{
    class AccountingModel : ModelBase{
        
        private double price ; // цена за одну ночь
        private int nightsCount ; // количество ночей.
        private double discount ; //скидка в процентах 
        private double total ; //сумма счёта

        // используем  сеттеры(свойства) get - мы возвращаем значение поля 
        //set  - устанавливаем значение
     
       

            // Цена за ночь
        public double Price
        {
            get { return price; }
            set
            {
                if (value >= 0)
                    price = value; // значение у поля price всегда положительное.
                else throw new ArgumentException(); // поймали отрицательное число
                SetNewTotal();
                Notify(nameof(Price)); // уведомление
            }
        }

        //
        //
        // J: Пожалуйста, пиши { и } с новой строки. Это распространенное соглашение, по крайней мере в C#
        //
        //
        public int NightsCount{
            get {
                return nightsCount;
            }
            set{
                if(value > 0) 
                    nightsCount = value; // если было прошла ночь в отеле засчитываем
                else throw new ArgumentException(); // ошибка значения
                SetNewTotal();
                Notify(nameof(NightsCount)); 
            }
        }

       public double Discount{
            get{
                return discount;
            } 
            set{
                discount = value;
                
                // J: float и double хранят значения лишь приблизительно.
                // Пример:
                // var x = 0.01;
                // var y = 0.01;
                // if (x == y)
                //    Плохо. Может быть FALSE
                // if(Math.Abs(x - y) < ТОЧНОСТЬ)
                //    Лучше!
                if(discount != ((-1) * Total / (Price * NightsCount) + 1) * 100)
                   SetNewTotal();
                Notify(nameof(Discount));
            }
       }

        public double Total{
            get{
                return total;    
            }
            set{
            
                if(value > 0)
                    total = value;
                else throw new ArgumentException();
                if (total != Price * NightsCount * (1 - Discount / 100))
                     SetNewDiscount();
                Notify(nameof(Total));
            }
        }

        public AccountingModel(){
            price = 0;
            nightsCount = 1;
            discount = 0;
            total = 0;
        }

        private void SetNewTotal()
        {
            Total = Price * NightsCount * (1 - Discount / 100);
        }

        private void SetNewDiscount()
        {
            
            Discount = ((-1) * Total / (Price * NightsCount) + 1) * 100;
        }


    }


}
