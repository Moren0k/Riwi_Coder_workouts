using Microsoft.AspNetCore.Mvc;
using PruebaRutaAvanzada.Data;
using PruebaRutaAvanzada.Models;

namespace PruebaRutaAvanzada.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppDbContext _context;

        public AppointmentController(AppDbContext context)
        {
            _context = context; //DB
        }

        public IActionResult Index()
        {
            var mv = new ViewModel
            {
                //Enviar las listas a la vista
                Patients = _context.Patients.ToList(),
                Doctors = _context.Doctors.ToList(),
                Appointments = _context.Appointments.ToList()
            };
            return View(mv);
        }

        public IActionResult Create(Appointment appointment)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");

            try
            {
                // Validar disponible el doctor por fecha 
                if (_context.Appointments.Any(a => a.DoctorId == appointment.DoctorId && a.Date.Date == appointment.Date.Date))
                {
                    return RedirectToAction("Index");
                }

                // Validar disponible el paciente por fecha
                if (_context.Appointments.Any(a => a.PatientId == appointment.PatientId && a.Date.Date == appointment.Date.Date))
                {
                    return RedirectToAction("Index");
                }

                // Buscar doctor y paciente
                var doctor = _context.Doctors.FirstOrDefault(d => d.Id == appointment.DoctorId);
                var patient = _context.Patients.FirstOrDefault(p => p.Id == appointment.PatientId);

                // Crear mensaje email
                if (patient != null)
                {
                    var email = new Email
                    {
                        EmailTo = patient.Email,
                        Message = doctor != null 
                            ? $"Cita creada para {appointment.Date:dd/MM/yyyy} con el doctor {doctor.FirstName}" 
                            : $"Cita creada para {appointment.Date:dd/MM/yyyy}",
                        Status = "Enviado"
                    };
                    _context.Emails.Add(email);
                }
                // Guardar la cita en la DB
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la cita: " + ex.Message);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Appointment? appointmentEdit)
        {
            if (appointmentEdit == null) return RedirectToAction("Index");

            try
            {
                // Buscar la cita en la DB
                var appointment = _context.Appointments.FirstOrDefault(a => a.Id == appointmentEdit.Id);
                if (appointment == null) return RedirectToAction("Index");

                // Validar que no exista otra cita del mismo doctor en la misma fecha
                var existeCita = _context.Appointments
                    .Any(a => a.Id != appointmentEdit.Id 
                              && a.DoctorId == appointmentEdit.DoctorId 
                              && a.Date.Date == appointmentEdit.Date.Date);
                if (existeCita) return RedirectToAction("Index");

                // Actualizar los datos
                appointment.PatientId = appointmentEdit.PatientId;
                appointment.DoctorId = appointmentEdit.DoctorId;
                appointment.Date = appointmentEdit.Date;
                appointment.Reason = appointmentEdit.Reason;
                appointment.Status = appointmentEdit.Status;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al actualizar la cita: " + ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                //Buscar y eliminar una Cita
                var appointment = _context.Appointments.Find(id);
                if (appointment == null)
                {
                    return RedirectToAction("Index");
                }

                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Ocurrió un error al eliminar la cita.");
            }

            return RedirectToAction("Index");
        }

        public IActionResult DetailsAppointment(int id)
        {
            //Buscar los detalles de una Cita por el ID
            var appointment = _context.Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null)
            {
                return RedirectToAction("Index");
            }

            var mv = new ViewModel
            {
                Appointments = new List<Appointment> { appointment },
                Patients = _context.Patients.ToList(),
                Doctors = _context.Doctors.ToList()
            };
            return View(mv);
        }

        public IActionResult Cancelled(int id) //Marcar como Cancelada una Cita
        {
            try
            {
                //Buscar la cita por el ID
                var appointment = _context.Appointments.FirstOrDefault(a => a.Id == id);
                if (appointment == null)
                {
                    return RedirectToAction("Index");
                }

                //Cambiar el estado a cancelada
                appointment.Status = "Cancelada";
                _context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Ocurrió un error al cancelar la cita.");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Completed(int id) //Marcar como Completada una Cita
        {
            try
            {
                //Buscar la cita por el ID
                var appointment = _context.Appointments.FirstOrDefault(a => a.Id == id);
                if (appointment == null)
                {
                    return RedirectToAction("Index");
                }

                //Cambiar el estado a Completada
                appointment.Status = "Completada";
                _context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Ocurrió un error al completar la cita.");
            }

            return RedirectToAction("Index");
        }
    }
}