using DemoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alfabetocliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("obteniendo datos......./n");
            var mycontexdata = new myHelperData();
            //obtenemos de DB lista de alfabeto
            var myalfabeto = mycontexdata.GeTAlfabeto();
            Console.WriteLine("cargando archivo ...................");
            //Leemos txt
            string text = System.IO.File.ReadAllText(@"C:\xx\nombres.txt");
            //Quitamos las comillas
            var names = text.Replace("\"", "");
            //Sacamos lista sin comillas
            var arrNames = names.Split(',');
            Console.WriteLine("Ordenando ...................");
            //ordenamos lista sin comillas alfabeticamente
            Comparison<string> comparador = new Comparison<string>((cadena1, cadena2) => cadena1.CompareTo(cadena2));
            Array.Sort<string>(arrNames, comparador);
            int count = 1;
            int sumtotal = 0;
            Console.WriteLine("Calculando ...................");
            //recorre todas los nombres
            foreach (string item in arrNames)
            {
                int? value = 0;
                //recorre las letras del nombre
                for (int i = 0; i < item.Length; i++)
                {
                    //obtiene la letra
                    var letra = item[i];
                    //obtiene el valor de la letra desde nuesta lista de alfabeto de DB y la suma
                    value += myalfabeto.Where(c => c.fcValue == letra.ToString()).FirstOrDefault().fiIdKey;
                }
                //se multiplica valor de la letra  por la posicion de la letra
                var sumletra = value * count;
                Console.WriteLine($"nombre: {item} valor:{value} posicion: {count} Puntuacion: {sumletra}");
                //se suma total de valor de letras
                sumtotal += (int)sumletra;
                count++;
            }
            Console.WriteLine($"Total de Nombre: {arrNames.Length} Puntuacion total: {sumtotal}");
            Console.ReadLine();
        }
    }
}
