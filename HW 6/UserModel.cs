using System;
using System.Collections.Generic;
using System.Text;

namespace HW_6
{
    class UserModel
    {
        public int id;
        public string name;
        public string login;
        public string password;
        public string address;
        public int age;

        public override string ToString()
        {
            return $"id={id}; name={name}; login={login}; password={password}; address={address}; age={age};";
        }
    }
}
