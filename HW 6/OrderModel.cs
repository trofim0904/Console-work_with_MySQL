using System;
using System.Collections.Generic;
using System.Text;

namespace HW_6
{
    class OrderModel
    {
        public int id;
        public string number;
        public string type;
        public string color;
        public UserModel user;
        public override string ToString()
        {
            return $"------------------------------------------------------\n| Id:{id} Number:{number} Type:{type} Color:{color} \n| User:[{user}]\n------------------------------------------------------";
        }
    }
}
