using BlazorServerCRUD.Web.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerCRUD.Web.Data;
using BlazorServerCRUD.Web.Context;
using System.IO;
using OfficeOpenXml;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace BlazorServerCRUD.Web.Repository
{
    public class JobsRepository : IJobsRepository
    {
        DatabaseContext _context;

        public JobsRepository (DatabaseContext context)
        {
            _context = context;

        }

        public List<JobAdvertisement> SaveExcel(string fileName)
        {
            var FilePath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}"+ "\\" + fileName;
            FileInfo fileInfo = new FileInfo(FilePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                int colCount = worksheet.Dimension.End.Column;
                int rowCount = worksheet.Dimension.End.Row;
                for (int row=2; row <= rowCount; row++)
                {
                    JobAdvertisement job = new JobAdvertisement();
                    for(int col=1; col<=colCount; col++)
                    {
                        if(col==1)job.WorkForm = worksheet.Cells[row, col].Value.ToString();
                        else if (col==2)job.Gender = worksheet.Cells[row, col].Value.ToString();
                        else if (col==3)job.Qualification = worksheet.Cells[row, col].Value.ToString();
                        else if (col==4)job.UniversityDep = worksheet.Cells[row, col].Value.ToString();
                        else if (col==5)job.Country = worksheet.Cells[row, col].Value.ToString();
                        else if (col==6)job.Category = worksheet.Cells[row, col].Value.ToString();
                        else if (col==7)job.Department = worksheet.Cells[row, col].Value.ToString();
                        else if (col==8)job.Page = worksheet.Cells[row, col].Value.ToString();
                        else if (col==9)job.Company = worksheet.Cells[row, col].Value.ToString();
                        else if (col==10)job.ReleaseDate = Convert.ToDateTime(worksheet.Cells[row, col].Value);
                        else if (col==11)job.NumberOfPerson = Convert.ToInt32(worksheet.Cells[row, col].Value.ToString());
                        else if (col==12)job.MilitaryStatus = worksheet.Cells[row, col].Value.ToString();
                        else if (col==13)job.Age = Convert.ToInt32(worksheet.Cells[row, col].Value.ToString());
                        else if (col==14)job.Experience = worksheet.Cells[row, col].Value.ToString();
                        else if (col==15)job.ForeignLang = worksheet.Cells[row, col].Value.ToString();
                        else if (col==16)job.ApplicationDate = worksheet.Cells[row, col].Value.ToString();
                        else if (col==17)job.EducationLevel = worksheet.Cells[row, col].Value.ToString();
                        else if (col==18)job.Sector = worksheet.Cells[row, col].Value.ToString();
                        else if (col==19)job.AdvNumber = Convert.ToInt32(worksheet.Cells[row, col].Value.ToString());
                        else if (col==20)job.UpdatedDate = Convert.ToDateTime(worksheet.Cells[row, col].Value);
                        else if (col==21)job.Position = worksheet.Cells[row, col].Value.ToString();
                        else if (col==22)job.Site = worksheet.Cells[row, col].Value.ToString();
                        else if (col==23)job.Salary = Convert.ToInt32(worksheet.Cells[row, col].Value.ToString());
                        else if (col==24)job.PositionLevel = worksheet.Cells[row, col].Value.ToString();
                    }
                    _context.Add(job);
                    _context.SaveChanges();

                    string[] files = Directory.GetFiles($"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}"+ "\\");
                    foreach (string file in files)    
                    {    
                    File.Delete(file);    
                    Console.WriteLine($"{file} is deleted.");    
                    }
                }
            }

            return _context.JobAdvertisements.ToList();
        }

        
        public List<JobAdvertisement> Delete()
        {
            JobAdvertisement job_ = new JobAdvertisement();
            
            int size = _context.JobAdvertisements.LongCount().GetHashCode();
            var job = _context.JobAdvertisements.Take(size).ToList();
            
            _context.RemoveRange(job);
            _context.SaveChanges();
           
            
            return _context.JobAdvertisements.ToList();
        }

       
    }
}