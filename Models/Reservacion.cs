﻿using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Models
{
    public class Reservacion
    {
        public int Id {  get; set; }   
        public int NumeroHabitacion { get; set; }
        public int IdCliente { get; set; } 
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int? NoPersonas { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; } 
        public virtual Habitacion? NumeroHabitacionNavigation { get; set; } 
    }
}
