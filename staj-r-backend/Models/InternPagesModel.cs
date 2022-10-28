using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;
using staj_r_backend.Helper;

namespace staj_r_backend.Models
{
    // https://github.com/BuyukAdamlar/staj-r/issues/36
    public class InternPagesModel
    {
        private Executor ex;
        public InternPagesModel()
        {
            ex = new Executor();
        }
        public enum internships
        {
            StajI = 1, STAJII = 2, IME = 3
        }

        public record internDateForDeps
        {
            public DateTime LastApply { get; set; }  //Son başvuru tarihidir
            public DateTime Start { get; set; } //Staj aralığı başlangıcıdır
            public DateTime Finish { get; set; }  //Staj aralığı sonudur
            public DateTime LastDocument { get; set; } //Son belge teslim tarihidir
        }

        //Bu metot bölüm yöneticileri içindir
        public async Task<bool> manageApplyingDates(string number, internships en, internDateForDeps dates, bool isNewEra)
        {
            string internType = "";
            switch (en)
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
            string firstQuery = $"MATCH(u:User) WHERE u.number = '{number}' WITH u.department AS dep " +
                $"MATCH(d:Department) WHERE d.number=dep RETURN  d.{internType}lastApply AS a, d.{internType}internStart AS b, " +
                $"d.{internType}internFinish AS c, d.{internType}lastDocument AS d";
            var resFirst = await ex.executeOneNode(firstQuery);
            if (!isNewEra)
            {
                if ((DateTime)resFirst["a"] < dates.LastApply || (DateTime)resFirst["b"] < dates.Start ||
                (DateTime)resFirst["c"] > dates.Finish || (DateTime)resFirst["d"] > dates.LastDocument)
                {
                    throw new Exception("Öğrencinin aleyhinde tarih düzeltmesi yapılamaz.");
                }
            }
            string label = en.ToString();
            string query = "";
            if (isNewEra)
            {
                query = $"MATCH(u:User) WHERE u.number = '{number}' WITH u.department AS dep " +
              $"MATCH(d:Department) WHERE d.number=dep SET d.{internType}lastApply = date('{new LocalDate(dates.LastApply)}'), " +
              $"d.{internType}internStart = date('{new LocalDate(dates.Start)}'), " +
              $"d.{internType}internFinish = date('{new LocalDate(dates.Finish)}'), " +
              $"d.{internType}lastDocument = date('{new LocalDate(dates.LastDocument)}') " +
              $"WITH dep MATCH(u:User)-[:MEMBER]-(r:Role) WHERE u.department = d AND ID(r)=7 WITH u " +
              $"MATCH(u)-[:DOES]-(s:{label}) OPTIONAL MATCH(s)-[:DOc]-(q) DETACH DELETE q DETACH DELETE s";
            }
            else
            {
                query = $"MATCH(u:User) WHERE u.number = '{number}' WITH u.department AS dep " +
            $"MATCH(d:Department) WHERE d.number=dep SET d.{internType}lastApply = date('{new LocalDate(dates.LastApply)}'), " +
            $"d.{internType}internStart = date('{new LocalDate(dates.Start)}'), " +
            $"d.{internType}internFinish = date('{new LocalDate(dates.Finish)}'), " +
            $"d.{internType}lastDocument = date('{new LocalDate(dates.LastDocument)}')";
            }
            return await ex.executeReturnless(query);
        }
        //https://github.com/BuyukAdamlar/staj-r/issues/36

