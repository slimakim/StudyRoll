using System;
namespace DelegatesExample
{
    /// <summary>
    /// Set.
    /// </summary>
    public class Set
    {
        public Set(int numItems)
        {
            _items = new Object[numItems];
            for (int i = 0; i < numItems; i++)
            {
                _items[i] = i;
            }
        }

        /// <summary>
        /// The items.
        /// </summary>
        private readonly Object[] _items;

        public delegate void Feedback(Object value, int item, int numItems);

        /// <summary>
        /// Processes the items.
        /// </summary>
        /// <param name="feedback">Feedback.</param>
        public void ProcessItems(Feedback feedback)
        {
            for (int item = 0; item < _items.Length; item++)
            {
                //feedback?.Invoke(_items[item], item + 1, _items.Length);
                if (feedback != null)
                {
                    feedback.Invoke(_items[item], item + 1, _items.Length);
                }
            }
        }
    }
}
