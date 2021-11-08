using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace padenie_2
{
    class Program
    {
        
            public const double G = 9.81, S = 0.00090, Cx = 0.5, p = 1.2;
            public static double m, h, V, dt, a, t, V0, h0, h_first,g;
            static void Main(string[] args)
        {
                Console.Write("Данные значения: ");
                Console.WriteLine($"\n Maccа тела m= {m}кг  Плотность воздуха p= {p}кг/м^3  Площадь поперечного сечения S= {S}м^2");
                Console.WriteLine($" Коэффициент лобового аэродинамического сопротивления Cx= {Cx}  Ускорение свободного падения g= {G}м/с^2");
                int Hcycleid = 1; //нужно для проверки на положительное число
                bool isCorrect = false; //нужно для проверки на ввод буквы
                Console.Write($"\nВведите значение высоты h_first, м: ");
                while (!isCorrect) //проверка на ввод буквы
                {
                    isCorrect = double.TryParse(Console.ReadLine(), out h_first);
                    if (!isCorrect)
                        Console.WriteLine("***** Ошибка ввода! Введите ПОЛОЖИТЕЛЬНО ЧИСЛО *****");
                }
                while (Hcycleid == 1) //начало проверки на положительное число
                {
                    if (h_first > 0)
                    {
                        Hcycleid = 0;
                    }
                    else
                    {
                        Console.WriteLine("***** Ошибка ввода! Введите ПОЛОЖИТЕЛЬНОЕ ЧИСЛО *****");
                        double.TryParse(Console.ReadLine(), out h_first);
                    }
                }
                m = 0.01*Math.Pow(16, (1.0 / 3.0));// перевод в кг6
                dt = 0.1;
                V0 = 0;
                h0 = h_first;
                Console.Write("Все необходимые данные записаны");
                while (h0 >= 0)
                {
                //g = (1 - a) / (1 + a);
                    Console.WriteLine($"{t}  {dt}  {h}  {V}  {a}");
                    a = ((m * G) - ((p * Math.Pow(V0, 2) * S * Cx) / 2)) / m;
                    V = (-1 + Math.Pow((1 + 4 *p * S * Cx / (2 * m) * dt * (V0 + G * dt)), 0.5)) / (p * S * Cx / (2 * m) * dt);//через дискриминант?
                h = h0 - (V0 * dt) - ((a * dt * dt) / 2);
                    t = t + dt;
                    //dt = 2 *m/ (p * V * S * Cx);// пришлось закоментировать, ибо решение сбоит
                    h0 = h;
                    V0 = V;
                    if (a <= 0.0001)
                    {
                        Console.WriteLine($"\nвремя падения {t} , высота {h_first - h0} , скорость {V} , ускорение {a} ");
                        break;
                    }
                }
                Console.ReadKey();
            }
        }
    }

