using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace PatientRecordApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            string temp;
            int id;
            string name;
            float balance;
            float balance_owned;
            string path = @"C:\temp\cis297-w2022-assignment4-template-hhdaana\PatientRecordApplication\PatientRecordApplication\Records.txt";
            int counter = 0;
            string input;
            string[] records = new string[100];
            const char DELIM = ',';
            string[] fields;
            int idSearch = 0;

            do
            {

                Console.WriteLine("select an option by enterign the coressponding number");
                Console.WriteLine("Add a new patient ---> 1");
                Console.WriteLine("Display all patient data ---> 2");
                Console.WriteLine("Search patient by ID ---> 3");
                Console.WriteLine("Search patients by balance due --->4");
                Console.WriteLine("Exit ---> 5");
                choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":

                        Console.WriteLine("Enter new patient ID:");
                        temp = Console.ReadLine();
                        id = Int32.Parse(temp);
                        Console.WriteLine("Enter new patient Name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter balance due:");
                        temp = Console.ReadLine();
                        balance = float.Parse(temp); 

                        Console.Clear();

                        Patient patient = new Patient(id, name, balance);

                        string line = id + "," + name + "," + balance + ",";

                        File.AppendAllText(path, line + Environment.NewLine);
                        break;
                    case "2":
                        try
                        {

                            foreach (string l in File.ReadLines(path))
                            {
                                Console.WriteLine(l);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "3":
                        try
                        {
                            Patient tempP = new Patient();
                            FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                            StreamReader reader = new StreamReader(inFile);
                            string recordIn;
                            Console.WriteLine("Enter patient ID:");
                            idSearch = Convert.ToInt32(Console.ReadLine());
                            while (idSearch != null)
                            {
                                inFile.Seek(0, SeekOrigin.Begin);
                                recordIn = reader.ReadLine();
                                while (recordIn != null)
                                {
                                    fields = recordIn.Split(DELIM);
                                    tempP.idNumber = Convert.ToInt32(fields[0]);
                                    tempP.name = fields[1];
                                    tempP.balanceOwed = Convert.ToDouble(fields[2]);
                                    if (tempP.idNumber == idSearch)
                                    {
                                        WriteLine("\n{0,-5}{1,-12}{2,8}\n", "Num", "Name", "Salary");
                                        WriteLine("{0,-5}{1,-12}{2,8}\n", tempP.idNumber, tempP.name, tempP.balanceOwed.ToString("C"));
                                    }
                                    recordIn = reader.ReadLine();
                                }
                                Console.WriteLine("Enter Another patient ID:");
                                idSearch = Convert.ToInt32(Console.ReadLine());
                            }
                            reader.Close();
                            inFile.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "4":
                        try
                        {
                            Patient tempP = new Patient();
                            FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                            StreamReader reader = new StreamReader(inFile);
                            string recordIn;
                            Patient tempP2 = new Patient();
                            FileStream inFile2 = new FileStream(path, FileMode.Open, FileAccess.Read);
                            StreamReader reader2 = new StreamReader(inFile2);
                            string recordIn2;
                            Console.WriteLine("Enter min balance:");
                            balance_owned = Convert.ToInt32(Console.ReadLine());
                            while (balance_owned != null)
                            {
                                inFile2.Seek(0, SeekOrigin.Begin);
                                recordIn = reader2.ReadLine();
                                while (recordIn != null)
                                {
                                    fields = recordIn.Split(DELIM);
                                    tempP2.idNumber = Convert.ToInt32(fields[0]);
                                    tempP2.name = fields[1];
                                    tempP2.balanceOwed = Convert.ToDouble(fields[2]);
                                    if (tempP2.balanceOwed >= balance_owned)
                                    {
                                        WriteLine("\n{0,-5}{1,-12}{2,8}\n", "Num", "Name", "Salary");
                                        WriteLine("{0,-5}{1,-12}{2,8}\n", tempP2.idNumber, tempP2.name, tempP2.balanceOwed.ToString("C"));
                                    }
                                    recordIn = reader2.ReadLine();
                                }
                                Console.WriteLine("Enter Another min balance:");
                                balance_owned = Convert.ToInt32(Console.ReadLine());
                            }
                            reader2.Close();
                            inFile2.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                            break;
                    default:
                        break;
                }
            } while (choice != "5");
        }
    }
}