        public record studentDetails
        {
            public string number { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string email { get; set; }
            public string firm { get; set; }
            public string status { get; set; }
            public string statusCode { get; set; }
        }
        public async Task<List<studentDetails>> getStudents(string number /*Kurul üyesi hocanın numarası*/, internships i)
        {
            string query = $"MATCH(u:User) WHERE u.number='{number}' WITH u.department AS d " +
                $"MATCH(u:User)-[:DOES]->(s:{i.ToString()}) WHERE u.department = d RETURN " +
                $"u.number AS number, u.name AS name, u.surname AS surname, u.email AS email, s.firm AS firm, s.status AS status, s.statusCode AS code";
            var neoResult = await ex.execute(query);
            List<studentDetails> students = new List<studentDetails>();
            for (int j = 0; j < neoResult["number"].Count; j++)
            {
                students.Add(new studentDetails
                {
                    number = (string)neoResult["number"][j],
                    name = (string)neoResult["name"][j],
                    surname = (string)neoResult["surname"][j],
                    email = (string)neoResult["email"][j],
                    firm = (string)neoResult["firm"][j],
                    status = (string)neoResult["status"][j],
                    statusCode = (string)neoResult["statusCode"][j],
                });
            }
            return students;
        }
        #region studentDetails________POPUP
        public record Popup
        {
            //PUPUP EKRANI
            public string statusCode { get; set; }
            public string message { get; set; }
            public string interviewDate { get; set; }
            //Staj Başvuru Durumu
            public Apply apply { get; set; }
            //Staj Bilgileri Bölümü
            public InternInfo internInfo { get; set; }
            //Staj Değerlendirmesi Bölümü
            public InternRating rating { get; set; }
            public IMERating IMERating { get; set; }
        }
        public record Apply
        {
            public string applyStatusMessage { get; set; }
            public string applyDate { get; set; }
        }
        public async Task<Popup> getStudentDetails(string stdnumber, internships type)
        {
            string findStdQuery = $"MATCH(n:User)-[:DOES]->(s:{type.ToString()}) WHERE n.number = '{stdnumber}' RETURN " +
                $"s.applyDate AS apl, " +
                $"s.statusCode AS code, " +
                $"s.status, " +
                $"s.startDate AS strDt, " +
                $"s.finishDate AS fnsDt, " +
                $"s.firm AS firm, " +
                $"s.message AS m, " +
                $"s.interview AS intr, " +
                $"ID(s) AS id";
            var qres = await ex.executeOneNode(findStdQuery);
            string message = (string)qres["m"];
            DateTime interviewDt = (DateTime)qres["intr"];
            string interview = interviewDt.Year + "." + interviewDt.Month + "." + interviewDt.Day + " - " + interviewDt.Hour + ":" + interviewDt.Minute;
            long ID = (long)qres["id"];
            string code = (string)qres["code"];
            DateTime applyDate = (DateTime)qres["apl"];
            string applyStatusMessage = "";
            if(code == "a")
            {
                applyStatusMessage = "Öğrenci başvuru yapmıştır, onay beklenmektedir.";
            }
            else if(code == "b")
            {
                applyStatusMessage = "Öğrencinin başvurusu onaylanmamıştır";
            }
            else if(code == "c")
            {
                applyStatusMessage = "Öğrencinin başvurusu onaylanmıştır.";
            }
            Apply apply = new Apply
            {
                applyDate = applyDate.Day+"."+applyDate.Month+"."+applyDate.Year,
                applyStatusMessage = applyStatusMessage,
            }; ;
            InternInfo internInfo = null;
            InternRating rating = null;
            IMERating IMERating = null;
            if(code == "c" || code == "d" || code == "e" || code == "f" || code == "g" || code == "h")
            {
                string firm = (string)qres["firm"];
                DateTime startingDate = (DateTime)qres["strDt"];
                DateTime finishDate = (DateTime)qres["fnsDt"];
                internInfo = new InternInfo
                {
                    firm = firm,
                    date = "Staj Başlangıcı: " + startingDate.Day + "." + startingDate.Month + "." + startingDate.Year + "    Staj Bitişi: "
                    + finishDate.Day + "." + finishDate.Month + "." + finishDate.Year
                };
            }
            if(code == "f" || code == "g" || code == "h")
            {
                if(type != internships.IME)
                {
                    rating = await getIRatingDetails(ID);
                }
                else
                {
                    IMERating = await getIMERatingDetails(ID);
                }
            }
            Popup p = new Popup()
            {
                message = message,
                interviewDate = interview,
                apply = apply,
                internInfo = internInfo,
                rating = rating,
                IMERating = IMERating
            };
            return p;
        }
        public record InternInfo
        {
            public string firm { get; set; }
            public string date { get; set; }
        }
        public record InternRating
        {
            public string documentStatusMessage { get; set; }
            public string lastReportUpdateDate { get; set; }
            public string lastRatingUpdateDate { get; set; }
        }
        public record IMERating
        {
            public string documentStatusMessage { get; set; }
            public string lastAuditUpdateDate { get; set; }
            public string lastRatingUpdateDate { get; set; }
        }
        private async Task<InternRating> getIRatingDetails(long id)
        {
            string query = $"MATCH(s)-[:DOC]->(d:Document) WHERE ID(s) = {id} AND d.documentCode =   RETURN ";
            var res = await ex.executeOneNode(query);
            return new InternRating
            {
                //documentStatusMessage = ,
   
            };
        }
        private async Task<IMERating> getIMERatingDetails(long id)
        {
            string query = $"MATCH(s) WHERE ID(s) = {id}";
            var res = await ex.executeOneNode(query);
            return new IMERating
            {
                //lastAuditUpdateDate = ,
                //documentStatusMessage = ,
                //lastRatingUpdateDate=
            };
        }
        #endregion
    }
}
