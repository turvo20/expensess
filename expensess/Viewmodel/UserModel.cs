using System;
using System.Collections.Generic;
using System.Text;

namespace expensess.Viewmodel
{
    public class UserModel
    {
        public List<UserViewModel> Get()
        {
            List<UserViewModel> list = new List<UserViewModel>();
            list.Add(new UserViewModel { Name = "Anushka", Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRWR7fU-Ju22niixgRowQPqmhmMbv-4aKkcJQ" });
            list.Add(new UserViewModel { Name = "Rashmika", Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSK_5khGWXgQYUQIZOzibWuSgGInxReaCZBgQ" });
            list.Add(new UserViewModel { Name = "Katrina", Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQGzJ5pf0DCv9vt23kzS4bVrD5gdhOxSvS9ew" });
            list.Add(new UserViewModel { Name = "Ankita", Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQeK0yborsJrdFJJvpRG7puz0M4RCQ_S0Lclg" });
            list.Add(new UserViewModel { Name = "Priyanka", Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRyrfE8R1HiwkDpyp_3s3D7nPhoz4c2OdB1mA" });
            list.Add(new UserViewModel { Name = "Madhuri", Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTr3PWzPZ80p4DyexDIpuQB1qZXhCtJ4Qb2bw" });
            list.Add(new UserViewModel { Name = "Samantha", Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTiF6-L6aZqLaArzq_zkLJO-MRHCqWYIXFkPg" });
            return list;
        }
    }
}
