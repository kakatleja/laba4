using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4._2
{
    internal class Time
    {
        // Поля
        private byte hours;
        private byte minutes;

        // Свойства с проверкой корректности
        public byte Hours
        {
            get => hours;
            set
            {
                if (value > 23) throw new ArgumentOutOfRangeException("Hours must be 0-23");
                hours = value;
            }
        }

        public byte Minutes
        {
            get => minutes;
            set
            {
                if (value > 59) throw new ArgumentOutOfRangeException("Minutes must be 0-59");
                minutes = value;
            }
        }

        // Конструкторы
        public Time(byte hours = 0, byte minutes = 0)
        {
            Hours = hours;
            Minutes = minutes;
        }

        // Перегрузка ToString для вывода
        public override string ToString()
        {
            return $"{hours:D2}:{minutes:D2}";
        }

        // Шестое задание
        public Time Subtract(Time t)
        {
            int totalMinutes1 = this.hours * 60 + this.minutes;
            int totalMinutes2 = t.hours * 60 + t.minutes;
            int diff = totalMinutes1 - totalMinutes2;
            if (diff < 0) diff += 24 * 60; // переход в предыдущие сутки
            byte h = (byte)(diff / 60);
            byte m = (byte)(diff % 60);
            return new Time(h, m);
        }

        // Седьмое задание
        public static Time operator ++(Time t)
        {
            int totalMinutes = t.hours * 60 + t.minutes + 1;
            if (totalMinutes >= 24 * 60) totalMinutes -= 24 * 60;
            return new Time((byte)(totalMinutes / 60), (byte)(totalMinutes % 60));
        }

        public static Time operator --(Time t)
        {
            int totalMinutes = t.hours * 60 + t.minutes - 1;
            if (totalMinutes < 0) totalMinutes += 24 * 60;
            return new Time((byte)(totalMinutes / 60), (byte)(totalMinutes % 60));
        }

        // Приведение типов
        public static implicit operator int(Time t)
        {
            return t.hours * 60 + t.minutes;
        }

        public static explicit operator bool(Time t)
        {
            return t.hours != 0 || t.minutes != 0;
        }

        // Бинарные операции сравнения
        public static bool operator <(Time t1, Time t2)
        {
            return ((int)t1) < ((int)t2);
        }

        public static bool operator >(Time t1, Time t2)
        {
            return ((int)t1) > ((int)t2);
        }

    }
}
