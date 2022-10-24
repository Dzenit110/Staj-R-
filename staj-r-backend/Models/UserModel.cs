using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using staj_r_backend.Models.Entities;
using staj_r_backend.Helper;
using System.Text.Json;

namespace staj_r_backend.Models
{
    public class UserModel
    {
        public async Task<bool> registerModel(string number, string name, string surname, string email, string password, string department, int roleID)
        {
            try
            {
                string query = $"CREATE(u:User{{number:'{number}', name:'{name}', surname: '{surname}', email:'{email}',password:'{password}', department:'{department}'}}) " +
                    $"WITH u MATCH(r:Role) WHERE ID(r)={roleID} CREATE(u)-[:MEMBER]->(r)";
                Executor ex = new Executor();
                return await ex.executeReturnless(query);
            }
            catch
            {
                return false;
            }
        }

        //İkililerden ilk string rol adı, ikinci string ise yetkilerdir
        public record role_auth
        {
            public int roleID { get; set; }
            public string role { get; set; }
            public List<string> authories { get; set; }
        }
        public async Task<List<role_auth>> getRoles()
        {
            Executor ex = new Executor();
            var res = new List<role_auth>();
            var response = await ex.execute("MATCH(n:Role) RETURN n.name AS n, n.authorities AS a, ID(n) AS i");
            for (int j = 0; j < response["n"].Count; j++)
            {
                string _role = (string)response["n"][j];
                int _id = Convert.ToInt32((long)response["i"][j]);
                List<string> _authories = new List<string>();
                if (response["a"][j] != null)
                {
                    foreach (object auth in (List<object>)response["a"][j])
                    {
                        _authories.Add(((string)auth).ToString());
                    }
                }
                res.Add(new role_auth { roleID = _id, role = _role, authories = _authories });
            }
            return res;
        }

        public async Task<bool> createRole(string name, List<string> authorities)
        {
            try
            {
                string auth = "[";
                for (int j = 0; j < authorities.Count; j++)
                {
                    if (j == authorities.Count - 1)
                    {
                        auth += $"'{authorities[j]}'";
                    }
                    else
                    {
                        auth += $"'{authorities[j]}',";
                    }
                }
                auth += "]";
                string query = "CREATE(n:Role{name:'" + name + "', authorities:" + auth + "})";
                Executor ex = new Executor();
                return await ex.executeReturnless(query);
            }
            catch
            {
                return false;
            }

        }

        public record userList
        {
            public string roleName { get; set; }
            public int roleID { get; set; }
            public string number { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string email { get; set; }
        }

        #region Kullanıcılar sayfası popup

        //int: RoleID,   string:Role Name  //Number parametresi siteye giriş yapmış olan kullanıcının numarasıdır.
        public async Task<Dictionary<int, string>> getRolesForDropDown(string number)
        {
            Dictionary<int,string> result = new Dictionary<int,string>();
            string query = $"MATCH(u:User)-[:MEMBER]->(r:Role) WHERE u.number = '{number}' WITH r.authorities AS a " +
                $"MATCH(r:Role) WHERE apoc.coll.containsAll(a,r.authorities)=true AND size(a)>size(r.authorities) RETURN r.name AS n, ID(r) AS i";
            Executor ex = new Executor();
            var queryResult = await ex.execute(query);
            for(int j=0; j < queryResult["n"].Count; j++)
            {
                result.Add((int)queryResult["n"][j], (string)queryResult["i"][j]);
            }
            return result;
        }

        public async Task<bool> updateRole(string number, int roleID) //Değişim yapılacak kullanıcının numarası
        {
            string query = $"MATCH(u:User)-[m:MEMBER]->(:Role) WHERE u.number = '{number}' " +
                $"DELETE m MATCH(r:Role) WHERE ID(r)={roleID} CREATE(n)-[:MEMBER]->(r)";
            Executor ex = new Executor();
            return await ex.executeReturnless(query);
        }
        public async Task<bool> updateEmail(string number, string newEmail) //Değişim yapılacak kullanıcının numarası
        {
            Executor ex = new Executor();
            string query = $"MATCH(u:User) WHERE u.number = '{number}' SET u.email = '{newEmail}'";
            return await ex.executeReturnless(query);
        }

