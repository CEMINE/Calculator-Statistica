using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Timers;



namespace Statistica_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            
            string answer;
            Console.WriteLine("Pentru a introduce date negrupate apasati tasta 1.");
            Console.WriteLine("Pentru a introduce date grupate apasati tasta 2");
            Console.WriteLine("Pentru a introduce intervale de incredere apasati tasta 3");
            Console.WriteLine("Pentru a verifica prin testul Student(media) apasati tasta 4");
            Console.WriteLine("Pentru a verifica prin testul Helmert(varianta) apasati tasta 5");
            answer = Convert.ToString(Console.ReadLine());

            if (answer == "1")
            {
                int n;
              

                Console.WriteLine("Introduceti numarul de elemente ale esantionului: ");
                n = Convert.ToInt32(Console.ReadLine());
                double suma_numere = 0;
                double[] numere = new double[n];

                List<double> lista_numere = new List<double>();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Introduceti elementul {0}: ", i);
                    numere[i] = Convert.ToDouble(Console.ReadLine());
                    suma_numere = suma_numere + numere[i];
                    lista_numere.Add(numere[i]);

                }



                Console.WriteLine("Date negrupate");
                double x_max = numere[0], x_min = numere[0];
                double media = suma_numere / n;
                Console.WriteLine("Media datelor negrupate introduse este {0}.", media);
                for (int i = 0; i < n; i++)
                {
                    if (x_max < numere[i])
                    {
                        x_max = numere[i];
                    }
                }

                for (int k = 0; k < n; k++)
                {

                    if (x_min >= numere[k])
                        x_min = numere[k];


                }
                Console.WriteLine("Xmax este {0} si Xmin este {1}", x_max, x_min);
                double h;
                h = (x_max - x_min) / (1 + 3.322 * Math.Log10(n));
                int h_rotunjit = Convert.ToInt32(Math.Ceiling(h));
                Console.WriteLine("H este {0} iar H rotunjit este {1}", h, h_rotunjit);


                bool impar;
                // daca n este impar
                if (n % 2 != 0)
                {
                    Console.WriteLine("N({0}) este numar impar.", n);
                    impar = true;
                }

                else
                {
                    Console.WriteLine("N({0}) este numar par.", n);
                    impar = false;
                }

                int numarul_medianei1, numarul_medianei2, numarul_medianei;
                double mediana;
                if (impar == true)
                {
                    numarul_medianei = (n - 1) / 2;
                    mediana = (numere[numarul_medianei]);
                    Console.WriteLine("Mediana pe date negrupate a esantionului (n impar) este {0}", mediana);
                }

                if (impar == false)
                {
                    numarul_medianei1 = (n / 2) - 1;
                    numarul_medianei2 = (n / 2);
                    mediana = (numere[numarul_medianei1] + numere[numarul_medianei2]) / 2;
                    Console.WriteLine("Mediana pe date negrupate (n este par) este {0}", mediana);
                }

                var quey = (from item in numere
                            group item by item into g
                            orderby g.Count() descending
                            select new { item = g.Key, Count = g.Count() }).First();
                if (quey.Count <= 1)
                {
                    Console.WriteLine("Nu exista modul");
                }
                else if (quey.Count > 1)
                {
                    Console.WriteLine("Modul pe date negrupate este numarul " + quey.item + ", acesta se repeta de  " + quey.Count + " ori.");
                }
                
                List<double> xi_media = new List<double>();
                List<double> xi_media2 = new List<double>();
                double[] rezultat_xi_media = new double[n];
                float varianta = 0;
                double suma_xi_med_patr=0;
                for (int k = 0; k < lista_numere.Count; k++)
                {
                    rezultat_xi_media[k] = (lista_numere[k] - media);
                    //xi_media2.Add(rezultat_xi_media[k]);
                    rezultat_xi_media[k] = rezultat_xi_media[k] * rezultat_xi_media[k];
                    xi_media.Add(rezultat_xi_media[k]);
                    suma_xi_med_patr += rezultat_xi_media[k];
                    if (k == lista_numere.Count - 1)                        
                    {
                        float n_m_u = (float)n - 1;
                        varianta = 1 / n_m_u * (float)suma_xi_med_patr;
                        Console.WriteLine("Varianta este: " + varianta);
                    }
                }
                

                double rezultat1 = 0;
                double suma_numere_media = 0;
                for (int a = 0; a < lista_numere.Count;a++)
                {
                    rezultat1 = (lista_numere[a] - media) * (lista_numere[a] - media);
                    double rezultat_patrat = rezultat1 * rezultat1;
                    suma_numere_media += rezultat1;
                    rezultat1 = 0;
                    rezultat_patrat = 0;
                    
                }
                float n_float = n;
                float unu_n = 1 / n_float;
                
                float abaterea_med_patr = (float)suma_numere_media / (n-1);
                abaterea_med_patr = (float)Math.Sqrt(abaterea_med_patr);
                Console.WriteLine("Abaterea medie patratica este " + abaterea_med_patr);

                double rezultat_ab_lin=0;
                double suma_numere_xi_media = 0;
                for (int t = 0; t<lista_numere.Count;t++)
                {
                    rezultat_ab_lin = Math.Abs(lista_numere[t] - media);
                    suma_numere_xi_media += rezultat_ab_lin;
                }

                float abatere_med_lin = unu_n * (float)suma_numere_xi_media;
                Console.WriteLine("Abaterea medie liniara este " + abatere_med_lin);
                double coef_var = (abaterea_med_patr / media) * 100;
                Console.WriteLine("Coeficientul de variatie este " + coef_var + "%");
                double amplitudine = x_max - x_min;
                Console.WriteLine("Amplitudinea este " + amplitudine);

                Console.ReadKey();
                System.Threading.Thread.Sleep(-1);


            }


            if (answer == "2")
             
            {
                List<double> list1 = new List<double>();
                int n;
                Console.WriteLine("Introduceti numarul de elemente ale esantionului: ");
                n = Convert.ToInt32(Console.ReadLine());
                double suma_numere = 0;
                double[] numere = new double[n];



                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Introduceti elementul {0}: ", i);
                    numere[i] = Convert.ToDouble(Console.ReadLine());
                    suma_numere = suma_numere + numere[i];
                    list1.Add(numere[i]);
                }
                    double x_max = numere[0]; 
                    double x_min = numere[0];
                    for (int j = 0; j < n; j++)
                    {
                        if (x_max < numere[j])
                        {
                            x_max = numere[j];
                        }
                    }

                    for (int k = 0; k < n; k++)
                    {

                        if (x_min >= numere[k])
                            x_min = numere[k];


                    }


                    int nr_int = 0;
                    double[] mijloc_intervale = new double[nr_int];
                  

                    double h;
                    h = (x_max - x_min) / (1 + 3.322 * Math.Log10(n));
                    int h_rotunjit = Convert.ToInt32(Math.Ceiling(h));
                int nr_intervale=-1;
                double interval;
                interval = x_min;
                while (interval <= x_max + h_rotunjit | interval == x_max)
                {
                    interval = interval + h_rotunjit;
                    nr_intervale++;
                    
                }
                
                Console.WriteLine("Seria de date introdusa are " + nr_intervale + " intervale.");

                double[] lim_inf = new double[10];
                double[] lim_sup = new double[10];
                lim_inf[0] = x_min;
                lim_sup[0] = lim_inf[0] + h_rotunjit;

                int x_min_rotunjit = 0;
                if (x_min % 2 != 0)
                {
                    x_min_rotunjit = (int)Math.Floor(x_min);
                }
                else
                    x_min_rotunjit = Convert.ToInt32(x_min);


                lim_inf[0] = x_min_rotunjit;
                lim_sup[0] = lim_inf[0] + h_rotunjit;
                int[] ni = new int[n];
                double suma_mij_int = 0;
                double[] xi = new double[n];
                double[] xi_ni = new double[n];
                double suma_xi_ni = 0;
                double media_grupate = 0;
                int[] cni = new int[n];
                double lim_inf_int_median = 0;
                double lim_sup_int_median = 0;
                double cni_s = 0;
                bool stop = false;
                double mediana = 0;
                List<double> lista_cni = new List<double>();
                List<int> lista_ni = new List<int>();
                int max_ni = 0;
                List<double> lim_inf_int_mod = new List<double>();
                List<double> lim_sup_int_mod = new List<double>();
                double modul;
                List<double> lista_lim_inf = new List<double>();
                List<double> lista_lim_sup = new List<double>();
                for (int q = 0; q < nr_intervale; q++)
                {
                    if (q == 0)
                    {
                        lim_inf[q] = x_min_rotunjit;
                        lim_sup[q] = x_min_rotunjit + h_rotunjit;
                        suma_mij_int = suma_mij_int + (lim_inf[q] + lim_sup[q])/2;
                        xi[q] = (lim_inf[q] + lim_sup[q]) / 2;
                        
                       
                    }
            
                    else if (q != 0)
                    {
                        lim_inf[q] = x_min_rotunjit + (q * h_rotunjit);
                        lim_sup[q] = lim_inf[q] + h_rotunjit;
                        suma_mij_int = suma_mij_int + (lim_inf[q] + lim_sup[q])/2;
                        xi[q] = (lim_inf[q] + lim_sup[q]) / 2;


                    }

                    for (int z = 0; z < n; z++)
                    {
                        if (list1[z] >= lim_inf[q] & list1[z] <= lim_sup[q])
                        {
                            ni[q]++;
                            
                        }
                        
                        

                    }
                    lista_ni.Add(ni[q]);
                    max_ni = lista_ni[0];
                    lista_lim_inf.Add(lim_inf[q]);
                    lista_lim_sup.Add(lim_sup[q]);

                    if (q == 0)
                    {
                        cni[q] = ni[q];
                        cni_s = cni[q];
                        lista_cni.Add(cni_s);
                    }
                    else
                    {
                        cni[q] = cni[q] + ni[q];
                        cni_s = cni_s + cni[q];
                        lista_cni.Add(cni_s);

                    }
                    if (stop == false)
                    {
                        if (cni_s > (n / 2))
                        {
                            lim_inf_int_median = lim_inf[q];
                            lim_sup_int_median = lim_sup[q];
                            Console.WriteLine("Intervalul median este [" + lim_inf[q] + ";" + lim_sup[q] + "]");
                            double jumatate_n = n / 2;
                            double cni_int_ant_median = lista_cni[q - 1];
                            double ni_int_median = ni[q];
                            double numarator = jumatate_n - cni_int_ant_median;
                            double numitor = ni_int_median;
                            mediana = lim_inf_int_median + h_rotunjit * (numarator / numitor);
                            Console.WriteLine("Mediana pe date grupate este " + mediana);
                            stop = true;

                        }
                    }
                   
                    int duplicates = 0;
                    max_ni = lista_ni.Max();


                    lim_inf_int_mod.Add(lim_inf[q]);
                    lim_sup_int_mod.Add(lim_sup[q]);
                    double lim_inf_int_modal;
                    double lim_sup_int_modal;
                    int index = 0;

                    if (q == nr_intervale - 1)
                    {
                        foreach (int item in lista_ni)
                        {
                            if (lista_ni[lista_ni.IndexOf(max_ni)] == item)
                            {
                                duplicates++;
                            }
                        }
                    }

                    if (q == nr_intervale - 1)
                    {
                        if (duplicates == 1)
                        {
                            index = lista_ni.IndexOf(max_ni);
                            lim_inf_int_modal = lim_inf_int_mod[index];
                            lim_sup_int_modal = lim_sup_int_mod[index];
                            double delta1 = lista_ni[index] - lista_ni[index - 1];
                            double delta2 = lista_ni[index] - lista_ni[index + 1];
                            double suma_delte = delta1 + delta2;
                            Console.WriteLine("Intervalul modal este [" + lim_inf_int_modal + ";" + lim_sup_int_modal + "]");
                            modul = lim_inf_int_modal + h_rotunjit * (delta1/suma_delte);
                            Console.WriteLine("Modul este " + modul);

                        }
                        else if (duplicates > 1)
                        {
                            Console.WriteLine("Nu exista interval modal");
                        }
                    }
                 



                    xi_ni[q] = xi[q] * ni[q];
                    suma_xi_ni = suma_xi_ni + xi_ni[q];

                    if (q == nr_intervale-1)
                    {
                        media_grupate = suma_xi_ni / n;
                        Console.WriteLine("Media pe date grupate este: " + media_grupate);
                    }





                    List<double> medie_intervale = new List<double>();
                    double xi_media_patrat = 0;
                    double suma_xi_media_patrat = 0;
                    if (q == nr_intervale - 1)
                    {
                        for (int j = 0; j < lista_lim_inf.Count; j++)
                        {
                            medie_intervale.Add((lista_lim_inf[j] + lista_lim_sup[j]) / 2);
                            xi_media_patrat = (medie_intervale[j] - media_grupate) * (medie_intervale[j] - media_grupate) * lista_ni[j];
                            suma_xi_media_patrat += xi_media_patrat;
                            float unu_n = (1 / (float)n);
                            float abatere_med_liniara;
                            double calcul_modul_xi_media = 0;
                            double suma_modul_xi_media = 0;
                            float coef_var = 0;

                            if (j == lista_lim_inf.Count - 1)
                            {
                                float n_m_u = ((float)n - 1);

                                float fractie = 1 / n_m_u;
                                float varianta = fractie * (float)suma_xi_media_patrat;
                                Console.WriteLine("Varianta pe date grupate este: " + varianta);
                                double abaterea_medie_patr = Math.Sqrt(varianta);
                                Console.WriteLine("Abaterea medie patratica este: " + abaterea_medie_patr);
                                for (int z = 0; z < lista_lim_inf.Count; z++)
                                {
                                    calcul_modul_xi_media = Math.Abs(medie_intervale[z] - media_grupate) * lista_ni[z];
                                    suma_modul_xi_media += calcul_modul_xi_media;
                                }
                                abatere_med_liniara = unu_n * (float)suma_modul_xi_media;
                                Console.WriteLine("Abaterea medie liniara este: " + abatere_med_liniara);
                                coef_var = ((float)abaterea_medie_patr / (float)media_grupate) * 100;
                                Console.WriteLine("Coeficientul de variatie este de: " + coef_var + "%");
                                
                            }

                        }
                        
                    }



                }

                Console.ReadKey();
                System.Threading.Thread.Sleep(-1);




            }




            if (answer == "3")
            {
                List<double> lista_numere = new List<double>();
                int n;
                double t = 0;
                double hi_patrat_alfa_2;
                double hi_patrat_unu_alfa_2;
                Console.WriteLine("Introduceti t-ul tabelar: ");
                t = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Introduceti probabilitatea (numar intreg): ");
                int probabilitate = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Introduceti hi patrat in functie de alfa/2: ");
                hi_patrat_alfa_2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Introduceti hi patrat in functie de 1-alfa/2: ");
                hi_patrat_unu_alfa_2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Introduceti numarul de elemente ale esantionului: ");
                n = Convert.ToInt32(Console.ReadLine());
                double suma_numere = 0;
                double[] numere = new double[n];



                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Introduceti elementul {0}: ", i);
                    numere[i] = Convert.ToDouble(Console.ReadLine());
                    suma_numere = suma_numere + numere[i];
                    lista_numere.Add(numere[i]);
                }
                double medie_negrupate = 0;
                double[] rezultat_xi_media = new double[n];
                float varianta = 0;
                double suma_xi_med_patr = 0;
                double media = suma_numere / n;
                float ab_med_patr = 0;
                List<double> xi_media = new List<double>();
                List<double> xi_media2 = new List<double>();

                for (int k = 0; k < lista_numere.Count; k++)
                {
                    rezultat_xi_media[k] = (lista_numere[k] - media);
                    //xi_media2.Add(rezultat_xi_media[k]);
                    rezultat_xi_media[k] = rezultat_xi_media[k] * rezultat_xi_media[k];
                    xi_media.Add(rezultat_xi_media[k]);
                    suma_xi_med_patr += rezultat_xi_media[k];
                    if (k == lista_numere.Count - 1)
                    {
                        float n_m_u = (float)n - 1;
                        varianta = 1 / n_m_u * (float)suma_xi_med_patr;
                        Console.WriteLine("Varianta este: " + varianta);
                    }
                }
                ab_med_patr = (float)Math.Sqrt(varianta);
                float lim_inf_student = 0;
                float lim_sup_student = 0;
                float float_medie_negrupate = (float)media;
                lim_inf_student = float_medie_negrupate -(float)t * ((float)(ab_med_patr / Math.Sqrt(n)));
                lim_sup_student = float_medie_negrupate + (float)t * ((float)(ab_med_patr / Math.Sqrt(n)));
                if (lim_inf_student < lim_sup_student)
                {
                    Console.WriteLine("Putem afirma cu o probabilitate de " + probabilitate + "% ca media este cuprinsa in intervalul [" + lim_inf_student + ";" + lim_sup_student + "].");
                }                
                else if(lim_inf_student > lim_sup_student)
                {
                    Console.WriteLine("Media nu este cuprinsa in intervalul [" + lim_inf_student + ";" + lim_sup_student + "].");
                }
                float alfa = 1 - (float)probabilitate / 100;
                double lim_inf_hi_patr = 0;
                double lim_sup_hi_patr = 0;
                lim_inf_hi_patr = ((n - 1) * varianta) / hi_patrat_alfa_2;
                lim_sup_hi_patr = ((n - 1) * varianta) / hi_patrat_unu_alfa_2;
                double sqrt_lim_inf_hi_patr = Math.Sqrt(lim_inf_hi_patr);
                double sqrt_lim_sup_hi_patr = Math.Sqrt(lim_sup_hi_patr);
                if(lim_inf_hi_patr < lim_sup_hi_patr)
                {
                    Console.WriteLine("Putem afirma cu o probabilitate de " + probabilitate + "% ca varianta este cuprinsa in intervalul [" + lim_inf_hi_patr + ";" + lim_sup_hi_patr + "].");
                }
                else if (lim_inf_hi_patr > lim_sup_hi_patr)
                {
                    Console.WriteLine("Varianta nu este cuprinsa in intervalul [" + lim_inf_hi_patr + ";" + lim_sup_hi_patr + "].");
                }
                if (sqrt_lim_inf_hi_patr < sqrt_lim_sup_hi_patr)
                {
                    Console.WriteLine("Putem afirma cu o probabilitate de " + probabilitate + "% ca abaterea medie patratica este cuprinsa in intervalul [" + sqrt_lim_inf_hi_patr + ";" + sqrt_lim_sup_hi_patr + "].");
                }
                else if (sqrt_lim_inf_hi_patr > sqrt_lim_sup_hi_patr)
                {
                    Console.WriteLine("Abaterea medie patratica nu se afla in intervalul [" + lim_inf_hi_patr + ";" + lim_sup_hi_patr + "].");
                }
                Console.ReadKey();
                System.Threading.Thread.Sleep(-1);







            }


            if (answer == "4")
            {
                int n;
                double suma_numere = 0;
                
                int probabilitate = 0;
                double tt = 0;


                Console.WriteLine("Introduceti probabilitatea(numar intreg): ");
                probabilitate = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Introduceti valoarea lui m: ");
                double m = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Introduceti t-ul tabelar(t critic): ");
                tt = Convert.ToDouble(Console.ReadLine());


                List<double> lista_numere = new List<double>();
                Console.WriteLine("Introduceti numarul de elemente al esantionului: ");
                n = Convert.ToInt32(Console.ReadLine());
                double[] numere = new double[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Introduceti elementul {0}: ", i);
                    numere[i] = Convert.ToDouble(Console.ReadLine());
                    suma_numere = suma_numere + numere[i];
                    lista_numere.Add(numere[i]);

                }
                double media_negrupate = suma_numere / n;
                double tc = 0;
                float alfa = 1 - ((float)probabilitate / 100);
                List<double> xi_media = new List<double>();
                List<double> xi_media2 = new List<double>();
                double[] rezultat_xi_media = new double[n];
                float varianta = 0;
                double suma_xi_med_patr = 0;

                for (int k = 0; k < lista_numere.Count; k++)
                {
                    rezultat_xi_media[k] = (lista_numere[k] - media_negrupate);
                    //xi_media2.Add(rezultat_xi_media[k]);
                    rezultat_xi_media[k] = rezultat_xi_media[k] * rezultat_xi_media[k];
                    xi_media.Add(rezultat_xi_media[k]);
                    suma_xi_med_patr += rezultat_xi_media[k];
                    if (k == lista_numere.Count - 1)
                    {
                        float n_m_u = (float)n - 1;
                        varianta = 1 / n_m_u * (float)suma_xi_med_patr;
                        Console.WriteLine("Varianta este: " + varianta);
                    }
                }


                double rezultat1 = 0;
                double suma_numere_media = 0;
                for (int a = 0; a < lista_numere.Count; a++)
                {
                    rezultat1 = (lista_numere[a] - media_negrupate) * (lista_numere[a] - media_negrupate);
                    double rezultat_patrat = rezultat1 * rezultat1;
                    suma_numere_media += rezultat1;
                    rezultat1 = 0;
                    rezultat_patrat = 0;

                }
                float n_float = n;
                float unu_n = 1 / n_float;
               
                float abaterea_med_patr = (float)suma_numere_media / (n - 1);
                abaterea_med_patr = (float)Math.Sqrt(abaterea_med_patr);
                Console.WriteLine("Abaterea medie patratica este " + abaterea_med_patr);
                












                tc = (Math.Abs(media_negrupate - m) / abaterea_med_patr ) * Math.Sqrt(n);
                Console.WriteLine("Etapa 1: Se formulează ipoteza nulă, conform căreia media este egala cu " + m);
                Console.WriteLine("Ipoteza nula- H0: m=m0=" + m);
                Console.WriteLine("Ipoteza alternativă- H1: m nu este egal cu m0, m nu este egal cu " + m);
                Console.WriteLine("Etapa 2: Se stabileste nivelul semnificatiei al testului, alfa = " + alfa);
                Console.WriteLine("Etapa 3: Se determina valoarea calculata a testului student");
                if (tc < tt)
                {
                    Console.WriteLine(tc + " este mai mic decat " + tt + ".");
                    Console.WriteLine("Ipoteza nula se accepta si se poate spune cu o probabilitate de " + probabilitate + "% ca media este egala cu \n valoarea m0, eventualele diferente fiind nesemnificative");
                }
                else if (tc > tt)
                {
                    Console.WriteLine(tc + " este mai mare decat " + tt + ".");
                    Console.WriteLine("Ipoteza nula se respinge, si se poate spune cu o probabilitate de " + probabilitate + "% ca media difera de valoarea \n data m0, diferentele fiind semnificative.");
                }
                Console.WriteLine("Scrie 'da' daca vrei sa inchizi programul.");
                Console.ReadKey();
                System.Threading.Thread.Sleep(-1);

            }

            if (answer == "5")
            {
                int n;
                double suma_numere = 0;

                int probabilitate = 0;
                double hi_patrat_alfa_2;
                double hi_patrat_unu_alfa_2;

                Console.WriteLine("Introduceti probabilitatea(numar intreg): ");
                probabilitate = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Introduceti valoarea lui o2: ");
                double o2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Introduceti hi patrat in functie de alfa/2: ");
                hi_patrat_alfa_2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Introduceti hi patrat in functie de 1 - alfa / 2: ");
                hi_patrat_unu_alfa_2 = Convert.ToDouble(Console.ReadLine());


                List<double> lista_numere = new List<double>();
                Console.WriteLine("Introduceti numarul de elemente al esantionului: ");
                n = Convert.ToInt32(Console.ReadLine());
                double[] numere = new double[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Introduceti elementul {0}: ", i);
                    numere[i] = Convert.ToDouble(Console.ReadLine());
                    suma_numere = suma_numere + numere[i];
                    lista_numere.Add(numere[i]);

                }
                double media_negrupate = suma_numere / n;
                float alfa = 1 - ((float)probabilitate / 100);
                List<double> xi_media = new List<double>();
                List<double> xi_media2 = new List<double>();
                double[] rezultat_xi_media = new double[n];
                float varianta = 0;
                double suma_xi_med_patr = 0;

                for (int k = 0; k < lista_numere.Count; k++)
                {
                    rezultat_xi_media[k] = (lista_numere[k] - media_negrupate);
                    //xi_media2.Add(rezultat_xi_media[k]);
                    rezultat_xi_media[k] = rezultat_xi_media[k] * rezultat_xi_media[k];
                    xi_media.Add(rezultat_xi_media[k]);
                    suma_xi_med_patr += rezultat_xi_media[k];
                    if (k == lista_numere.Count - 1)
                    {
                        float n_m_u = (float)n - 1;
                        varianta = 1 / n_m_u * (float)suma_xi_med_patr;
                    }
                }
                int n_m_unu = n - 1;
                double hi_c = (Convert.ToDouble(n_m_unu) * varianta) / o2;
                Console.WriteLine("n este" + n + " varianta este " + varianta + "o2 este " + o2);

                double alfa_mare = 0;
                double alfa_mic = 0;
                for (int x = 0; x< 6; x++)
                {
                    if (hi_patrat_alfa_2 > hi_patrat_unu_alfa_2)
                    {
                        alfa_mare = hi_patrat_alfa_2;
                        alfa_mic = hi_patrat_unu_alfa_2;
                    }
                    else if (hi_patrat_alfa_2 < hi_patrat_unu_alfa_2)
                    {
                        alfa_mare = hi_patrat_unu_alfa_2;
                        alfa_mic = hi_patrat_alfa_2;
                    }
                }



                if (hi_c >= alfa_mic && hi_c <= alfa_mare)
                {
                    Console.WriteLine(hi_c + " apartine intervalului [" + alfa_mic + ";" + alfa_mare + "].");
                    Console.WriteLine("Ipoteza nula se accepta si se poate spune cu o probabilitate de " + probabilitate + "% ca  varianta analizata \n este egala cu valoarea data o2(" + o2 + "), \n eventualele diferente fiind intamplatoare");
                }
                else
                {
                    Console.WriteLine(hi_c + " nu apartine intervalului [" + alfa_mic + ";" + alfa_mare + "].");
                    Console.WriteLine("Ipoteza nula se respinge si se poate spune cu o probabilitate de " + probabilitate + "% ca varianta difera  \n de valoarea data o2( " + o2 + "), diferentele avand cauze reale");
                }

                Console.ReadKey();
                System.Threading.Thread.Sleep(-1);






            }


            Console.ReadKey();
            System.Threading.Thread.Sleep(-1);











            }
        }
    }

