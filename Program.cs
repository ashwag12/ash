using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "teachers.txt";
            int s = 0;
            string id, name, clsec;
            Console.WriteLine("press 1 to add a teacher \n press 2 to search \n press 3 to update a record \n press 0 to exit");
        s=Convert.ToInt32( Console.ReadLine());
            while (s != 0) { 
                switch (s)
                {
                    case 1:
                        Console.WriteLine("\n enter the ID");
                     id=   Console.ReadLine();
                        Console.WriteLine("\n enter the NAME");
                    name=    Console.ReadLine();
                        Console.WriteLine("\n enter the CLASS");
                        clsec= Console.ReadLine();
                        addre(id, name, clsec, path);
                        break;


                    case 2:
                        Console.WriteLine("\n press 1 to search by ID \n press 2  to search by NAME \n press 3  to search by CLASS");
                        int ss = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n enter the value");
                     string   val = Console.ReadLine();
                        Console.WriteLine(string.Join(" ", search(val,path,ss)));
                        break;


                    case 3:
                        Console.WriteLine("\n press 1 to update by ID \n press 2  to update by NAME \n press 3  to update by CLASS");
                         ss = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n enter the value");
                         val = Console.ReadLine();
                        Console.WriteLine("\n enter the ID");
                        id = Console.ReadLine();
                        Console.WriteLine("\n enter the NAME");
                        name = Console.ReadLine();
                        Console.WriteLine("\n enter the CLASS");
                        clsec = Console.ReadLine();
                        update(val, path, ss, id, name, clsec);
                        break;
                }
                Console.WriteLine("\n press 1 to add a teacher \n press 2 to search \n press 3 to update a record \n press 0 to exit");
                s = Convert.ToInt32(Console.ReadLine());

            }
        }





        public static void addre(string ID , string NAME , string clsec,string path)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    file.WriteLine(ID+","+ NAME+","+ clsec);
                    Console.WriteLine("\n TEACHER HAS BEEN ADDED");

                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("something went wrong  :", e);
            }
        }






        public static string[] search(string searchteacher , string path , int place)
        {
            place--;
            string[] nothere = {" sorry! not found "};

            try
            {
                string[] line = System.IO.File.ReadAllLines(@path);
                for(int i = 0; i < line.Length; i++)
                {
                    string[] field = line[i].Split(',');
                    if (thereis(searchteacher, field, place))
                    {
                        Console.WriteLine("\n record found");
                        return field;
                    }

                }
                return nothere;
            }
            catch (Exception e)
            {
                return nothere;
                throw new ApplicationException("something went wrong  :", e);
            }



        }
     









public static void update (string searchteacher, string path, int place, string id, string name, string clsec)
        {
            place--;
            string temp = "temp.txt";
            bool updated = false ;

            try
            {
                string[] line = System.IO.File.ReadAllLines(@path);
                for (int i = 0; i < line.Length; i++)
                {
                    string[] field = line[i].Split(',');
                    if (!(thereis(searchteacher, field, place)))
                    {
                          addre(field[0], field[1], field[2], @temp);
                        Console.WriteLine("\n not found, nothing has been updated");

                    }
                    else
                    {
                        if (!updated)
                        {
                            addre(id, name, clsec, @temp);
                            Console.WriteLine("\n found");
                            updated = true;
                        }
                    }
                }
                if (updated)
                {
                    File.Delete(@path);
                    System.IO.File.Move(temp, path);
                    Console.WriteLine("\n updated");
                }
                else
                    File.Delete(temp);


            }
            catch (Exception ex)
            {
                throw new ApplicationException("something went wrong  :", ex);
            }



        }



        public static bool thereis(string searchteacher, string[] row, int place)
        {
            if (row[place].Equals(searchteacher))
            {
                return true;

            }
                return false;
        }
    }
}
