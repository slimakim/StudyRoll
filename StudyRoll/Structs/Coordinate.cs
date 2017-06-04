using System;
using StudyRoll.Interfaces;

namespace StudyRoll.Structs
{
    /// <summary>
    /// Coordinate.
    /// </summary>
    public struct Coordinate : ICoordinate
    {
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double Longitude { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StudyRoll.Structs.Coordinate"/> struct.
        /// </summary>
        /// <param name="latitude">Latitude.</param>
        /// <param name="longtitude">Longtitude.</param>
        public Coordinate(double latitude, double longtitude)
        {
            this.Latitude = latitude;
            this.Longitude = longtitude;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StudyRoll.Structs.Coordinate"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StudyRoll.Structs.Coordinate"/>.</returns>
        public override string ToString()
        {
            return string.Format("[Coordinate: Latitude={0}, Longitude={1}, HashCode={2}]", Latitude, Longitude, GetHashCode());
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="T:StudyRoll.Structs.Coordinate"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return (int)Latitude ^ (int)Longitude;
        }
    }
}
