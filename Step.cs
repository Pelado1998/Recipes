//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID
{
    /// <summary>
    /// Cumple con Expert ya que es el encargado de solamente conocer los pasos.
    /// Cumple con SRP ya que solo presenta una razón de cambio.
    /// </summary>
    public class Step
    {
        #region Exceptions
        public class InputException : System.Exception
        {
            public InputException() : base("El ingrediente no puede ser nulo") { }
        }
        public class InputNullException : System.Exception
        {
            public InputNullException() : base("La descripción es nula") { }
        }
        public class QuantityException : System.Exception
        {
            public QuantityException() : base("La cantidad no puede ser nulo o negativa") { }
        }
        public class QuantityNullException : System.Exception
        {
            public QuantityNullException() : base("La cantidad es nula o negativa") { }
        }
        public class EquipmentException : System.Exception
        {
            public EquipmentException() : base("El tiempo no puede ser nulo o negativo") { }
        }
        public class EquipmentNullException : System.Exception
        {
            public EquipmentNullException() : base("El equipo es nulo") { }
        }
        public class TimeException : System.Exception
        {
            public TimeException() : base("El tiempo es nulo o negativo") { }
        }

        #endregion
        public Step(Product input, double quantity, Equipment equipment, int time)
        {
            #region Preconditions
            if (input == null)
            {
                throw new InputException();
            }
            else if(quantity<=0)
            {
                throw new QuantityException();
            }
            else if(equipment == null)
            {
                throw new EquipmentNullException();
            }
            else if(time <= 0)
            {
                throw new EquipmentException();
            }
            #endregion

            this.Input = input;
            this.Quantity = quantity;
            this.Equipment = equipment;
            this.Time = time;

            #region Postconditions
            if (this.Input == null)
            {
                throw new InputNullException();
            }
            else if(this.Quantity <= 0)
            {
                throw new QuantityNullException();
            }
            else if(this.Equipment == null)
            {
                throw new EquipmentNullException();
            }
            else if(this.Time <= 0)
            {
                throw new TimeException();
            }
            #endregion
        }

        public Product Input { get; set; }

        public double Quantity { get; set; }

        public int Time { get; set; }

        public Equipment Equipment { get; set; }
    }
}