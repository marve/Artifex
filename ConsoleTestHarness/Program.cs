using Core;
using Core.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHarness
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            QuadLinkedList<Fancy> quadLinkedList = new QuadLinkedList<Fancy>(GenerateElements(10, 10));
            Console.ReadLine();
        }

        private static Fancy[][] GenerateElements(int rows, int columns)
        {
            return Enumerable.Range(0, rows).Select(rowIndex =>
            {
                return Enumerable.Range(0, columns).Select(columnIndex =>
                {
                    return new Fancy();
                }).ToArray();
            }).ToArray();
        }

        private class Fancy
        {

        }
    }
}
