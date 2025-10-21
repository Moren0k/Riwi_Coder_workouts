using Microsoft.AspNetCore.Mvc;
using PruebaRutaAvanzada.Data;
using PruebaRutaAvanzada.Models;

namespace PruebaRutaAvanzada.Controllers
{
    public class PatientController : Controller
    {
        private readonly AppDbContext _context;

        public PatientController(AppDbContext context)
        {
            _context = context; //DB
        }

        public IActionResult Index()
        {
            var mv = new ViewModel
            {   //Envío listas a la vista
                Patients = _context.Patients.ToList(),
                Doctors = _context.Doctors.ToList(),
                Appointments = _context.Appointments.ToList()
            };
            return View(mv);
        }

        public IActionResult Create(Patient patient) //Crear un Paciente
        {
            try
            {
                //Verificar que un Paciente no tenga el mismo documento que el que se va a crear
                if (_context.Patients.Any(p => p.Document == patient.Document))
                {
                    return RedirectToAction("Index");
                }
                
                //Poner (Nombre, Apellido, SegundoApellido) en minusculas
                patient.FirstName = patient.FirstName?.ToLower();
                patient.LastName = patient.LastName?.ToLower();
                patient.SecondLastName = patient.SecondLastName?.ToLower();
                
                //Validar que siempre se ingrese un Nombre y un Documento
                if (string.IsNullOrWhiteSpace(patient.FirstName) || string.IsNullOrWhiteSpace(patient.Document))
                {
                    return RedirectToAction("Index");
                }
                //Agregar a la tabla de Pacientes
                _context.Patients.Add(patient);
                _context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Ocurrió un error al crear el paciente.");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Patient? patientEdit) //Editar un Paciente
        {
            if (patientEdit == null)
                return RedirectToAction("Index");

            try
            {
                var patient = _context.Patients.FirstOrDefault(p => p.Id == patientEdit.Id);
                if (patient == null)
                    return RedirectToAction("Index");

                // Evitar duplicados en documentos
                if (_context.Patients.Any(p => p.Id != patientEdit.Id && p.Document == patientEdit.Document))
                    return RedirectToAction("Index");

                // Actualizar campos
                patient.FirstName = patientEdit.FirstName?.ToLower();
                patient.LastName = patientEdit.LastName?.ToLower();
                patient.SecondLastName = patientEdit.SecondLastName?.ToLower();
                patient.Document = patientEdit.Document;
                patient.Phone = patientEdit.Phone;
                patient.Email = patientEdit.Email;
                patient.Age = patientEdit.Age;

                _context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Ocurrió un error al actualizar el paciente.");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) //Eliminar un Paciente
        {
            try
            {
                //Buscar el paciente y Eliminar
                var patient = _context.Patients.Find(id);
                if (patient == null)
                {
                    return RedirectToAction("Index");
                }
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Ocurrió un error al eliminar el paciente.");
            }
            return RedirectToAction("Index");
        }

        public IActionResult DetailsPatient(int id) //Detalles
        {
            //Buscar los detalles del Paciente por el ID y mostrarlos en la vista
            var patient = _context.Patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return RedirectToAction("Index");
            }
            return View(patient);
        }
    }
}