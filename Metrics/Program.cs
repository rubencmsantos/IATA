using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Globalization;


namespace AmITP2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> newLines = new List<string>();
            List<double> power = new List<double>();
            //double average;
            Dictionary<int, int> powerHist = new Dictionary<int, int>();
            Dictionary<DateTime, double> all = new Dictionary<DateTime, double>();
            Dictionary<DateTime, double> ano2006 = new Dictionary<DateTime, double>();
            Dictionary<DateTime, double> ano2007 = new Dictionary<DateTime, double>();
            Dictionary<DateTime, double> ano2008 = new Dictionary<DateTime, double>();
            Dictionary<DateTime, double> ano2009 = new Dictionary<DateTime, double>();
            Dictionary<DateTime, double> ano2010 = new Dictionary<DateTime, double>();

            Dictionary<int, double> dias = new Dictionary<int, double>();
            Dictionary<DayOfWeek, double> dias2 = new Dictionary<DayOfWeek, double>();
            Dictionary<int, double> tamanhos = new Dictionary<int, double>();
            Dictionary<DayOfWeek, double> tamanhos2 = new Dictionary<DayOfWeek, double>();
            Dictionary<int, double> mediadias = new Dictionary<int, double>();
            Dictionary<DayOfWeek, double> mediadias2 = new Dictionary<DayOfWeek, double>();


            dias2.Add(DayOfWeek.Monday, 0);
            dias2.Add(DayOfWeek.Tuesday, 0);
            dias2.Add(DayOfWeek.Wednesday, 0);
            dias2.Add(DayOfWeek.Thursday, 0);
            dias2.Add(DayOfWeek.Friday, 0);
            dias2.Add(DayOfWeek.Saturday, 0);
            dias2.Add(DayOfWeek.Sunday, 0);

            tamanhos2.Add(DayOfWeek.Monday, 0);
            tamanhos2.Add(DayOfWeek.Tuesday, 0);
            tamanhos2.Add(DayOfWeek.Wednesday, 0);
            tamanhos2.Add(DayOfWeek.Thursday, 0);
            tamanhos2.Add(DayOfWeek.Friday, 0);
            tamanhos2.Add(DayOfWeek.Saturday, 0);
            tamanhos2.Add(DayOfWeek.Sunday, 0);

            dias.Add(1,0); dias.Add(2,0); dias.Add(3,0); dias.Add(4,0); dias.Add(5,0); dias.Add(6,0); dias.Add(7,0);
            dias.Add(8,0); dias.Add(9,0); dias.Add(10,0); dias.Add(11,0); dias.Add(12,0); dias.Add(13,0); dias.Add(14,0);
            dias.Add(15,0); dias.Add(16,0); dias.Add(17,0); dias.Add(18,0); dias.Add(19,0); dias.Add(20,0); dias.Add(21,0);
            dias.Add(22,0); dias.Add(23,0); dias.Add(24,0); dias.Add(25,0); dias.Add(26,0); dias.Add(27,0); dias.Add(28,0);
            dias.Add(29,0); dias.Add(30,0); dias.Add(31,0);

            tamanhos.Add(1, 0); tamanhos.Add(2, 0); tamanhos.Add(3, 0); tamanhos.Add(4, 0); tamanhos.Add(5, 0); tamanhos.Add(6, 0); tamanhos.Add(7, 0);
            tamanhos.Add(8, 0); tamanhos.Add(9, 0); tamanhos.Add(10, 0); tamanhos.Add(11, 0); tamanhos.Add(12, 0); tamanhos.Add(13, 0); tamanhos.Add(14, 0);
            tamanhos.Add(15, 0); tamanhos.Add(16, 0); tamanhos.Add(17, 0); tamanhos.Add(18, 0); tamanhos.Add(19, 0); tamanhos.Add(20, 0); tamanhos.Add(21, 0);
            tamanhos.Add(22, 0); tamanhos.Add(23, 0); tamanhos.Add(24, 0); tamanhos.Add(25, 0); tamanhos.Add(26, 0); tamanhos.Add(27, 0); tamanhos.Add(28, 0);
            tamanhos.Add(29, 0); tamanhos.Add(30, 0); tamanhos.Add(31, 0);

            //int pMaxHour = 0, pMaxMinute = 0;
            string pMaxHour = "";
            string pMaxDate = "";
            float pMax = 0;
            double sum = 0;

            DateTime data;

            if (System.IO.File.Exists(args[0]))
            {
                string[] lines = System.IO.File.ReadAllLines(args[0]);
                List<string> linesList = new List<string>(lines);
                foreach (string line in lines)
                {
                    // Use a tab to indent each line of the file.
                    //Console.WriteLine("\t" + line);
                }
                for (int i = 1; i < linesList.Count(); i++)
                {
                    newLines.Add(linesList.ElementAt(i));
                }

                List<Double> valorestotal = new List<Double>();

                foreach (string line in newLines)
                {
                    string[] medSplit = line.Split(';');
                    data = DateTime.Parse(medSplit[0] + " " + medSplit[1]);
                    //Console.WriteLine(data.Hour);

                    if (medSplit[2] != "?")
                    {
                        String instPower = medSplit[2];
                        String date = medSplit[0];
                        String time = medSplit[1];
                        //Console.WriteLine(float.Parse(instPower, CultureInfo.InvariantCulture)*100);
                        int instPowerInt = (int)(float.Parse(instPower, CultureInfo.InvariantCulture) * 100);
                        valorestotal.Add(instPowerInt);
                        sum += instPowerInt;

                        //Console.WriteLine(sum);
                        //string[] instPower = medSplit[2].Split('.');

                        // Convert.ToSingle(medSplit[2], CultureInfo.InvariantCulture);
                        if (instPowerInt > pMax)
                        {
                            pMax = instPowerInt;
                            pMaxDate = date;
                            pMaxHour = time;
                        }
                        //Console.WriteLine(long.Parse(instPower[0]));
                        //Console.WriteLine(medSplit[3]);
                        if (powerHist.ContainsKey(instPowerInt))
                        {
                            powerHist[instPowerInt] += 1;
                        }
                        else
                        {
                            powerHist.Add(instPowerInt, 1);
                        }
                        all.Add(data, instPowerInt);
                        if (data.Year.Equals(2006)) { ano2006.Add(data, instPowerInt); }
                        if (data.Year.Equals(2007)) { ano2007.Add(data, instPowerInt); }
                        if (data.Year.Equals(2008)) { ano2008.Add(data, instPowerInt); }
                        if (data.Year.Equals(2009)) { ano2009.Add(data, instPowerInt); }
                        if (data.Year.Equals(2010)) { ano2010.Add(data, instPowerInt); }

                        if (dias.ContainsKey(data.Day)) { dias[data.Day] += instPowerInt;
                            tamanhos[data.Day]++; }

                        if (dias2.ContainsKey(data.DayOfWeek)) { dias2[data.DayOfWeek] += instPowerInt;
                            tamanhos2[data.DayOfWeek]++;
                        }


                    }


                }
                Console.WriteLine("\n-------------MÉDIA POR DIA-------------\n");

                foreach (KeyValuePair<int,double> a in dias.ToList())
                {
                        mediadias.Add(a.Key, a.Value / tamanhos[a.Key]);
                        Console.WriteLine("MÉDIA NO DIA [" + a.Key + "] " + mediadias[a.Key]);
                }
                Console.WriteLine("\n-------------MÉDIA POR DIA DA SEMANA-------------\n");

                foreach (KeyValuePair<DayOfWeek, double> a in dias2.ToList())
                {
                    mediadias2.Add(a.Key, a.Value / tamanhos2[a.Key]);
                    Console.WriteLine("MÉDIA DE [" + a.Key + "] " + mediadias2[a.Key]);
                }




                double media = valorestotal.Average();

                var list2006 = ano2006.ToList();
                var list2007 = ano2007.ToList();
                var list2008 = ano2008.ToList();
                var list2009 = ano2009.ToList();
                var list2010 = ano2010.ToList();
                double total2006 = 0;
                double total2007 = 0;
                double total2008 = 0;
                double total2009 = 0;
                double total2010 = 0;

                foreach (KeyValuePair<DateTime, double> a in list2006) { total2006 += a.Value; }
                foreach (KeyValuePair<DateTime, double> a in list2007) { total2007 += a.Value; }
                foreach (KeyValuePair<DateTime, double> a in list2008) { total2008 += a.Value; }
                foreach (KeyValuePair<DateTime, double> a in list2009) { total2009 += a.Value; }
                foreach (KeyValuePair<DateTime, double> a in list2010) { total2010 += a.Value; }

                double media2006 = total2006 / (double)list2006.Count();
                double media2007 = total2007 / (double)list2007.Count();
                double media2008 = total2008 / (double)list2008.Count();
                double media2009 = total2009 / (double)list2009.Count();
                double media2010 = total2010 / (double)list2010.Count();
                double mediatotal = sum / (double)newLines.Count();

                Console.WriteLine("\n-------------MÉDIA POR ANOS-------------\n");
                Console.WriteLine("MÉDIA [2006] " + media2006);
                Console.WriteLine("MÉDIA [2007] " + media2007);
                Console.WriteLine("MÉDIA [2008] " + media2008);
                Console.WriteLine("MÉDIA [2009] " + media2009);
                Console.WriteLine("MÉDIA [2010] " + media2010);
                Console.WriteLine("MÉDIA [TOTAL] " + media);

                // STD. TOTAL
                double totalQtotal = 0;
                double numerototal = valorestotal.Count();
                foreach (Double d in valorestotal) {
                    double intermedio = d - media;
                    double quadrado = Math.Pow((double)intermedio, 2);
                    totalQtotal += quadrado;
                }
                double Devtotal = Math.Sqrt(totalQtotal / numerototal);
                Console.WriteLine("\nDESVIO PADRÃO TOTAL " + Devtotal);

                double media1 = 0, media2 = 0, media3 = 0, media4 = 0, media5 = 0, media6 = 0;
                double media7 = 0, media8 = 0, media9 = 0, media10 = 0, media11 = 0, media12 = 0;
                double soma1 = 0, soma2 = 0, soma3 = 0, soma4 = 0, soma5 = 0, soma6 = 0;
                double soma7 = 0, soma8 = 0, soma9 = 0, soma10 = 0, soma11 = 0, soma12 = 0;
                double total1 = 0, total2 = 0, total3 = 0, total4 = 0, total5 = 0, total6 = 0;
                double total7 = 0, total8 = 0, total9 = 0, total10 = 0, total11 = 0, total12 = 0;

                foreach (KeyValuePair<DateTime, double> a in all)
                {
                    if (a.Key.Month.Equals(1)) {soma1 += a.Value; total1++;}
                    if (a.Key.Month.Equals(2)) {soma2 += a.Value; total2++;}
                    if (a.Key.Month.Equals(3)) {soma3 += a.Value; total3++;}
                    if (a.Key.Month.Equals(4)) {soma4 += a.Value; total4++;}
                    if (a.Key.Month.Equals(5)) {soma5 += a.Value; total5++;}
                    if (a.Key.Month.Equals(6)) {soma6 += a.Value; total6++;}
                    if (a.Key.Month.Equals(7)) {soma7 += a.Value; total7++;}
                    if (a.Key.Month.Equals(8)) {soma8 += a.Value; total8++;}
                    if (a.Key.Month.Equals(9)) {soma9 += a.Value; total9++;}
                    if (a.Key.Month.Equals(10)) {soma10 += a.Value; total10++;}
                    if (a.Key.Month.Equals(11)) {soma11 += a.Value; total11++;}
                    if (a.Key.Month.Equals(12)) {soma12 += a.Value; total12++;}
                }
                media1 = soma1 / total1; media2 = soma2 / total2; media3 = soma3 / total3; media4 = soma4 / total4; media5 = soma5 / total5;
                media6 = soma6 / total6; media7 = soma7 / total7; media8 = soma8 / total8; media9 = soma9 / total9; media10 = soma10 / total10;
                media11 = soma11 / total11; media12 = soma12 / total12;

                Console.WriteLine("\n-------------MÉDIA POR MÊS-------------\n");
                Console.WriteLine("MÉDIA [JANEIRO] " + media1);
                Console.WriteLine("MÉDIA [FEVEREIRO] " + media2);
                Console.WriteLine("MÉDIA [MARÇO] " + media3);
                Console.WriteLine("MÉDIA [ABRIL] " + media4);
                Console.WriteLine("MÉDIA [MAIO] " + media5);
                Console.WriteLine("MÉDIA [JUNHO] " + media6);
                Console.WriteLine("MÉDIA [JULHO] " + media7);
                Console.WriteLine("MÉDIA [AGOSTO] " + media8);
                Console.WriteLine("MÉDIA [SETEMBRO] " + media9);
                Console.WriteLine("MÉDIA [OUTUBRO] " + media10);
                Console.WriteLine("MÉDIA [NOVEMBRO] " + media11);
                Console.WriteLine("MÉDIA [DEZEMBRO] " + media12);

                double t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0, t9 = 0, t10 = 0, t11 = 0, t12 = 0;

                foreach (KeyValuePair<DateTime, double> a in all)
                {
                    if (a.Key.Month.Equals(1)) { double i1 = a.Value - media1; double q1 = Math.Pow((double)i1, 2); t1 += q1; }
                    if (a.Key.Month.Equals(2)) { double i2 = a.Value - media2; double q2 = Math.Pow((double)i2, 2); t2 += q2; }
                    if (a.Key.Month.Equals(3)) { double i3 = a.Value - media3; double q3 = Math.Pow((double)i3, 2); t3 += q3; }
                    if (a.Key.Month.Equals(4)) { double i4 = a.Value - media4; double q4 = Math.Pow((double)i4, 2); t4 += q4; }
                    if (a.Key.Month.Equals(5)) { double i5 = a.Value - media5; double q5 = Math.Pow((double)i5, 2); t5 += q5; }
                    if (a.Key.Month.Equals(6)) { double i6 = a.Value - media6; double q6 = Math.Pow((double)i6, 2); t6 += q6; }
                    if (a.Key.Month.Equals(7)) { double i7 = a.Value - media7; double q7 = Math.Pow((double)i7, 2); t7 += q7; }
                    if (a.Key.Month.Equals(8)) { double i8 = a.Value - media8; double q8 = Math.Pow((double)i8, 2); t8 += q8; }
                    if (a.Key.Month.Equals(9)) { double i9 = a.Value - media9; double q9 = Math.Pow((double)i9, 2); t9 += q9; }
                    if (a.Key.Month.Equals(10)) { double i10 = a.Value - media10; double q10 = Math.Pow((double)i10, 2); t10 += q10; }
                    if (a.Key.Month.Equals(11)) { double i11 = a.Value - media11; double q11 = Math.Pow((double)i11, 2); t11 += q11; }
                    if (a.Key.Month.Equals(12)) { double i12 = a.Value - media12; double q12 = Math.Pow((double)i12, 2); t12 += q12; }
                }

                Console.WriteLine("\n-------------DESVIO PADRÃO POR MESES-------------\n");
                double Dev1 = Math.Sqrt(t1 / total1); Console.WriteLine("DESVIO PADRÃO [JANEIRO] " + Dev1);
                double Dev2 = Math.Sqrt(t2 / total2); Console.WriteLine("DESVIO PADRÃO [FEVEREIRO] " + Dev2);
                double Dev3 = Math.Sqrt(t3 / total3); Console.WriteLine("DESVIO PADRÃO [MARÇO] " + Dev3);
                double Dev4 = Math.Sqrt(t4 / total4); Console.WriteLine("DESVIO PADRÃO [ABRIL] " + Dev4);
                double Dev5 = Math.Sqrt(t5 / total5); Console.WriteLine("DESVIO PADRÃO [MAIO] " + Dev5);
                double Dev6 = Math.Sqrt(t6 / total6); Console.WriteLine("DESVIO PADRÃO [JUNHO] " + Dev6);
                double Dev7 = Math.Sqrt(t7 / total7); Console.WriteLine("DESVIO PADRÃO [JULHO] " + Dev7);
                double Dev8 = Math.Sqrt(t8 / total8); Console.WriteLine("DESVIO PADRÃO [AGOSTO] " + Dev8);
                double Dev9 = Math.Sqrt(t9 / total9); Console.WriteLine("DESVIO PADRÃO [SETEMBRO] " + Dev9);
                double Dev10 = Math.Sqrt(t10 / total10); Console.WriteLine("DESVIO PADRÃO [OUTUBRO] " + Dev10);
                double Dev11 = Math.Sqrt(t11 / total11); Console.WriteLine("DESVIO PADRÃO [NOVEMBRO] " + Dev11);
                double Dev12 = Math.Sqrt(t12 / total12); Console.WriteLine("DESVIO PADRÃO [DEZEMBRO] " + Dev12);

                Console.WriteLine("\n-------------DESVIO PADRÃO POR ANOS-------------\n");

                // STD. 2006
                double totalQ2006 = 0;
                double numero2006 = list2006.Count();
                foreach (KeyValuePair<DateTime, double> a in list2006){
                    double intermedio = a.Value - media2006;
                    double quadrado = Math.Pow((double)intermedio, 2);
                    totalQ2006 += quadrado;}
                double Dev2006 = Math.Sqrt(totalQ2006 / numero2006);
                Console.WriteLine("DESVIO PADRÃO [2006] " + Dev2006);
                // STD. 2007
                double totalQ2007 = 0;
                double numero2007 = list2007.Count();
                foreach (KeyValuePair<DateTime, double> a in list2007)
                {
                    double intermedio = a.Value - media2007;
                    double quadrado = Math.Pow((double)intermedio, 2);
                    totalQ2007 += quadrado;
                }
                double Dev2007 = Math.Sqrt(totalQ2007 / numero2007);
                Console.WriteLine("DESVIO PADRÃO [2007] " + Dev2007);
                // STD. 2008
                double totalQ2008 = 0;
                double numero2008 = list2008.Count();
                foreach (KeyValuePair<DateTime, double> a in list2008)
                {
                    double intermedio = a.Value - media2008;
                    double quadrado = Math.Pow((double)intermedio, 2);
                    totalQ2008 += quadrado;
                }
                double Dev2008 = Math.Sqrt(totalQ2008 / numero2008);
                Console.WriteLine("DESVIO PADRÃO [2008] " + Dev2008);
                // STD. 2009
                double totalQ2009 = 0;
                double numero2009 = list2009.Count();
                foreach (KeyValuePair<DateTime, double> a in list2009)
                {
                    double intermedio = a.Value - media2008;
                    double quadrado = Math.Pow((double)intermedio, 2);
                    totalQ2009 += quadrado;
                }
                double Dev2009 = Math.Sqrt(totalQ2009 / numero2009);
                Console.WriteLine("DESVIO PADRÃO [2009] " + Dev2009);
                // STD. 2010
                double totalQ2010 = 0;
                double numero2010 = list2010.Count();
                foreach (KeyValuePair<DateTime, double> a in list2010)
                {
                    double intermedio = a.Value - media2010;
                    double quadrado = Math.Pow((double)intermedio, 2);
                    totalQ2010 += quadrado;
                }
                double Dev2010 = Math.Sqrt(totalQ2010 / numero2010);
                Console.WriteLine("DESVIO PADRÃO [2010] " + Dev2010);

             

                //Calculando histograma da potencia
                foreach (KeyValuePair<int, int> item in powerHist)
				{
                    //Console.WriteLine(pMax);
                   //Console.WriteLine(item.Key+":"+item.Value);
				}
                var powerHistOrdered = powerHist.ToList();
                powerHistOrdered.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

                var topPower = powerHistOrdered.Take(10);
                int totalCount = 0;


                foreach (KeyValuePair<int, int> item in topPower)
				{
                    totalCount += item.Value;
				    //Console.WriteLine(item.Key+":"+item.Value);
				}

                float shadowPower = 0;
				foreach (KeyValuePair<int, int> item in topPower)
				{
                    shadowPower += item.Key*((float)item.Value/totalCount);
					//Console.WriteLine(item.Key + ":" + item.Value);
				}
                Console.WriteLine("\nA potência de sombra instalada é: "+shadowPower+" W");
                Console.WriteLine("\nO pico de potência foi de: " + pMax + " W"+" no dia "+pMaxDate+" às "+pMaxHour);


                /*ConnectionFactory connectDB = new AmITP2.ConnectionFactory();
                List<string>[] list = new List<string>[3];
                list = connectDB.Select("SELECT * FROM temp ORDER BY time DESC LIMIT 10");
                foreach (List<string> subList in list)
                {
                    foreach (string item in subList)
                    {
                        Console.Write(item+" ");
                    }
                    Console.WriteLine("");
                }*/
            }
		}
    }
}
