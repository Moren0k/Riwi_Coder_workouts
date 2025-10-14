using Microsoft.AspNetCore.Mvc;
using PruebaRutaAvanzada.Data;
using PruebaRutaAvanzada.Models;

namespace PruebaRutaAvanzada.Controllers
{
    public class DoctorController : Controller
    {
        private readonly AppDbContext _context;

        public DoctorController(AppDbContext context)
        {
            _context = context; //DB
        }

        public IActionResult Index()
        {
            var mv = new ViewModel
            {   //Envío lista a la vista
                Patients = _context.Patients.ToList(),
                Doctors = _context.Doctors.ToList(),
                Appointments = _context.Appointments.ToList()
            };
            return View(mv);
        }

        public IActionResult Create(Doctor doctor) //Crear un Doctor
        {
            try
            {
                //Verificar que un Doctor no tenga el mismo documento que el que se va a crear
                if (_context.Doctors.Any(d => d.Document == doctor.Document))
                {
                    return RedirectToAction("Index");
                }
                
                //Poner (Nombre, Apellido, SegundoApellido) en minusculas
                doctor.FirstName = doctor.FirstName?.ToLower();
                doctor.LastName = doctor.LastName?.ToLower();
                doctor.SecondLastName = doctor.SecondLastName?.ToLower();
                
                //Validar que siempre se ingrese un Nombre y un Documento
                if (string.IsNullOrWhiteSpace(doctor.FirstName) || string.IsNullOrWhiteSpace(doctor.Document))
                {
                    return RedirectToAction("Index");
                }
                //Agregar a la tabla de Doctores
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Ocurrió un error al crear el doctor.");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Doctor? doctorEdit) //Editar un Doctor
        {
            try
            {
                //Buscar el Doctor y verificar que esté en la DB
                var doctor = _context.Doctors.FirstOrDefault(d => doctorEdit != null && d.Id == doctorEdit.Id);
                if (doctor == null)
                {
                    return RedirectToAction("Index");
                }
                
                //Verificar que el Documento editado no sea igual a uno ya en la DB
                if (_context.Doctors.Any(d => doctorEdit != null && d.Document == doctorEdit.Document && d.Id != doctorEdit.Id))
                {
                    return RedirectToAction("Index");
                }
                
                //Editar y guardar los nuevos datos del Paciente
                if (doctorEdit != null)
                {
                    doctor.FirstName = doctorEdit.FirstName?.ToLower();
                    doctor.LastName = doctorEdit.LastName?.ToLower();
                    doctor.SecondLastName = doctorEdit.SecondLastName?.ToLower();
                    doctor.Document = doctorEdit.Document;
                    doctor.Phone = doctorEdit.Phone;
                    doctor.Email = doctorEdit.Email;
                    doctor.Specialty = doctorEdit.Specialty;
                }
                _context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Ocurrió un error al actualizar el doctor.");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) //Eliminar un Doctor
        {
            try
            {
                //Buscar el paciente y Eliminar
                var doctor = _context.Doctors.Find(id);
                if (doctor == null)
                {
                    return RedirectToAction("Index");
                }
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Ocurrió un error al eliminar el doctor.");
            }
            return RedirectToAction("Index");
        }

        public IActionResult DetailsDoctor(int id) //Detalles
        {
            //Buscar los detalles del Doctor por el ID y mostrarlos en la vista
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return RedirectToAction("Index");
            }
            return View(doctor);
        }
    }
}