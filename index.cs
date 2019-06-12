using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecUber {
    class execUber{
        static void Main(){

            double [] salarios = new double[] {9, 4, 3, 1, 7, 12, 45, 41, 32, 98};

            int length = salarios.Length;

            double [] respostas = new double[getCombinacoes(length)];

            respostas = getAllAnswers(length, salarios, respostas);


            showDistincts(salarios, length, respostas);
                
            Console.WriteLine("\n\nPress any key to exit.");
            System.Console.ReadKey();
        }

        public static double[] getAllAnswers(int length, double[] salarios, double[] respostas){
            int h = 0;

            for(int i = 0 ; i < length ; i++){
                for(int j = i+1 ; j < length ; j++){
                    respostas[h] = (salarios[i] + salarios[j]);
                    h++;
                }
            }
            return respostas;
        }

        public static void showDistincts(double[] salarios, int length, double[] respostas){
            var result = (from r in respostas
                        where respostas.Count(r1 => r1 == r) >= 2
                        select r).Distinct();

            int lengthResult = result.ToArray().Length;
            int lastLoop = 0;
            foreach (int num in result){
                for(int i = 0 ; i < length ; i++){
                    for(int j = i+1 ; j < length ; j++){
                        if( num == salarios[i] + salarios[j]){
                            System.Console.Write("[{0}, {1}] ", salarios[i], salarios[j]);
                        }
                    }
                }
                lastLoop++;
                if(lastLoop != lengthResult)
                    System.Console.Write(" // ");
            }
        }

        public static int getCombinacoes(int length){
            int combinacoes = 1;
            int newLength = length-1;
            for(int i = newLength ; i > 0 ; i--){
                combinacoes+=i;
            }
            return combinacoes;
        }

    }
}