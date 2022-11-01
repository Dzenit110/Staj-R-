using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staj_r_backend.Models.Entities
{
    public record UserWToken
    {
        public string token { get; set; }
        public DateTime tokenExpiresOn { get; set; }
        public User user { get; set;}
    }
    public enum internships
    {
        StajI = 1, STAJII = 2, IME = 3
    }
    public record Status
    {
        public string status { get; set; }
        public string message { get; set; }
        public pages pageContent { get; set; }
        public string statusCode { get; set; }
    }
    public enum pages
    {
        empty = 1,
        apply = 2,
        report = 3,
        rating = 4
    }
    public record ReportPages
    {
        public string pageCode { get; set; }
        public string page { get; set; }
        public int pageNumber { get; set; }
        public string lastUpdate { get; set; }
    }
    public record internDateForDeps
    {
        public DateTime LastApply { get; set; }  //Son başvuru tarihidir
        public DateTime Start { get; set; } //Staj aralığı başlangıcıdır
        public DateTime Finish { get; set; }  //Staj aralığı sonudur
        public DateTime LastDocument { get; set; } //Son belge teslim tarihidir
    }
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
    public record Popup
    {
        //PUPUP EKRANI
        public string statusCode { get; set; }
        public string message { get; set; }
        public string interviewDate { get; set; }
        //Staj Başvuru Durumu
        public string applyStatusMessage { get; set; }
        public string applyDate { get; set; }
        //Staj Bilgileri Bölümü
        public string firm { get; set; }
        public string InternDate { get; set; }
        public int doesInternID { get; set; }
        //public InternInfo internInfo { get; set; }
        //Staj Değerlendirmesi Bölümü
        //public InternRating rating { get; set; }
        //public IMERating IMERating { get; set; }
    }
    public record InternInfo
    {
        public string firm { get; set; }
        public string date { get; set; }
    }

    public record role_auth
    {
        public int roleID { get; set; }
        public string role { get; set; }
        public List<string> authories { get; set; }
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

    public enum rolesDefault
    {
        Öğrenci = 7, Öğretim_Üyesi = 9, Kurul_Üyesi = 10, Bölüm_Yöneticisi = 11, Kurum_Yetkilisi = 15
    }


}
