using Neo4j.Driver;
using staj_r_backend.Helper;
using staj_r_backend.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

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
                $"message:'', interview: datetime('{neoDt}')}}) " +
                $"CREATE(s)-[:DOC]->(d:Document{{documentCode:'a', document:'Staj Başvuru Ve Kabul Formu', lastUpdate:date(), form:'{formstr}'}})";
            return await ex.executeReturnless(query1);
        }


        //Staj tarihleri gelen öğrencilere Staj Yapıyor 
        public async Task<bool> checkForStatus()
        {
            string query =
                $"MATCH(s:StajI) WHERE s.statusCode = 'c' AND s.startDate<=date() AND s.finishDate>=date() SET s.statusCode = 'd', s.status = 'Staj Yapılıyor'; " +
                $"MATCH(s:StajII) WHERE s.statusCode = 'c' AND s.startDate<=date() AND s.finishDate>=date() SET s.statusCode = 'd', s.status = 'Staj Yapılıyor'; " +
                $"MATCH(s:IME) WHERE s.statusCode = 'c' AND s.startDate<=date() AND s.finishDate>=date() SET s.statusCode = 'd', s.status = 'Staj Yapılıyor'; " +
                $"MATCH(s:StajI) WHERE s.statusCode = 'd' AND s.finishDate<date() SET s.statusCode = 'e', s.status = 'Staj Sonlandı'; " +
                $"MATCH(s:StajII) WHERE s.statusCode = 'd' AND s.finishDate<date() SET s.statusCode = 'e', s.status = 'Staj Sonlandı'; " +
                $"MATCH(s:IME) WHERE s.statusCode = 'd' AND s.finishDate<date() SET s.statusCode = 'e', s.status = 'Staj Sonlandı';";
            return await ex.executeReturnless(query);
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


        //https://github.com/BuyukAdamlar/staj-r/issues/39

        public async Task<Status> getStatus(string number, internships type)
        {
            int year = DateTime.Now.Year - Convert.ToInt32("20" + number.Substring(0, 2));
            if (type == internships.StajI && year < 2)
            {
                return new Status()
                {
                    message = "Bu yıl Staj-I başvurusu yapamazsınız.",
                    status = "Bu yıl Staj-I başvurusu yapamazsınız.",
                    statusCode = "z",
                    pageContent = pages.empty
                };
            }
            else if (type == internships.STAJII && year < 3)
            {
                return new Status()
                {
                    message = "Bu yıl Staj-II başvurusu yapamazsınız. ",
                    status = "Bu yıl Staj-II başvurusu yapamazsınız. ",
                    statusCode = "z",
                    pageContent = pages.empty
                };
            }
            else if (type == internships.IME && year < 3)
            {
                return new Status()
                {
                    message = "Bu yıl IME başvurusu yapamazsınız.",
                    status = "Bu yıl IME başvurusu yapamazsınız.",
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
                    status = "Başvuru yapılmadı",
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
                if (interview.Year != 2000)
                {
                    status += " \n\rMülakat tarihiniz ve saatiniz: " + interview.ToString();
                }
                status += " \n\rKuruldan son mesajınız: " + message;
                pages pg = pages.empty;
                switch (code)
                {
                    case "b":
                        pg = pages.apply;
                        break;
                    case "d":
                        pg = pages.report;
                        break;
                    case "e":
                        pg = pages.rating;
                        break;
                    default:
                        pg = pages.empty;
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
        }

        public async Task<bool> updateBasvuruKabul(string number, internships type, BasvuruFormu form)
        {
            string label = type.ToString();
            string formstr = JsonSerializer.Serialize(form);
            string query = $"MATCH(u:User)-[:DOES]->(s:{label}) WHERE u.number = '{number}' SET s.statusCode = 'a', s.status = 'Başvuru Onayı Bekleniyor' WITH s " +
                $"MATCH(s)-[:DOC]->(d:Document) WHERE documentCode = 'a' SET d.lastUpdate=date(), d.form='{formstr}'";
            return await ex.executeReturnless(query);
        }
        public async Task<BasvuruFormu> getBasvuruKabul(string number, internships type)
        {
            string label = type.ToString();
            string query = $"MATCH(u:User)-[:DOES]->(s:{label}) WHERE u.number = '{number}' WITH s " +
                $"MATCH(s)-[:DOC]->(d:Document) WHERE documentCode = 'a' RETURN d.form AS frm";
            string Json = (string)(await ex.executeOneNode(query))["frm"];
            return JsonSerializer.Deserialize<BasvuruFormu>(Json);
        }

        #region report
        public async Task<List<ReportPages>> getReportList(string number, internships intern)
        {
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(d:Document) WHERE d.documentCode = 'c' OR d.documentCode = 'd' OR d.documentCode = 'e' RETURN " +
                $"d.documentCode AS dc, " +
                $"d.document AS doc, " +
                $"d.pageNumber AS pn, " +
                $"d.lastUpdate AS lu";
            var qres = await ex.execute(query);
            List<ReportPages> res = new List<ReportPages>();
            for (int j = 0; j < qres["dc"].Count; j++)
            {
                DateTime dt = (DateTime)qres["lu"][j];
                res.Add(new ReportPages
                {
                    pageCode = (string)qres["dc"][j],
                    page = (string)qres["doc"][j],
                    pageNumber = Convert.ToInt32((long)qres["pn"][j]),
                    lastUpdate = dt.Day + "." + dt.Month + "." + dt.Year,
                });
            }
            return res;
        }
        public async Task<bool> addNewReport(string number, internships intern, ReportCover rc)
        {
            string formstr = JsonSerializer.Serialize(rc);
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern}) WHERE u.number = '{number}' " +
                $"OPTIONAL MATCH(s)-[:DOC]->(r:Document) WHERE r.documentCode = 'c' WITH s, COUNT(r) AS ct " +
                $"MERGE(s)-[:DOC]->(r:Document{{documentCode: 'c'}}) WITH  s, ct " +
                $"MATCH(s)-[:DOC]->(r:Document) WHERE ct = 0 AND r.documentCode = 'c' " +
                $"SET r.document = 'Staj Raporu Kapak - Bilgiler', r.lastUpdate = date(), r.form = '{formstr}', r.pageNumber = 2 RETURN COUNT(r) AS c";
            long res = (long)(await ex.executeOneNode(query))["c"];
            if (res == 0)
            {
                return false;
            }
            else if (res == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> updateReportCover(string number, internships intern, ReportCover rc)
        {
            string formstr = JsonSerializer.Serialize(rc);
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(r:Document) WHERE r.documentCode = 'c' SET r.form = '{formstr}', r.lastUpdate = date()";
            return await ex.executeReturnless(query);
        }
        public async Task<ReportCover> getReportCover(string number, internships intern)
        {
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(r:Document) WHERE r.documentCode = 'c' RETURN r.form AS form";
            var qres = await ex.executeOneNode(query);
            string formJson = (string)qres["form"];
            return JsonSerializer.Deserialize<ReportCover>(formJson);
        }
        public async Task<bool> addWeekToReport(string number, internships intern, WeekReport rc)
        {
            string form = JsonSerializer.Serialize(rc);
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(d:Document) WHERE d.pageNumber > 1 WITH s, MAX(d.pageNumber) AS mx " +
                $"CREATE(s)-[:DOC]->(d:Document{{documentCode: 'd', document: 'Staj Raporu - Haftalık', " +
                $"lastUpdate: date(), form: '{form}', pageNumber: mx}})";
            return await ex.executeReturnless(query);
        }
        public async Task<bool> updateWeekReport(string number, internships intern, WeekReport rc, int pageNumber)
        {
            string form = JsonSerializer.Serialize(rc);
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(d:Document) WHERE d.documentCode = 'd' AND d.pageNumber = {pageNumber} " +
                $"SET d.lastUpdate()=date(), d.form = '{form}'";
            return await ex.executeReturnless(query);
        }
        public async Task<WeekReport> getWeekReport(string number, internships intern, int pageNumber)
        {
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(d:Document) WHERE d.documentCode = 'd' AND d.pageNumber = {pageNumber} " +
                $"RETURN d.form AS form";
            var qres = await ex.executeOneNode(query);
            string formJson = (string)qres["form"];
            return JsonSerializer.Deserialize<WeekReport>(formJson);
        }
        public async Task<bool> addDailyToReport(string number, internships intern, DailyReport dr)
        {
            string form = JsonSerializer.Serialize(dr);
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(d:Document) WHERE d.pageNumber > 1 WITH s, MAX(d.pageNumber) AS mx " +
                $"CREATE(s)-[:DOC]->(d:Document{{documentCode: 'e', document: 'Staj Raporu - Günlük', " +
                $"lastUpdate: date(), form: '{form}', pageNumber: mx}})";
            return await ex.executeReturnless(query);
        }
        public async Task<bool> updateDailyReport(string number, internships intern, DailyReport rc, int pageNumber)
        {
            string form = JsonSerializer.Serialize(rc);
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(d:Document) WHERE d.documentCode = 'e' AND d.pageNumber = {pageNumber} " +
                $"SET d.lastUpdate()=date(), d.form = '{form}'";
            return await ex.executeReturnless(query);
        }
        public async Task<DailyReport> getDailyReport(string number, internships intern, int pageNumber)
        {
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(d:Document) WHERE d.documentCode = 'e' AND d.pageNumber = {pageNumber} " +
                $"RETURN d.form AS form";
            var qres = await ex.executeOneNode(query);
            string formJson = (string)qres["form"];
            return JsonSerializer.Deserialize<DailyReport>(formJson);
        }
        public async Task<bool> deletePageOnReport(string number, internships intern, int pageNumber)
        {
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                $"WITH {pageNumber} AS pn, s " +
                $"MATCH(s)-[:DOC]->(d:Document) WHERE d.pageNumber = pn " +
                $"OPTIONAL MATCH(s)-[:DOC]->(d2:Document) WHERE d2.pageNumber > pn " +
                $"DETACH DELETE d WITH d2 SET d2.pageNumber = d2.pageNumber-1";
            return await ex.executeReturnless(query);
        }
        public async Task<bool> changeOrderOfTwoPage(string number, internships intern, int pageNumberOne, int pageNumberTwo)
        {
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
               $"WITH {pageNumberOne} AS pno, {pageNumberTwo} AS pnt, s " +
               $"MATCH(s)-[:DOC]->(d:Document) WHERE d.pageNumber = pno " +
               $"MATCH(s)-[:DOC]->(d2:Document) WHERE d2.pageNumber = pnt " +
               $"SET d.pageNumber = pnt, d2.pageNumber = pno";
            return await ex.executeReturnless(query);
        }
        public async Task<bool> changeOrderOnReport(string number, internships intern, int currentPageNumber, int newPageNumber)
        {
            string query = "";
            if (currentPageNumber > newPageNumber)
            {
                query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                    $"WITH {currentPageNumber} AS cpn, {newPageNumber} AS npn, s " +
                    $"MATCH(s)-[:DOC]->(d:Document) WHERE d.pageNumber = cpn " +
                    $"OPTIONAL MATCH(s)-[:DOC]->(d2:Document) WHERE d2.pageNumber < cpn AND d2.pageNumber >= npn " +
                    $"SET d2.pageNumber = d2.pageNumber+1, d.pageNumber = npn";
            }
            else if (currentPageNumber < newPageNumber)
            {
                query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                    $"WITH {currentPageNumber} AS cpn, {newPageNumber} AS npn, s " +
                    $"MATCH(s)-[:DOC]->(d:Document) WHERE d.pageNumber = cpn " +
                    $"OPTIONAL MATCH(s)-[:DOC]->(d2:Document) WHERE d2.pageNumber > cpn AND d2.pageNumber <= npn " +
                    $"SET d2.pageNumber = d2.pageNumber-1, d.pageNumber = npn";
            }
            else
            {
                return true;
            }
            return await ex.executeReturnless(query);
        }
        #endregion
        #region rating
        public async Task<bool> addIMEDenetim(string number, IMEDenetim ime)
        {
            string form = JsonSerializer.Serialize(ime);
            string query = $"MATCH(u:User)-[:DOES]->(s:IME) WHERE u.number = '{number}' " +
                $"OPTIONAL MATCH(s)-[:DOC]->(r:Document) WHERE r.documentCode = 'g' WITH s, COUNT(r) AS ct " +
                $"MERGE(s)-[:DOC]->(r:Document{{documentCode:'g'}}) WITH  s, ct " +
                $"MATCH(s)-[:DOC]->(r:Document) WHERE ct = 0 AND r.documentCode = 'g' " +
                $"SET r.document = 'IME Denetim Formu', r.lastUpdate = date(), r.form = '{form}' RETURN COUNT(r) AS c";
            long res = (long)(await ex.executeOneNode(query))["c"];
            if (res == 0)
            {
                return false;
            }
            else if (res == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> updateIMEDenetim(string number, IMEDenetim imd)
        {
            string formstr = JsonSerializer.Serialize(imd);
            string query = $"MATCH(u:User)-[:DOES]->(s:IME) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(r:Document) WHERE r.documentCode = 'g' SET r.form = '{formstr}', r.lastUpdate = date()";
            return await ex.executeReturnless(query);
        }
        public async Task<IMEDenetim> getIMEDenetim(string number)
        {
            string query = $"MATCH(u:User)-[:DOES]->(s:IME) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(r:Document) WHERE r.documentCode = 'g' RETURN r.form AS form";
            var qres = await ex.executeOneNode(query);
            string formJson = (string)qres["form"];
            return JsonSerializer.Deserialize<IMEDenetim>(formJson);
        }
        public async Task<bool> addIMERating(string number, IMERating ime)
        {
            string form = JsonSerializer.Serialize(ime);
            string query = $"MATCH(u:User)-[:DOES]->(s:IME) WHERE u.number = '{number}' " +
                $"OPTIONAL MATCH(s)-[:DOC]->(r:Document) WHERE r.documentCode = 'h' WITH s, COUNT(r) AS ct " +
                $"MERGE(s)-[:DOC]->(r:Document{{documentCode:'h'}}) WITH  s, ct " +
                $"MATCH(s)-[:DOC]->(r:Document) WHERE ct = 0 AND r.documentCode = 'h' " +
                $"SET r.document = 'IME Değerlendirme Formu', r.lastUpdate = date(), r.form = '{form}' RETURN COUNT(r) AS c";
            long res = (long)(await ex.executeOneNode(query))["c"];
            if (res == 0)
            {
                return false;
            }
            else if (res == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> updateIMERating(string number, IMERating imd)
        {
            string formstr = JsonSerializer.Serialize(imd);
            string query = $"MATCH(u:User)-[:DOES]->(s:IME) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(r:Document) WHERE r.documentCode = 'h' SET r.form = '{formstr}', r.lastUpdate = date()";
            return await ex.executeReturnless(query);
        }
        public async Task<IMERating> getIMERating(string number)
        {
            string query = $"MATCH(u:User)-[:DOES]->(s:IME) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(r:Document) WHERE r.documentCode = 'h' RETURN r.form AS form";
            var qres = await ex.executeOneNode(query);
            string formJson = (string)qres["form"];
            return JsonSerializer.Deserialize<IMERating>(formJson);
        }
        public async Task<bool> addStajRating(string number, internships intern, StajRating sr)
        {
            string form = JsonSerializer.Serialize(sr);
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                $"OPTIONAL MATCH(s)-[:DOC]->(r:Document) WHERE r.documentCode = 'b' WITH s, COUNT(r) AS ct " +
                $"MERGE(s)-[:DOC]->(r:Document{{documentCode:'b'}}) WITH  s, ct " +
                $"MATCH(s)-[:DOC]->(r:Document) WHERE ct = 0 AND r.documentCode = 'b' " +
                $"SET r.document = 'Staj Değerlendirme Formu', r.lastUpdate = date(), r.form = '{form}' RETURN COUNT(r) AS c";
            long res = (long)(await ex.executeOneNode(query))["c"];
            if (res == 0)
            {
                return false;
            }
            else if (res == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> updateStajRating(string number, internships intern, StajRating sr)
        {
            string formstr = JsonSerializer.Serialize(sr);
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(r:Document) WHERE r.documentCode = 'b' SET r.form = '{formstr}', r.lastUpdate = date()";
            return await ex.executeReturnless(query);
        }
        public async Task<StajRating> getStajRating(string number, internships intern)
        {
            string query = $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE u.number = '{number}' " +
                $"MATCH(s)-[:DOC]->(r:Document) WHERE r.documentCode = 'h' RETURN r.form AS form";
            var qres = await ex.executeOneNode(query);
            string formJson = (string)qres["form"];
            return JsonSerializer.Deserialize<StajRating>(formJson);
        }
        public async Task<Status> deliverDocuments(string number, internships intern)
        {
            string internType = "";
            switch (intern)
            {
                case internships.StajI:
                    internType = "I";
                    break;
                case internships.STAJII:
                    internType = "II";
                    break;
                case internships.IME:
                    internType = "IME";
                    break;
            }
            string query = $"MATCH(u:User) WHERE u.number = '{number}' " +
                $"MATCH(d:Department) WHERE d.number = u.department " +
                $"MATCH(u:User)-[:DOES]->(s:{intern.ToString()}) WHERE d.{internType}lastDocument > date() " +
                $"SET s.statusCode = 'f', s.status = 'Değerlendirme Bekleniyor' RETURN COUNT(s) AS ct";
            long count = (long)(await ex.executeOneNode(query))["ct"];
            if (count == 0)
            {
                return null;
            }
            return await getStatus(number, intern);
        }


        #endregion
    }
}
