//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID
{
    /// <summary>
    /// Cumple con expert ya que es el experto en conocer la receta y sus pasos.
    /// Cumple con SRP ya que es una sola la razon de cambio que vemos nosotros.
    /// Cumple con Creator ya que crea recetas a partir de los pasos, con los cuales se relaciona.
    /// </summary>
    public class Recipe
    {
        #region Exceptions

         public class StepsModificationException : System.Exception
        {
            public StepsModificationException() : base("Se modificaron los pasos del porceso") { }
        }
        public class FinalProductModificationException : System.Exception
        {
            public FinalProductModificationException() : base("Se modificó el producto final en el proceso") { }
        }
        public class ConsoleEmptyException : System.Exception
        {
            public ConsoleEmptyException() : base("No se escribió nada por consola") { }
        }
        public class ConsoleException : System.Exception
        {
            public ConsoleException() : base("No se pudo escribir por consola") { }
        }
        public class InputException : System.Exception
        {
            public InputException() : base("El ingrediente no puede ser nulo") { }
        }
        public class QuantityException : System.Exception
        {
            public QuantityException() : base("La cantidad no puede ser nulo o negativa") { }
        }
        public class EquipmentException : System.Exception
        {
            public EquipmentException() : base("El tiempo no puede ser nulo o negativo") { }
        }
        public class EquipmentNullException : System.Exception
        {
            public EquipmentNullException() : base("El equipo no puede ser nulo") { }
        }
        public class TimeException : System.Exception
        {
            public TimeException(string message) : base(message) { }
        }
        public class TimeNullException : System.Exception
        {
            public TimeNullException(string message) : base(message) { }
        }
        public class StepsNullException : System.Exception
        {
            public StepsNullException() : base("El paso no puede ser nulo") { }
        }
        public class FinalProductException : System.Exception
        {
            public FinalProductException() : base("El paso no puede ser nulo") { }
        }
        public class RecipeCapacityException : System.Exception
        {
            public RecipeCapacityException() : base("Se llegó al máximo de pasos para una receta") { }
        }
        public class RecipeMaxCapacityException : System.Exception
        {
            public RecipeMaxCapacityException() : base("Se obtuvo el máximo de pasos para una receta") { }
        }
        public class RecipeMinCapacityException : System.Exception
        {
            public RecipeMinCapacityException() : base("Se obtuvo una receta vacía") { }
        }
        public class RecipeEmptyException : System.Exception
        {
            public RecipeEmptyException() : base("La receta no puede estar vacia") { }
        }
        public class NotAdded : System.Exception
        {
            public NotAdded() : base("No fue agregado a la receta") { }
        }
        public class NotRemoved : System.Exception
        {
            public NotRemoved() : base("No fue quitado de la receta") { }
        }
        #endregion

        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            #region Preconditions
            if (step == null)
            {
                throw new StepsNullException();
            }
            else if (50<=steps.Count+1)
            {
                throw new RecipeCapacityException();
            }
            #endregion
            
            this.steps.Add(step);

            #region Postconditions
            if (this.steps[this.steps.Count-1] != step)
            {
                throw new NotAdded();
            }
            else if(this.steps.Count == 50)
            {
                throw new RecipeMaxCapacityException();
            }
            #endregion
        }

        public void RemoveStep(Step step)
        {
            #region Preconditions
            if (step == null)
            {
                throw new StepsNullException();
            }
            else if (steps.Count<=0)
            {
                throw new RecipeEmptyException();
            }
            #endregion

            this.steps.Remove(step);

            #region Postconditions
            if (this.steps.Contains(step))
            {
                throw new NotRemoved();
            }
            else if(this.steps.Count < 0)
            {
                throw new RecipeMinCapacityException();
            }
            #endregion
        }

        public void PrintRecipe()
        {
            #region Invariant
            ArrayList copySteps = this.steps;
            Product copyFinalProduct = this.FinalProduct;
            #endregion
            #region Preconditions
            if (this.steps == null)
            {
                throw new StepsNullException();
            }
            else if (this.FinalProduct == null)
            {
                throw new FinalProductException();
            }
            foreach (Step step in this.steps)
            {
                if (step.Input == null)
                {
                    throw new InputException();
                }
                else if(step.Quantity<=0)
                {
                    throw new QuantityException();
                }
                else if(step.Equipment == null)
                {
                    throw new EquipmentNullException();
                }
                else if(step.Time <= 0)
                {
                    throw new EquipmentException();
                }
            }
            
            #endregion
            

            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }

            #region Postconditions
            if (Console.Error == System.IO.TextWriter.Null)
            {
                throw new ConsoleException();
            }
            else if(Console.Out == null)
            {
                throw new ConsoleEmptyException();
            }
            #endregion

            #region Invariant
            if (copySteps !=this.steps)
            {
                throw new StepsModificationException();
            }
            else if (copyFinalProduct != this.FinalProduct)
            {
                throw new FinalProductModificationException();
            }
            #endregion

        }
    }
}