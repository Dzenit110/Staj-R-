using staj_r_backend.Helper.Token;
using staj_r_backend.Models;
using staj_r_backend.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace staj_r_backend.Controllers
{
    public class InternStdPagesController
    {
        private InternStdModel ism = new InternStdModel();
        public InternStdPagesController()
        {
            ism = new InternStdModel();
        }
        private TokenEntity getToken(string token)
        {
            return new Token().decrypt(token);
        }
        public async Task<bool> applyInternship(string token, internships type, BasvuruFormu form)
        {
            try
            {
                bool res = await ism.applyInternship(getToken(token).number, type, form);
                return res;
            }
            catch
            {
                return false;
            }
        }


        //Staj tarihleri gelen öğrencilere Staj Yapıyor 
        public async Task<bool> checkForStatus()
        {
            try
            {
                bool res = await ism.checkForStatus();
                return res;
            }
            catch
            {
                return false;
            }
        }

        //Şirketleri getirmek için kullanılır
        public async Task<Result<List<string>>> getCompanies()
        {
            try
            {
                var res = await ism.getCompanies();
                if (res == null)
                {
                    return new Result<List<string>>(false);
                }
                return new Result<List<string>>()
                {
                    isSuccess = true,
                    value = res,
                };
            }
            catch
            {
                return new Result<List<string>>(false);
            }
        }


        //https://github.com/BuyukAdamlar/staj-r/issues/39

        public async Task<Result<Status>> getStatus(string token, internships type)
        {
            try
            {
                var res = await ism.getStatus(getToken(token).number, type);
                if (res == null)
                {
                    return new Result<Status>(false);
                }
                return new Result<Status>()
                {
                    isSuccess = true,
                    value = res,
                };
            }
            catch
            {
                return new Result<Status>(false);
            }
        }

        public async Task<bool> updateBasvuruKabul(string token, internships type, BasvuruFormu form)
        {
            try
            {
                bool res = await ism.updateBasvuruKabul(getToken(token).number, type, form);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<Result<BasvuruFormu>> getBasvuruKabul(string token, internships type)
        {
            try
            {
                var res = await ism.getBasvuruKabul(getToken(token).number, type);
                if (res == null)
                {
                    return new Result<BasvuruFormu>(false);
                }
                return new Result<BasvuruFormu>()
                {
                    isSuccess = true,
                    value = res,
                };
            }
            catch
            {
                return new Result<BasvuruFormu>(false);
            }
        }

        #region report
        public async Task<Result<List<ReportPages>>> getReportList(string token, internships intern)
        {
            try
            {
                var res = await ism.getReportList(getToken(token).number, intern);
                if (res == null)
                {
                    return new Result<List<ReportPages>>(false);
                }
                return new Result<List<ReportPages>>()
                {
                    isSuccess = true,
                    value = res,
                };
            }
            catch
            {
                return new Result<List<ReportPages>>(false);
            }
        }
        public async Task<bool> addNewReport(string token, internships intern, ReportCover rc)
        {
            try
            {
                bool res = await ism.addNewReport(getToken(token).number, intern, rc);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> updateReportCover(string token, internships intern, ReportCover rc)
        {
            try
            {
                bool res = await ism.updateReportCover(getToken(token).number, intern, rc);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<Result<ReportCover>> getReportCover(string token, internships intern)
        {
            try
            {
                var res = await ism.getReportCover(getToken(token).number, intern);
                if (res == null)
                {
                    return new Result<ReportCover>(false);
                }
                return new Result<ReportCover>()
                {
                    isSuccess = true,
                    value = res,
                };
            }
            catch
            {
                return new Result<ReportCover>(false);
            }
        }
        public async Task<bool> addWeekToReport(string token, internships intern, WeekReport rc)
        {
            try
            {
                bool res = await ism.addWeekToReport(getToken(token).number, intern, rc);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> updateWeekReport(string token, internships intern, WeekReport rc, int pageNumber)
        {
            try
            {
                bool res = await ism.updateWeekReport(getToken(token).number, intern, rc, pageNumber);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<Result<WeekReport>> getWeekReport(string token, internships intern, int pageNumber)
        {
            try
            {
                var res = await ism.getWeekReport(getToken(token).number, intern, pageNumber);
                if (res == null)
                {
                    return new Result<WeekReport>(false);
                }
                return new Result<WeekReport>()
                {
                    isSuccess = true,
                    value = res,
                };
            }
            catch
            {
                return new Result<WeekReport>(false);
            }
        }
        public async Task<bool> addDailyToReport(string token, internships intern, DailyReport dr)
        {
            try
            {
                bool res = await ism.addDailyToReport(getToken(token).number, intern, dr);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> updateDailyReport(string token, internships intern, DailyReport rc, int pageNumber)
        {
            try
            {
                bool res = await ism.updateDailyReport(getToken(token).number, intern, rc, pageNumber);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<Result<DailyReport>> getDailyReport(string token, internships intern, int pageNumber)
        {
            try
            {
                var res = await ism.getDailyReport(getToken(token).number, intern, pageNumber);
                if (res == null)
                {
                    return new Result<DailyReport>(false);
                }
                return new Result<DailyReport>()
                {
                    isSuccess = true,
                    value = res,
                };
            }
            catch
            {
                return new Result<DailyReport>(false);
            }
        }
        public async Task<bool> deletePageOnReport(string token, internships intern, int pageNumber)
        {
            try
            {
                bool res = await ism.deletePageOnReport(getToken(token).number, intern, pageNumber);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> changeOrderOfTwoPage(string token, internships intern, int pageNumberOne, int pageNumberTwo)
        {
            try
            {
                bool res = await ism.changeOrderOfTwoPage(getToken(token).number, intern, pageNumberOne, pageNumberTwo);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> changeOrderOnReport(string token, internships intern, int currentPageNumber, int newPageNumber)
        {
            try
            {
                bool res = await ism.changeOrderOnReport(getToken(token).number, intern, currentPageNumber, newPageNumber);
                return res;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region rating
        public async Task<bool> addIMEDenetim(string token, IMEDenetim ime)
        {
            try
            {
                bool res = await ism.addIMEDenetim(getToken(token).number, ime);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> updateIMEDenetim(string token, IMEDenetim imd)
        {
            try
            {
                bool res = await ism.updateIMEDenetim(getToken(token).number, imd);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<Result<IMEDenetim>> getIMEDenetim(string token)
        {
            try
            {
                var res = await ism.getIMEDenetim(getToken(token).number);
                if (res == null)
                {
                    return new Result<IMEDenetim>(false);
                }
                return new Result<IMEDenetim>()
                {
                    isSuccess = true,
                    value = res,
                };
            }
            catch
            {
                return new Result<IMEDenetim>(false);
            }
        }
        public async Task<bool> addIMERating(string token, IMERating ime)
        {
            try
            {
                bool res = await ism.addIMERating(getToken(token).number, ime);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> updateIMERating(string token, IMERating imd)
        {
            try
            {
                bool res = await ism.updateIMERating(getToken(token).number, imd);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<Result<IMERating>> getIMERating(string token)
        {
            try
            {
                var res = await ism.getIMERating(getToken(token).number);
                if (res == null)
                {
                    return new Result<IMERating>(false);
                }
                return new Result<IMERating>()
                {
                    isSuccess = true,
                    value = res,
                };
            }
            catch
            {
                return new Result<IMERating>(false);
            }
        }
        public async Task<bool> addStajRating(string token, internships intern, StajRating sr)
        {
            try
            {
                bool res = await ism.addStajRating(getToken(token).number, intern, sr);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> updateStajRating(string token, internships intern, StajRating sr)
        {
            try
            {
                bool res = await ism.updateStajRating(getToken(token).number, intern, sr);
                return res;
            }
            catch
            {
                return false;
            }
        }
        public async Task<Result<StajRating>> getStajRating(string token, internships intern)
        {
            try
            {
                var res = await ism.getStajRating(getToken(token).number, intern);
                if (res == null)
                {
                    return new Result<StajRating>(false);
                }
                return new Result<StajRating>()
                {
                    isSuccess = true,
                    value = res,
                };
            }
            catch
            {
                return new Result<StajRating>(false);
            }
        }
        public async Task<Result<Status>> deliverDocuments(string token, internships intern)
        {
            try
            {
                var res = await ism.deliverDocuments(getToken(token).number, intern);
                if (res == null)
                {
                    return new Result<Status>(false);
                }
                return new Result<Status>()
                {
                    isSuccess = true,
                    value = res,
                };
            }
            catch
            {
                return new Result<Status>(false);
            }
        }
        #endregion
    }
}
