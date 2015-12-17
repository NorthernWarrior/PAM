using PAM.MVVM;
using PAM.Interfaces;
using System;

namespace PAM.Models
{
    public class Expense : Model, ICopyable<Expense>, ICloneable<Expense>
    {
        private int id;
        public int ID { get { return id; } private set { id = value; } }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value == date)
                    return;

                date = value;
                OnPropertyChanged("Date");
            }
        }

        private float value;
        public float Value
        {
            get { return value; }
            set
            {
                if (value == this.value)
                    return;
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (value == description)
                    return;

                description = value;
                OnPropertyChanged("Description");
            }
        }

        //****************************************************************************************************************

        public Expense()
        {
            Date = DateTime.Now;
        }

        public void Copy(Expense from)
        {
            Date = from.Date;
            Value = from.Value;
            Description = from.Description;
        }

        public Expense Clone()
        {
            var exp = new Expense();
            exp.Copy(this);
            return exp;
        }
    }
}
