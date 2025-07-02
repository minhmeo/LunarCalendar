using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DDay.iCal.Serialization.iCalendar;
using System.Text.RegularExpressions;
using DDay.iCal;
using System.Security.Cryptography;
using LunarEventCalendar;

namespace LunarEventCalendar
{
    public partial class ExportAD : Form
    {
        public ExportAD()
        {
            InitializeComponent();
        }

        private void btnXuatICal_Click(object sender, EventArgs e)
        {
            LunarMethods CalProc = new LunarMethods();

            string[] allevents = txtEvents.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            IICalendar ical = new iCalendar();
            ical.Method = FormResource.iCal_Method;
            ical.ProductID = FormResource.iCal_ProdId;

            foreach (string s in allevents)
            {
                for (int year = Convert.ToInt32(txtStartFrom.Text); year <= Convert.ToInt32(txtTo.Text); year++)
                {
                    ADEvents evt = ADEvents.GetEventFromRawData(s);
                    evt.SetYear = year;

                    Event icalEvt = ical.Create<Event>();
                    icalEvt.CopyFrom(evt.ToICalEvent());
                }

            }

            string FilePath = string.Concat(FormResource.iCal_DefaultFolder, 
                string.Format(FormResource.iCal_FileNameFormat, txtStartFrom.Text, txtTo.Text));

            iCalendarSerializer serializer = new iCalendarSerializer();
            serializer.Serialize(ical, FilePath);
            MessageBox.Show(FormResource.Form_FinishConvertMsg, FormResource.Form_FinishConvertDlgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }

    public class ADEvents
    {
        public DateTime EventDDate { get; set; }
        public DateTime EventADate { get; set; }
        public int _Year = DateTime.Now.Year;
        public int SetYear
        {
            set
            {
                EventADate = new DateTime(value, EventADate.Month, EventADate.Day);
                UpdateSonarDate();
            }
        }

        public String EventName { get; set; }

        public ADEvents(String eventName)
        {
            EventName = eventName;
        }

        public ADEvents(DateTime ADate, String eventName)
            : this(eventName)
        {
            EventADate = ADate;
        }

        public override string ToString()
        {
            return string.Format(FormResource.iCal_EventToStringFormat, EventADate.Day, EventADate.Month, EventADate.Year, EventName);
        }

        public Event ToICalEvent()
        {
            Event result = new Event();
            result.Name = FormResource.iCal_EventName;
            result.Summary = string.Format(FormResource.iCal_EventTitleFormat, this.EventName, EventADate.ToString("dd/MM"));
            StringBuilder description = new StringBuilder();
            description.AppendLine(EventName);
            description.Append(FormResource.iCal_DescNgayAmLich);
            description.AppendLine(this.EventADate.ToString("dd/MM/yyyy"));
            description.Append(FormResource.iCal_DescNgayDuongLich);
            description.AppendLine(this.EventDDate.ToString("dd/MM/yyyy"));

            result.Description = description.ToString();
            result.Location = FormResource.iCal_Location;
            result.Status = EventStatus.Confirmed;
            result.IsAllDay = true;
            result.DTStart = new iCalDateTime(this.EventDDate);
            result.DTEnd = result.DTStart.AddDays(1);

            result.Class = FormResource.iCal_Class;
            result.LastModified = result.Created = iCalDateTime.Now;


            result.UID = BitConverter.ToString((new MD5CryptoServiceProvider()).ComputeHash(UnicodeEncoding.Default.GetBytes(this.ToString())));

            return result;
        }

        public static ADEvents GetEventFromRawData(string RawData)
        {
            try
            {
                Regex regexObj = new Regex(FormResource.Process_InputRegEx);
                int day = 0, month = 0;
                int.TryParse(regexObj.Match(RawData).Groups["day"].Value, out day);
                int.TryParse(regexObj.Match(RawData).Groups["month"].Value, out month);
                string name = regexObj.Match(RawData).Groups["event"].Value;
                ADEvents result = new ADEvents(new DateTime(DateTime.Now.Year, month, day), name);
                int[] sonar = (new LunarMethods()).Lunar2Solar(day, month, DateTime.Now.Year, 0);
                result.EventDDate = new DateTime(sonar[2], sonar[1], sonar[0]);
                return result;
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
                return null;
            }

        }

        public void UpdateSonarDate()
        {
            int[] sonar = (new LunarMethods()).Lunar2Solar(this.EventADate.Day, this.EventADate.Month, this.EventADate.Year, 0);
            this.EventDDate = new DateTime(sonar[2], sonar[1], sonar[0]);
        }


    }
}
