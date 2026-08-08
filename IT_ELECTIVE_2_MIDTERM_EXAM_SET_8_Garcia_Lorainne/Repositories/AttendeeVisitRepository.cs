using System.Collections.Generic;
using System.Linq;
using IT_ELECTIVE_2_MIDTERM_EXAM_SET_8_Garcia_Lorainne.Models;

namespace IT_ELECTIVE_2_MIDTERM_EXAM_SET_8_Garcia_Lorainne.Repositories
{
    public class AttendeeVisitRepository
    {
        private static List<AttendeeVisit> attendees = new List<AttendeeVisit>();

        public List<AttendeeVisit> GetAll()
        {
            return attendees;
        }

        public AttendeeVisit GetById(int id)
        {
            return attendees.FirstOrDefault(a => a.Id == id);
        }

        public void Add(AttendeeVisit attendee)
        {
            attendee.Id = attendees.Count + 1;
            attendees.Add(attendee);
        }

        public void Update(AttendeeVisit attendee)
        {
            var existing = GetById(attendee.Id);

            if (existing != null)
            {
                existing.TicketNumber = attendee.TicketNumber;
                existing.FirstName = attendee.FirstName;
                existing.LastName = attendee.LastName;
                existing.Organization = attendee.Organization;
                existing.ContactNumber = attendee.ContactNumber;
                existing.Email = attendee.Email;
                existing.EventName = attendee.EventName;
                existing.CheckInTime = attendee.CheckInTime;
                existing.CheckOutTime = attendee.CheckOutTime;
                existing.Status = attendee.Status;
                existing.Notes = attendee.Notes;
            }
        }

        public List<AttendeeVisit> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return attendees;
            }

            return attendees.Where(a =>
                a.TicketNumber.Contains(keyword) ||
                a.FirstName.Contains(keyword) ||
                a.LastName.Contains(keyword) ||
                a.Organization.Contains(keyword) ||
                a.EventName.Contains(keyword)
            ).ToList();
        }
    }
}