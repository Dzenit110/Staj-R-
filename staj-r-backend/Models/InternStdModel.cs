using staj_r_backend.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using staj_r_backend.Models.Entities;
using System.Reflection;
using System.Text.Json;
using Neo4j.Driver;

namespace staj_r_backend.Models
{
    //https://github.com/BuyukAdamlar/staj-r/issues/37
    public class InternStdModel
    {
        Executor ex;
        public InternStdModel()
        {
            ex = new Executor();
        }

        // Öğrenci başvuru yaptığında kullanılacak
        public enum internships
        {
            StajI = 1, STAJII = 2, IME = 3
        }
        public async Task<bool> applyInternship(string number, internships type, BasvuruFormu form)
        {
            form.ad_soyad_37CxVUq = (string)(await ex.executeOneNode($"MATCH(u:User) WHERE u.number = '{number}' RETURN u.name+' '+u.surname AS n"))["n"];
            string startDate = new LocalDate(form.baslama_tarihi_WAT4WzP).ToString();
            string finishDate = new LocalDate(form.bitis_tarihi_3B2FDZD).ToString();
            string firm = form.resmi_ad_Y2Rr3rQ;
            form.numara_KcftQzH = number;
            string formstr = JsonSerializer.Serialize(form);
            //var FormList = form.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToDictionary(prop => prop.Name, prop => prop.GetValue(form, null).ToString()).ToList();
            //List<string> list = new List<string>();
            //for (int j = 0; j < FormList.Count; j++)
            //{
            //    if (FormList[j].Value == null || FormList[j].Value.Trim() == "")
            //    {
            //        list.Add("-");
            //    }
            //    else
            //    {
            //        list.Add(FormList[j].Value.Trim());
            //    }
            //}
            //string formstr = JsonSerializer.Serialize(list);
            string label = type.ToString();
            string neoDt = new LocalDateTime(new DateTime(2000, 01, 01)).ToString();
            string query1 = $"MATCH(u:User) WHERE u.number = '{number}' CREATE(u)-[:DOES]->(s:{label}{{" +
                $"applyDate:date(), statusCode:'a', status: 'Başvuru Onayı Bekleniyor', startDate: date('{startDate}'), finishDate: date('{finishDate}'), firm:'{firm}', " +
                $"message:'Başvurunuz onay bekliyor.', interview: datetime('{neoDt}')}}) " +
                $"CREATE(s)-[:DOC]->(d:Document{{documentCode:'a', document:'Staj Başvuru Ve Kabul Formu', lastUpdate:date(), form:'{formstr}'}})";
            return await ex.executeReturnless(query1);
        }


        //Staj tarihleri gelen öğrencilere Staj Yapıyor 
        public async Task checkForStatus()
        {
            string query =
                $"MATCH(s:StajI) WHERE s.statusCode = 'c' AND s.startDate<=date() AND s.finishDate>=date() SET s.statusCode = 'd', s.status = 'Staj Yapılıyor'; " +
                $"MATCH(s:StajII) WHERE s.statusCode = 'c' AND s.startDate<=date() AND s.finishDate>=date() SET s.statusCode = 'd', s.status = 'Staj Yapılıyor'; " +
                $"MATCH(s:IME) WHERE s.statusCode = 'c' AND s.startDate<=date() AND s.finishDate>=date() SET s.statusCode = 'd', s.status = 'Staj Yapılıyor'; " +
                $"MATCH(s:StajI) WHERE s.statusCode = 'd' AND s.finishDate<=date() SET s.statusCode = 'e', s.status = 'Staj Sonlandı'; " +
                $"MATCH(s:StajII) WHERE s.statusCode = 'd' AND s.finishDate<=date() SET s.statusCode = 'e', s.status = 'Staj Sonlandı'; " +
                $"MATCH(s:IME) WHERE s.statusCode = 'd' AND s.finishDate<=date() SET s.statusCode = 'e', s.status = 'Staj Sonlandı';";
                if (!await ex.executeReturnless(query))
                {
                    throw new Exception();
                };
        }

