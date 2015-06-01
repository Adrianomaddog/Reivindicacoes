using UnityEngine; // Pelo uso do random;

namespace MadSet
{
    public sealed class Set<T> // Tipo genérico;
    {
        // Atributos:
        private T[] values = null;

        // Métodos:
        public Set(){} // Construtor;
        public Set(T[] values) { this.values = values; } // Construtor/Constructor;
        ~Set() { } // Destrutor/Destructor;

        public int Length
        {
            get
            {
                return this.values.Length; // Retorna tamanho do array;
            }
            //set
            //{
            //    // Nada...
            //}
        }

        public void addSet(T[] values)
        {
            this.values = values;
        }

        public void addValue(T value)
        {
            if (this.values == null)
            {
                this.values = new T[1]; // Add tamanho 1;
                this.values[0] = value;
            }
            else
            {
                T[] newArray = new T[this.values.Length + 1]; // Novo array com um tamanho a mais;
                for (int i = 0; i < newArray.Length-1; i++)//foreach(T v in newArray)
                {
                    newArray[i] = this.values[i];
                }
                newArray[newArray.Length-1] = value;// Adiciona novo valor;
                this.values = newArray;
            }
        }

        public T getValue(int id)
        {
            return this.values[id];
        }
    }

    
    public class RandomPhrase
    {
        // Atributos:
        private Set<string> _set = null;

        // Métodos:
        public RandomPhrase() { this._set = new Set<string>(); }// Construtor padrão;
        public RandomPhrase(Set<string> set) { this._set = set; }// Construtor;
        public void setSet(Set<string> set) // Define o grupo;
        {
            this._set = set;
        }
        public void addPhrase(string phrase)
        {
            this._set.addValue(phrase);
        }
        public string getOne() // Pegar frase qualquer;
        {
            return this._set.getValue(Random.Range(0, this._set.Length));
        }
    }
}