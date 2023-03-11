using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.CommandTrees;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;


namespace HamaParcial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (DBhamaPrg db = new DBhamaPrg())


                
            {
                

                int choice;
                do
                {
                    
                    Console.WriteLine("Menu" + System.Environment.NewLine);
                    Console.WriteLine("1. Leer la lista de los pacientes" + System.Environment.NewLine);
                    Console.WriteLine("2. Agregar un nuevos paciente a la tabla" + System.Environment.NewLine);
                    Console.WriteLine("3. Editar Nombres y Apellidos de Pacientes" + System.Environment.NewLine);
                    Console.WriteLine("4. Borrar un registro" + System.Environment.NewLine);
                    Console.WriteLine("5. Salir del programa" + System.Environment.NewLine);
                    Console.Write("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Leer la lista de los pacientes" + System.Environment.NewLine);
                            //read method
                            var registro = db.mPacientes;
                            foreach (var readregistro in registro)
                            {
                                
                                Console.WriteLine(readregistro.IDPACIENTE + "  " + readregistro.NOMBRES + "  " + readregistro.APELLIDOS + "  " + readregistro.EXPEDIENTE + "  " + readregistro.IDENTIFICACION + "  " + readregistro.ESTATUS);
                                
                            }
                            //Console.Read();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Agregar un nuevos paciente a la tabla" + System.Environment.NewLine);

                            Console.Write("ID PACIENTE:  ");
                            Int32 IDPACIENTE = Convert.ToInt32(Console.ReadLine());

                            Console.Write("NOMBRE: ");
                            String NOMBRES = Console.ReadLine();

                            Console.Write("APELLIDOS: ");
                            String APELLIDOS = Console.ReadLine();

                            Console.Write("EXPENDIENTE: ");
                            Int32 EXPEDIENTE = Convert.ToInt32(Console.ReadLine());

                            Console.Write("IDENTIFICACION: ");
                            String IDENTIFICACION = Console.ReadLine();

                            Console.Write("ESTATUS: ");
                            Int32 ESTATUS = Convert.ToInt32(Console.ReadLine());


                            //add method
                            mPaciente addpaciente = new mPaciente();
                            addpaciente.IDPACIENTE =IDPACIENTE;
                            addpaciente.NOMBRES = NOMBRES;
                            addpaciente.APELLIDOS = APELLIDOS;
                            addpaciente.EXPEDIENTE = EXPEDIENTE;
                            addpaciente.IDENTIFICACION = IDENTIFICACION;
                            addpaciente.ESTATUS = ESTATUS;


                            db.AddTomPacientes(addpaciente);
                            db.SaveChanges();
                            Console.WriteLine("Se han guaradados los cambios");



                            break;
                        case 3:
                            //Edit method
                            Console.Clear();
                            Console.WriteLine("Actualizar Nombres y Apellidos de un paciente" + System.Environment.NewLine);
                            
                            Console.WriteLine("Escriba el Nombre que desea cambiar" + System.Environment.NewLine);

                            string currentName = Console.ReadLine();
                            Console.WriteLine("Escriba el Apellido que desea cambiar" + System.Environment.NewLine);
                            string currentLastname = Console.ReadLine();

                            var patient = db.mPacientes.Where(p => p.NOMBRES == currentName).FirstOrDefault();
                            var patient1 = db.mPacientes.Where(r => r.APELLIDOS == currentLastname).FirstOrDefault();

                            if (patient != null)
                            {
                                Console.Clear();
                                Console.WriteLine("Introduzca el nombre nuevo:" + System.Environment.NewLine);
                                patient.NOMBRES = Console.ReadLine();
                                Console.WriteLine("Introduzca el apellidonueva:" + System.Environment.NewLine);
                                patient1.APELLIDOS = Console.ReadLine();
                                db.SaveChanges();
                                Console.WriteLine("El nombre y Apellido del paciente han sido actualizados." + System.Environment.NewLine);
                            }
                            else
                            {
                                Console.WriteLine("No se encontro ningun paciente, intente nuevamente");
                            }


                            break;


                        case 4:
                            //delete method
                            Console.Clear();
                            Console.WriteLine("Introduzca el nombre que desea eliminar" + System.Environment.NewLine);
                            string patientName = Console.ReadLine();

                            var patient2 = db.mPacientes.Where(d => d.NOMBRES == patientName).FirstOrDefault();

                            if (patient2 != null)
                            {
                                
                                db.DeleteObject(patient2);
                                db.SaveChanges();
                                Console.WriteLine("El nombre del paciente ha sido eliminado");
                            }
                            else
                            {
                                Console.WriteLine("Ningun paciente ha sido encontrado, intente de nuevo");
                            }

                            

                            break;
                
                        case 5:
                            Console.WriteLine("Exiting the menu...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                    Console.WriteLine();
                } while (choice != 5);
            }
        }
    }
}

