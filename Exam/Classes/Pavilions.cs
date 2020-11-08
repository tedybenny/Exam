using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Classes
{
    public class pavilion
    {
        public pavilion(int ID,string Name,string Num,int Floor,string Status,double Area, double Areacost,double Ratio)
        {
            idpavilion = ID;
            mall_name = Name;
            number = Num;
            floor = Floor;
            status = Status;
            area = Area;
            areacost = Areacost;
            added_value_ratio = Ratio;
        }


        public int idpavilion { get; set; }
        public string mall_name { get; set; }
        public string number { get; set; }
        public int floor { get; set; }
        public string status { get; set; }
        public double area { get; set; }
        public double areacost { get; set; }
        public double added_value_ratio { get; set; }
    }
}
