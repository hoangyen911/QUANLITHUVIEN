using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QUANLITHUVIEN.Models;

namespace QUANLITHUVIEN.Controllers
{
    public class NhaXBsController : Controller
    {
        private QUANLITHUVIENDbContext db = new QUANLITHUVIENDbContext();

        // GET: NhaXBs
        public ActionResult Index()
        {
            return View(db.NhaXBs.ToList());
        }

        // GET: NhaXBs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaXB nhaXB = db.NhaXBs.Find(id);
            if (nhaXB == null)
            {
                return HttpNotFound();
            }
            return View(nhaXB);
        }

        // GET: NhaXBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhaXBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhaXB,TenNhaXB,DiaChi")] NhaXB nhaXB)
        {
            if (ModelState.IsValid)
            {
                db.NhaXBs.Add(nhaXB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhaXB);
        }

        // GET: NhaXBs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaXB nhaXB = db.NhaXBs.Find(id);
            if (nhaXB == null)
            {
                return HttpNotFound();
            }
            return View(nhaXB);
        }

        // POST: NhaXBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhaXB,TenNhaXB,DiaChi")] NhaXB nhaXB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaXB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhaXB);
        }

        // GET: NhaXBs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaXB nhaXB = db.NhaXBs.Find(id);
            if (nhaXB == null)
            {
                return HttpNotFound();
            }
            return View(nhaXB);
        }

        // POST: NhaXBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhaXB nhaXB = db.NhaXBs.Find(id);
            db.NhaXBs.Remove(nhaXB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            //dat ten cho file
            string _FileName = "NhaXB.xls";
            //duong dan luu file
            string _path = Path.Combine(Server.MapPath("~/Uploads/Excels"), _FileName);
            //luu file len server
            file.SaveAs(_path);
            // đọc dữ liệu từ file Excel
            DataTable dt = ReadDataFromExcelFile(_path);
            //CopyDataByBulk(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhaXB xb = new NhaXB();
                xb.MaNhaXB= dt.Rows[i][0].ToString();
                xb.TenNhaXB = dt.Rows[i][1].ToString();
                xb.DiaChi = dt.Rows[i][2].ToString();
                db.NhaXBs.Add(xb);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        //doc file excel tra ve du lieu dang datatable
        public DataTable ReadDataFromExcelFile(string filepath)
        {
            string connectionString = "";
            string fileExtention = filepath.Substring(filepath.Length - 4).ToLower();
            if (fileExtention.IndexOf(".xlsx") == 0)
            {
                connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + filepath + ";Extended Properties=\"Excel 12.0 Xml;HDR=NO\"";
            }
            else if (fileExtention.IndexOf(".xls") == 0)
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0";
            }

            // Tạo đối tượng kết nối
            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            DataTable data = null;
            try
            {
                // Mở kết nối
                oledbConn.Open();

                // Tạo đối tượng OleDBCommand và query data từ sheet có tên "Sheet1"
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

                // Tạo đối tượng OleDbDataAdapter để thực thi việc query lấy dữ liệu từ tập tin excel
                OleDbDataAdapter oleda = new OleDbDataAdapter();

                oleda.SelectCommand = cmd;

                // Tạo đối tượng DataSet để hứng dữ liệu từ tập tin excel
                DataSet ds = new DataSet();

                // Đổ đữ liệu từ tập excel vào DataSet
                oleda.Fill(ds);

                data = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {
                // Đóng chuỗi kết nối
                oledbConn.Close();
            }
            return data;
        }
        private void CopyDataByBulk(DataTable dt)
        {
            //lay ket noi voi database luu trong file webconfig
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["QUANLITHUVIENDbContext"].ConnectionString);
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            bulkcopy.DestinationTableName = "HOCSINHs";
            bulkcopy.ColumnMappings.Add(0, "MaNhaXB");
            bulkcopy.ColumnMappings.Add(1, "TenNhaXB");
            bulkcopy.ColumnMappings.Add(2, "DiaChi");
            con.Open();
            bulkcopy.WriteToServer(dt);
            con.Close();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