        //Şirketleri getirmek için kullanılır
        public async Task<List<string>> getCompanies()
        {
            string query = $"MATCH(n) WHERE n:StajI OR n:StajII OR n:IME RETURN collect(distinct(n.firm)) AS f";
            var qres = (List<object>)(await ex.executeOneNode(query))["f"];
            List<string> list = new List<string>();
            foreach (var item in qres)
            {
                string str = (string)item;
                if (!list.Contains(str))
                {
                    list.Add(str);
                }
            }
            return list;
        }

        public record Status
        {
            public string status { get; set; }
            public string message { get; set; }
            public pages pageContent { get; set; }
            public string statusCode { get; set; }
        }

        //https://github.com/BuyukAdamlar/staj-r/issues/39

        public enum pages
        {
            empty = 1,
            apply = 2,
            report = 3,
            rating = 4
        }
        public async Task<Status> getStatus(string number, internships type)
        {
            int year = Convert.ToInt32("20" + number.Substring(0, 2));
            if (type == internships.StajI && year < 2)
            {
                return new Status()
                {
                    message = "Bu yıl Staj-I başvurusu yapamazsınız.",
                    statusCode = "z",
                    pageContent = pages.empty
                };
            }
            else if (type == internships.STAJII && year < 3)
            {
                return new Status()
                {
                    message = "Bu yıl Staj-II başvurusu yapamazsınız. ",
                    statusCode = "z",
                    pageContent = pages.empty
                };
            }
            else if (type == internships.IME && year < 3)
            {
                return new Status()
                {
                    message = "Bu yıl IME yapamazsınız.",
                    statusCode = "z",
                    pageContent = pages.empty
                };
            }
            string query = $"MATCH(u:User)-[:DOES]->(s:{type.ToString()}) WHERE u.number = '{number}' RETURN properties(s) AS s";
            var qres = await ex.executeOneNode(query);
            if (qres.Count == 0)
            {
                string tp = "";
                switch (type)
                {
                    case internships.StajI:
                        tp = "I";
                        break;
                    case internships.STAJII:
                        tp = "II";
                        break;
                    case internships.IME:
                        tp = "IME";
                        break;
                }
                string dateQuery = $"MATCH(u:User) WHERE u.number = '{number}' WITH u.department AS dep MATCH(d:Department) WHERE d.number = dep RETURN d.{tp}lastApply AS l";
                DateTime dt = (DateTime)(await ex.executeOneNode(dateQuery))["l"];
                string strDate = dt.Day + "." + dt.Month + "." + dt.Year;
                return new Status()
                {
                    statusCode = "y",
                    message = $"{type} başvurusu yapmadınız. Son başvuru tarihi: {strDate}",
                    pageContent = pages.apply
                };
            }
            else
            {
                var props = (Dictionary<string, object>)qres["s"];
                string code = (string)props["statusCode"];
                string status = (string)props["status"];
                string orgStatus = status;
                string message = (string)props["message"];
                DateTime interview = (DateTime)props["interview"];
                if(interview.Year != 2000)
                {
                    status += " \n\rMülakat tarihiniz ve saatiniz: " + interview.ToString();
                }
                status += " \n\rKuruldan son mesajınız: "+message;
                pages pg = pages.empty;
                switch (code)
                {
                    case "b": pg = pages.apply; 
                        break;
                    case "d": pg = pages.report;
                        break;
                    case "e": pg = pages.rating;
                        break;
                    default: pg = pages.empty; 
                        break;
                }
                return new Status()
                {
                    status = orgStatus,
                    message = status,
                    statusCode = code,
                    pageContent = pg
                };
            }
            //}
        }

        public async Task<bool> updateBasvuruKabul(string number, internships type, BasvuruFormu form)
        {
            string label = type.ToString();
            string formstr = JsonSerializer.Serialize(form);
            string query = $"MATCH(u:User)-[:DOES]->(s:{label}) WHERE u.number = '{number}' WITH s" +
                $"MATCH(s)-[:DOC]->(d:Document) WHERE documentCode = 'a' SET d.lastUpdate=date(), d.form='{formstr}'";
            return await ex.executeReturnless(query);
        }
    }
}
