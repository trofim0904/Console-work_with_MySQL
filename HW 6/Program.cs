using System;
using System.Collections.Generic;

namespace HW_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<UserModel> userlist = Controler.getListofUsers();
            for (int i = 0; i < userlist.Count; i++)
            {
                Console.WriteLine(userlist[i]);
            }

            Controler.Update_User_by_ID(16, "petro", "petr777", "880055", "podval", 12);
            Controler.Update_Order_by_ID(3, "1K4F", "pen", "blue",16);

            List<OrderModel> list = Controler.getListofOrders();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }


            Console.ReadKey();
        }
    }
}