        //Döndürdüğü listenin ilke lemenaı kullanıcının ismi, ikinci elemanı da eposta adresidir.
        public async Task<List<string>> updatePassword(string number, string password) //Değişim yapılacak kullanıcının numarası, şifre controller'dan encryp edilip gelecek
        {
            Executor ex = new Executor();
            string query = $"MATCH(u:User) WHERE u.number = '{number}' SET u.password = '{password}' RETURN u.name AS n, u.email AS e";
            var qRes = await ex.executeOneNode(query);
            List<string> res = new List<string>
            {
                (string)qRes["n"], (string)qRes["e"]
            };
            return res;
        }
        #endregion
        public async Task<List<userList>> getUsers(string number)
        {
            Executor ex = new Executor();
            var searcher = await ex.executeOneNode($"MATCH(u:User) WHERE u.number = '{number}' " +
                $"MATCH(u)-[:MEMBER]->(r:Role) RETURN r.authorities AS a, u.department AS d");
            var q = ((List<object>)searcher["a"]).Select(e=>(string)e).ToList();
            string authList= JsonSerializer.Serialize(q);
            string dep = (string)searcher["d"];
            string query = $"MATCH(u:User)-[:MEMBER]-(r:Role) WHERE apoc.coll.containsAll({authList},r.authorities)=true AND size({authList})>size(r.authorities) " +
                $"RETURN DISTINCT(u.number) AS number, u.name AS name, u.surname AS surname, u.email AS email, r.name AS roleName, ID(r) AS roleID";
            var QueryResult= await ex.execute(query);
            List<userList> ul = new List<userList>();
            for(int j = 0; j < QueryResult["number"].Count; j++)
            {
                ul.Add(new userList
                {
                    roleName = (string)QueryResult["roleName"][j],
                    roleID = Convert.ToInt32((long)QueryResult["roleID"][j]),
                    number = (string)QueryResult["number"][j],
                    name = (string)QueryResult["name"][j],
                    surname=(string)QueryResult["surname"][j],
                    email=(string)QueryResult["email"][j]
                });
            }
            return ul;

            ////d içeriyorsa öğrenciler gelebilir

            //if (q.Contains((object)"d"))
            //{
            //    string query1 = $"MATCH(u:User)-[:MEMBER]->(r:Role) WHERE u.department='{dep}' AND ID(r)=7 RETURN DISTINCT(u.number) AS number, u.name AS name, u.surname AS surname, u.email AS email";
            //    var res1 = await ex.execute(query1);
            //    if (res1.Count != 0)
            //    {
            //        for (int j = 0; j < res1["number"].Count; j++)
            //        {
            //            ul.Add(new userList
            //            {
            //                roles = "Öğrenci",
            //                number = (string)res1["number"][j],
            //                name = (string)res1["name"][j],
            //                surname = (string)res1["surname"][j],
            //                email = (string)res1["email"][j],
            //            });
            //        }
            //    }
                
            //}
            ////f içeriyorsa öğretim üyeleri gelebilir
            //if (q.Contains((object)"f"))
            //{
            //    string query2 = $"MATCH(u:User)-[:MEMBER]->(r:Role) WHERE u.department='{dep}' AND ID(r)=9 RETURN DISTINCT(u.number) AS number, u.name AS name, u.surname AS surname, u.email AS email";
            //    var res2 = await ex.execute(query2);
            //    if (res2.Count != 0)
            //    {
            //        for (int j = 0; j < res2["number"].Count; j++)
            //        {
            //            ul.Add(new userList
            //            {
            //                roles = "Öğretim Üyesi",
            //                number = (string)res2["number"][j],
            //                name = (string)res2["name"][j],
            //                surname = (string)res2["surname"][j],
            //                email = (string)res2["email"][j],
            //            });
            //        }
            //    }
                
            //}
            ////h içeriyorsa kurul gelebilir
            //if (q.Contains((object)"h"))
            //{
            //    string query3 = $"MATCH(u:User)-[:MEMBER]->(r:Role) WHERE u.department='{dep}' AND ID(r)=10 RETURN DISTINCT(u.number) AS number, u.name AS name, u.surname AS surname, u.email AS email";
            //    var res3 = await ex.execute(query3);
            //    if (res3.Count != 0)
            //    {
            //        for (int j = 0; j < res3["number"].Count; j++)
            //        {
            //            ul.Add(new userList
            //            {
            //                roles = "Kurul Üyesi",
            //                number = (string)res3["number"][j],
            //                name = (string)res3["name"][j],
            //                surname = (string)res3["surname"][j],
            //                email = (string)res3["email"][j],
            //            });
            //        }
            //    }
                
            //}
            ////j içeriyorsa bölüm yöneticileri gelebilir
            //if (q.Contains((object)"j"))
            //{
            //    string query4 = $"MATCH(u:User)-[:MEMBER]->(r:Role) WHERE u.department='{dep}' AND ID(r)=11 RETURN DISTINCT(u.number) AS number, u.name AS name, u.surname AS surname, u.email AS email";
            //    var res4 = await ex.execute(query4);
            //    if (res4.Count != 0)
            //    {
            //        for (int j = 0; j < res4["number"].Count; j++)
            //        {
            //            ul.Add(new userList
            //            {
            //                roles = "Bölüm Yöneticisi",
            //                number = (string)res4["number"][j],
            //                name = (string)res4["name"][j],
            //                surname = (string)res4["surname"][j],
            //                email = (string)res4["email"][j],
            //            });
            //        }
            //    } 
            //}
            //IDictionary<string, List<string>> roleauths = new Dictionary<string, List<string>>();
            //roleauths.Add("Öğrenci", new List<string>());
            //roleauths.Add("Öğretim Üyesi", new List<string>() {"d"});
            //roleauths.Add("Kurul Üyesi", new List<string>() { "a", "b", "c" });
            //roleauths.Add("Bölüm Yöneticisi", new List<string>() { "d", "e", "f", "g", "h", "i" });
            //roleauths.Add("Kurum Yetkilisi", new List<string>() { "j", "k" });
            //List<string> deletingUsers = new List<string>();
            //for(int j = 0; j < ul.Count; j++)
            //{
            //    if (roleauths[ul[j].roles].Count != 0)
            //    {
            //        //if (!q.Contains(roleauths[ul[j].roles]) || q.Count == roleauths[ul[j].roles].Count)
            //        //{
            //        //    if (!deletingUsers.Contains(ul[j].number))
            //        //    {
            //        //        deletingUsers.Add(ul[j].number);
            //        //    }
            //        //}
            //    }
            //}
            //for(int j = 0; j < ul.Count; j++)
            //{
            //    if(deletingUsers.Contains(ul[j].number))
            //    {
            //        ul.Remove(ul[j]);
            //    }
            //}
            //for (int i = 0; i < ul.Count; i++)
            //{
            //    for(int j = i+1; j<ul.Count; j++)
            //    {
            //        if (ul[i].number == ul[j].number)
            //        {
            //            ul[i].roles += ", " + ul[j].roles;
            //            ul.Remove(ul[j]);
            //        }
            //    }
            //} 
            //return ul;
        }
    }
}
