using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky.Monogame.Blocks
{
    class Car
    {
        public string Owner;
        public string CarNumber;
    }

    class Bus : Car
    {
        public int BusNumber;
    }

    class Taxi : Car
    {
        public int Tax;
    }

    class pro
    {
        //public string A(Car car) =>
        //    car switch{
        //    Bus b => $"{b.BusNumber}번 버스입니다~"
        //    Taxi t => $"{t.Tax}원 요금입니다"
        //    Car c when c.Owenr == "류근찬" => $"갓갓 VIP 류근찬님 자동차입니다"
        //    _ => "ㅎ... 누구세요...?"
        //};

        public string A(Car car)
        {
            switch (car)
            {
                case Bus b:
                    return $"{b.BusNumber}번 버스입니다~";
                case Taxi t:
                    return $"{t.Tax}원 요금입니다";
                case Car c when c.Owner == "류근찬":
                    return "갓갓 VIP 류근찬님 자동차입니다";
                default:
                    return string.Empty;
            }
        }
    }
}
