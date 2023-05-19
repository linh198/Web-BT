using Microsoft.AspNetCore.Mvc;

namespace Web_BT.Controllers
{
    public class LaisuatController : Controller
    {
        public IActionResult Giaodien()
        {
            return View();
        }
    [HttpPost]
        public IActionResult Giaodien(int sotiengui, int laisuatgui, int kyhangui)
        {
            try
            {
                if(laisuatgui == 0)
                {
                    ViewData["Message1"] = "Lãi suất gửi phải lớn hơn";
                }   
                if (kyhangui == 0)
                {
                    ViewData["Message2"] = "Kỳ hạn gửi phải lớn hơn";
                }
                if (sotiengui == 0)
                {
                    ViewData["Message3"] = "Số tiền gửi phải lớn hơn 0";
                }
                ViewData["Sotiengui"] = sotiengui;
                ViewData["Laisuatgui"] = laisuatgui;
                ViewData["Kyhangui"] = kyhangui;
         
                ViewData["Sotienlainhanduoc"] = (sotiengui * laisuatgui / 100) * ((double)kyhangui / 12);
                ViewData["Tongsotiennhanduockhidenhan"] = ((sotiengui * laisuatgui / 100) * ((double)kyhangui / 12) + sotiengui);
            }
            catch (DivideByZeroException)
            {
                ViewData["Message"] = "Thong tin nhap vao khong phu hop";

            }
            return View();
        }
    }
}
